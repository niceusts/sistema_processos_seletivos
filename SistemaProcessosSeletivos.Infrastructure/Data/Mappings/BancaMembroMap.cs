using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

namespace SistemaProcessosSeletivos.Infrastructure.Data.Mappings;

public class BancaMembroMap : IEntityTypeConfiguration<BancaMembro>
{
    public void Configure(EntityTypeBuilder<BancaMembro> builder)
    {
        builder.ToTable("BancaMembro", "AVALIACAO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.EhPresidente)
               .IsRequired();

        builder.HasOne<BancaExaminadora>()
               .WithMany()
               .HasForeignKey(x => x.BancaExaminadoraId);

        builder.HasOne<Usuario>()
               .WithMany()
               .HasForeignKey(x => x.UsuarioId);
    }
}
