using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

namespace SistemaProcessosSeletivos.Infrastructure.Data.Mappings;

public class PerfilMap : IEntityTypeConfiguration<Perfil>
{
    public void Configure(EntityTypeBuilder<Perfil> builder)
    {
        builder.ToTable("Perfil", "ACESSO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Codigo)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnType("varchar(50)");

        builder.HasIndex(x => x.Codigo)
               .IsUnique();

        builder.Property(x => x.Nome)
               .IsRequired()
               .HasMaxLength(100)
               .HasColumnType("varchar(100)");

        builder.Property(x => x.CreatedAt)
               .HasDefaultValueSql("SYSDATETIME()");
    }
}
