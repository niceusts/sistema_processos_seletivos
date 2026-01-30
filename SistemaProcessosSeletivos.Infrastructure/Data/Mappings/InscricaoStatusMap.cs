using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

namespace SistemaProcessosSeletivos.Infrastructure.Data.Mappings;

public class InscricaoStatusMap : IEntityTypeConfiguration<InscricaoStatus>
{
    public void Configure(EntityTypeBuilder<InscricaoStatus> builder)
    {
        builder.ToTable("InscricaoStatus", "EXECUCAO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.NumeroEdital)
               .IsRequired()
               .HasColumnType("nvarchar(max)");

        builder.Property(x => x.Titulo)
               .IsRequired()
               .HasColumnType("nvarchar(max)");

        builder.Property(x => x.DescricaoHtml)
               .IsRequired()
               .HasColumnType("nvarchar(max)");

        builder.Property(x => x.ConfiguracoesJson)
               .HasColumnType("nvarchar(max)");
    }
}
