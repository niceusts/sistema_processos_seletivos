using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

namespace SistemaProcessosSeletivos.Infrastructure.Data.Mappings;

public class RespostaArquivoMap : IEntityTypeConfiguration<RespostaArquivo>
{
    public void Configure(EntityTypeBuilder<RespostaArquivo> builder)
    {
        builder.ToTable("RespostaArquivo", "EXECUCAO");

        builder.HasKey(x => x.RespostaId);

        builder.Property(x => x.Caminho)
               .HasMaxLength(500)
               .HasColumnType("varchar(500)");

        builder.Property(x => x.Hash)
               .HasMaxLength(128)
               .HasColumnType("varchar(128)");

        builder.HasOne(x => x.Resposta)
               .WithOne()
               .HasForeignKey<RespostaArquivo>(x => x.RespostaId);
    }
}
