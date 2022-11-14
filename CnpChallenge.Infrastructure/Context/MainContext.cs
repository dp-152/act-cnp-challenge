using CnpChallenge.Domain.Model.ClienteModel;
using Microsoft.EntityFrameworkCore;

namespace CnpChallenge.Infrastructure.Context;

public partial class MainContext : DbContext
{
    public MainContext(DbContextOptions<MainContext> opt) : base(opt)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(MainContext).Assembly,
            type => (type.Namespace ?? "").Contains("ModelConfig")
        );
        base.OnModelCreating(modelBuilder);
    }
    
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<ClienteEndereco> ClienteEnderecos { get; set; }
}