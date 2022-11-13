using CnpChallenge.Domain.Model.ClienteModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CnpChallenge.Infrastructure.ModelConfig;

public class ClienteConfig : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder
            .ToTable(nameof(Cliente), "dbo")
            .HasKey(c => c.Id)
            .IsClustered();

        builder.Property(c => c.Nome).IsRequired().HasMaxLength(200);
        builder.Property(c => c.DtNascimento).IsRequired();
        builder.Property(c => c.Status).IsRequired().HasColumnType("tinyint");
        builder.Property(c => c.DatInclusao).IsRequired().HasDefaultValueSql("getdate()").ValueGeneratedOnAdd();

        builder
            .HasMany(c => c.Enderecos)
            .WithOne(e => e.Cliente)
            .HasForeignKey(e => e.IdCliente)
            .OnDelete(DeleteBehavior.Cascade);

    }
}