using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

namespace SistemaProcessosSeletivos.Infrastructure.Data.Mappings;

public class BancaExaminadoraMap : IEntityTypeConfiguration<BancaExaminadora>
{
    public void Configure(EntityTypeBuilder<BancaExaminadora> builder)
    {
        builder.ToTable("BancaExaminadora", "AVALIACAO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
               .IsRequired()
               .HasMaxLength(200)
               .HasColumnType("varchar(200)");

        builder.HasOne<EditalEtapa>()
               .WithMany()
               .HasForeignKey(x => x.EditalEtapaId);
    }
}
