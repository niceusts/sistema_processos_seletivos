using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

namespace SistemaProcessosSeletivos.Infrastructure.Data.Mappings;

public class CandidatoMap : IEntityTypeConfiguration<Candidato>
{
    public void Configure(EntityTypeBuilder<Candidato> builder)
    {
        builder.ToTable("Candidato", "EXECUCAO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.NomeSocial)
               .HasMaxLength(200)
               .HasColumnType("varchar(200)");

        builder.Property(x => x.DataNascimento)
               .HasColumnType("date");

        builder.Property(x => x.Pcd)
               .HasDefaultValue(false);

        builder.Property(x => x.PossuiCadUnico)
               .HasDefaultValue(false);

        builder.HasOne<Usuario>()
               .WithMany()
               .HasForeignKey(x => x.UsuarioId);
    }
}
