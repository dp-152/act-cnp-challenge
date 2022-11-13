using CnpChallenge.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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
