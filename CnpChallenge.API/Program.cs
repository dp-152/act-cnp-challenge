using System.Reflection;
using CnpChallenge.API.ServiceRegistration.Utility;
using CnpChallenge.Application.Contracts.Interfaces.Feature;
using CnpChallenge.Application.Feature.Cliente;
using CnpChallenge.Domain.Interfaces.Manager;
using CnpChallenge.Domain.Interfaces.Repository;
using CnpChallenge.Domain.Manager;
using CnpChallenge.Infrastructure.Context;
using CnpChallenge.Infrastructure.Repository;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Polly;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers(options =>
    {
        options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
    })
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.Formatting = Formatting.Indented;
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate;
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    });

builder.Services
    .AddApiVersioning(options =>
    {
        options.ReportApiVersions = true;
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = new ApiVersion(1, 0);
    });

builder.Services
    .AddVersionedApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

builder.Services.AddDbContext<MainContext>((_, optionsBuilder) =>
{
    optionsBuilder
        .UseMemoryCache(new MemoryCache(new MemoryCacheOptions { SizeLimit = 100 }))
        .UseLazyLoadingProxies()
        .UseSqlServer(builder.Configuration.GetConnectionString("Default"),
            opt =>
            {
                opt.MigrationsHistoryTable("__EFMigrationHistory", "dbo");
                opt.EnableRetryOnFailure();
                opt.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            });
});

builder.Services.AddValidatorsFromAssembly(Assembly.Load("CnpChallenge.Domain"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IClienteRepository, SqlClienteRepository>();
builder.Services.AddScoped<IClienteServices, ClienteServices>();
builder.Services.AddScoped<IClienteManager, ClienteManager>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var retry = Policy.Handle<SqlException>().WaitAndRetry(new[]
    {
        TimeSpan.FromSeconds(3),
        TimeSpan.FromSeconds(5),
        TimeSpan.FromSeconds(8),
        TimeSpan.FromSeconds(15),
        TimeSpan.FromSeconds(30),
        TimeSpan.FromSeconds(60),
        TimeSpan.FromSeconds(90),
    });
    var service = scope.ServiceProvider.GetRequiredService<MainContext>();

    await retry.Execute(async () => await service.Database.MigrateAsync());
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{
}