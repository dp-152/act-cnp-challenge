using CnpChallenge.Domain.Model.ClienteModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CnpChallenge.Infrastructure.ModelConfig;

public class ClienteEnderecoConfig : IEntityTypeConfiguration<ClienteEndereco>
{
    public void Configure(EntityTypeBuilder<ClienteEndereco> builder)
    {
        builder
            .ToTable(nameof(ClienteEndereco), "dbo")
            .HasKey(e => e.Id)
            .IsClustered();

        builder.Property(e => e.Logradouro).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Cep).IsRequired().HasMaxLength(8);
        builder.Property(e => e.Uf).IsRequired().HasMaxLength(2);
        builder.Property(e => e.Cidade).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Bairro).IsRequired().HasMaxLength(60);
        builder.Property(e => e.Status).IsRequired().HasColumnType("tinyint");
        builder.Property(e => e.DatInclusao).HasDefaultValueSql("getdate()").ValueGeneratedOnAdd();
    }
}