using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

namespace SistemaProcessosSeletivos.Infrastructure.Data.Mappings;

public class PermissaoMap : IEntityTypeConfiguration<Permissao>
{
    public void Configure(EntityTypeBuilder<Permissao> builder)
    {
        builder.ToTable("Permissao", "ACESSO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Codigo)
               .IsRequired()
               .HasMaxLength(100)
               .HasColumnType("varchar(100)");

        builder.HasIndex(x => x.Codigo)
               .IsUnique();

        builder.Property(x => x.CreatedAt)
               .HasDefaultValueSql("SYSDATETIME()");
    }
}
