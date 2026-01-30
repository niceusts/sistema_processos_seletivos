using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

public class EditalMap : IEntityTypeConfiguration<Edital>
{
    public void Configure(EntityTypeBuilder<Edital> builder)
    {
        builder.ToTable("Edital", "CONFIG");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.NumeroEdital)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnType("varchar(50)");

        builder.Property(x => x.Titulo)
               .IsRequired()
               .HasMaxLength(200)
               .HasColumnType("varchar(200)");

        builder.Property(x => x.CreatedAt)
               .HasDefaultValueSql("SYSDATETIME()");

        builder.HasOne<Secretaria>()
               .WithMany()
               .HasForeignKey(x => x.SecretariaId);

        builder.HasOne<TipoProcesso>()
               .WithMany()
               .HasForeignKey(x => x.TipoProcessoId);
    }
}
