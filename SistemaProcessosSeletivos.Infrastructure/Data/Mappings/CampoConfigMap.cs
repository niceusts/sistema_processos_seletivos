using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

public class CampoConfigMap : IEntityTypeConfiguration<CampoConfig>
{
    public void Configure(EntityTypeBuilder<CampoConfig> builder)
    {
        builder.ToTable("CampoConfig", "CONFIG");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Label)
               .IsRequired()
               .HasMaxLength(200)
               .HasColumnType("varchar(200)");

        builder.Property(x => x.VariavelCodigo)
               .IsRequired()
               .HasMaxLength(100)
               .HasColumnType("varchar(100)");

        builder.Property(x => x.EhDadoSensivel)
               .HasDefaultValue(false);

        builder.HasIndex(x => new { x.FormularioSecaoId, x.VariavelCodigo })
               .IsUnique();

        builder.HasOne<FormularioSecao>()
               .WithMany()
               .HasForeignKey(x => x.FormularioSecaoId);
    }
}
