using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

namespace SistemaProcessosSeletivos.Infrastructure.Data.Mappings;

public class RespostaDataMap : IEntityTypeConfiguration<RespostaData>
{
    public void Configure(EntityTypeBuilder<RespostaData> builder)
    {
        builder.ToTable("RespostaData", "EXECUCAO");

        builder.HasKey(x => x.RespostaId);

        builder.HasOne(x => x.Resposta)
               .WithOne()
               .HasForeignKey<RespostaData>(x => x.RespostaId);
    }
}
