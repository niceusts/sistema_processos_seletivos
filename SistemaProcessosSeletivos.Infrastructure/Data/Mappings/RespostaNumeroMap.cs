using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

namespace SistemaProcessosSeletivos.Infrastructure.Data.Mappings;

public class RespostaNumeroMap : IEntityTypeConfiguration<RespostaNumero>
{
    public void Configure(EntityTypeBuilder<RespostaNumero> builder)
    {
        builder.ToTable("RespostaNumero", "EXECUCAO");

        builder.HasKey(x => x.RespostaId);

        builder.Property(x => x.Valor)
               .HasPrecision(18, 4);

        builder.HasOne(x => x.Resposta)
               .WithOne()
               .HasForeignKey<RespostaNumero>(x => x.RespostaId);
    }
}
