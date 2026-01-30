using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

public class CampoOpcaoMap : IEntityTypeConfiguration<CampoOpcao>
{
    public void Configure(EntityTypeBuilder<CampoOpcao> builder)
    {
        builder.ToTable("CampoOpcao", "CONFIG");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.TextoVisivel)
               .IsRequired()
               .HasMaxLength(200)
               .HasColumnType("varchar(200)");

        builder.Property(x => x.ValorArmazenado)
               .IsRequired()
               .HasMaxLength(100)
               .HasColumnType("varchar(100)");

        builder.HasOne<CampoConfig>()
               .WithMany()
               .HasForeignKey(x => x.CampoConfigId);
    }
}
