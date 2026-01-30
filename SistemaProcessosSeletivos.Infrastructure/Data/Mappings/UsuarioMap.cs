using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

namespace SistemaProcessosSeletivos.Infrastructure.Data.Mappings;

public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario", "ACESSO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Cpf)
               .IsRequired()
               .HasMaxLength(11)
               .HasColumnType("varchar(11)");

        builder.HasIndex(x => x.Cpf)
               .IsUnique();

        builder.Property(x => x.NomeCompleto)
               .IsRequired()
               .HasMaxLength(200)
               .HasColumnType("varchar(200)");

        builder.Property(x => x.Email)
               .IsRequired()
               .HasMaxLength(200)
               .HasColumnType("varchar(200)");

        builder.Property(x => x.SenhaHash)
               .IsRequired()
               .HasMaxLength(255)
               .HasColumnType("varchar(255)");

        builder.Property(x => x.RowVer)
               .IsRowVersion();

        builder.Property(x => x.CreatedAt)
               .HasDefaultValueSql("SYSDATETIME()");

        builder.Property(x => x.IsDeleted)
               .HasDefaultValue(false);
    }
}
