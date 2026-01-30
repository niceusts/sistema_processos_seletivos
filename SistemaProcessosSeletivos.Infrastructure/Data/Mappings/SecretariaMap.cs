using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

namespace SistemaProcessosSeletivos.Infrastructure.Data.Mappings;

public class SecretariaMap : IEntityTypeConfiguration<Secretaria>
{
    public void Configure(EntityTypeBuilder<Secretaria> builder)
    {
        builder.ToTable("Secretaria", "ACESSO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
               .IsRequired()
               .HasMaxLength(200)
               .HasColumnType("varchar(200)");

        builder.Property(x => x.Sigla)
               .HasMaxLength(20)
               .HasColumnType("varchar(20)");

        builder.Property(x => x.Ativo)
               .HasDefaultValue(true);

        builder.Property(x => x.CreatedAt)
               .HasDefaultValueSql("SYSDATETIME()");

        builder.Property(x => x.IsDeleted)
               .HasDefaultValue(false);

        builder.HasOne<Tenant>()
               .WithMany()
               .HasForeignKey(x => x.TenantId);
    }
}
