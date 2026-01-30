using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

public class FormularioSecaoMap : IEntityTypeConfiguration<FormularioSecao>
{
    public void Configure(EntityTypeBuilder<FormularioSecao> builder)
    {
        builder.ToTable("FormularioSecao", "CONFIG");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Titulo)
               .IsRequired()
               .HasMaxLength(200)
               .HasColumnType("varchar(200)");

        builder.HasOne<Edital>()
               .WithMany()
               .HasForeignKey(x => x.EditalId);
    }
}
