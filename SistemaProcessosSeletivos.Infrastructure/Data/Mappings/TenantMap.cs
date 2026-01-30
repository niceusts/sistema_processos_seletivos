using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

namespace SistemaProcessosSeletivos.Infrastructure.Data.Mappings;

public class TenantMap : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.ToTable("Tenant", "ACESSO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
               .IsRequired()
               .HasMaxLength(200)
               .HasColumnType("varchar(200)");

        builder.Property(x => x.Tipo)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnType("varchar(50)");

        builder.Property(x => x.CreatedAt)
               .HasDefaultValueSql("SYSDATETIME()");

        builder.Property(x => x.IsDeleted)
               .HasDefaultValue(false);
    }
}
