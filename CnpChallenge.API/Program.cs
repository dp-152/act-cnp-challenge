using System.Reflection;
using CnpChallenge.Application.Contracts.Interfaces.Feature;
using CnpChallenge.Application.Feature.Cliente;
using CnpChallenge.Domain.Interfaces.Manager;
using CnpChallenge.Domain.Interfaces.Repository;
using CnpChallenge.Domain.Manager;
using CnpChallenge.Infrastructure.Context;
using CnpChallenge.Infrastructure.Repository;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.Formatting = Formatting.Indented;
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate;
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    });
builder.Services.AddDbContext<MainContext>((_, optionsBuilder) =>
{
    optionsBuilder
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

using (var scope = app.Services.CreateScope()) {
    var service = scope.ServiceProvider.GetRequiredService<MainContext>();
    await service.Database.MigrateAsync();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
