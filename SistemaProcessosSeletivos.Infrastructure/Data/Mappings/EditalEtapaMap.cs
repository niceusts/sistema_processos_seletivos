using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

public class EditalEtapaMap : IEntityTypeConfiguration<EditalEtapa>
{
    public void Configure(EntityTypeBuilder<EditalEtapa> builder)
    {
        builder.ToTable("EditalEtapa", "CONFIG");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
               .IsRequired()
               .HasMaxLength(100)
               .HasColumnType("varchar(100)");

        builder.Property(x => x.PesoPonderado)
               .HasPrecision(10, 2);

        builder.Property(x => x.CreatedAt)
               .HasDefaultValueSql("SYSDATETIME()");

        builder.HasOne<Edital>()
               .WithMany()
               .HasForeignKey(x => x.EditalId);
    }
}
