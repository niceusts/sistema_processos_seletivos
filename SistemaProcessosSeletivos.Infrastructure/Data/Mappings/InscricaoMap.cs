using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

namespace SistemaProcessosSeletivos.Infrastructure.Data.Mappings;

public class InscricaoMap : IEntityTypeConfiguration<Inscricao>
{
    public void Configure(EntityTypeBuilder<Inscricao> builder)
    {
        builder.ToTable("Inscricao", "EXECUCAO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ProtocoloGerado)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnType("varchar(50)");

        builder.Property(x => x.NotaFinal)
               .HasPrecision(10, 2);

        builder.Property(x => x.RowVer)
               .IsRowVersion();

        builder.Property(x => x.CreatedAt)
               .HasDefaultValueSql("SYSDATETIME()");

        builder.HasOne(x => x.Candidato)
               .WithMany(c => c.Inscricoes)
               .HasForeignKey(x => x.CandidatoId);

        builder.HasOne<Edital>()
               .WithMany()
               .HasForeignKey(x => x.EditalId);
    }
}
