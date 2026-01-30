using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

namespace SistemaProcessosSeletivos.Infrastructure.Data.Mappings;

public class RecursoAnaliseMap : IEntityTypeConfiguration<RecursoAnalise>
{
    public void Configure(EntityTypeBuilder<RecursoAnalise> builder)
    {
        builder.ToTable("RecursoAnalise", "JURIDICO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ParecerTecnico)
               .IsRequired()
               .HasColumnType("nvarchar(max)");

        builder.Property(x => x.DataAnalise)
               .HasDefaultValueSql("SYSDATETIME()");

        builder.HasIndex(x => x.RecursoId)
               .IsUnique();

        builder.HasOne<Recurso>()
               .WithMany()
               .HasForeignKey(x => x.RecursoId);

        builder.HasOne<Usuario>()
               .WithMany()
               .HasForeignKey(x => x.UsuarioAvaliadorId);
    }
}
