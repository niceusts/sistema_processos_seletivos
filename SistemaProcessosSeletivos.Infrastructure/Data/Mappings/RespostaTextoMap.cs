using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

namespace SistemaProcessosSeletivos.Infrastructure.Data.Mappings;

public class RespostaTextoMap : IEntityTypeConfiguration<RespostaTexto>
{
    public void Configure(EntityTypeBuilder<RespostaTexto> builder)
    {
        builder.ToTable("RespostaTexto", "EXECUCAO");

        builder.HasKey(x => x.RespostaId);

        builder.HasOne(x => x.Resposta)
               .WithOne()
               .HasForeignKey<RespostaTexto>(x => x.RespostaId);
    }
}
