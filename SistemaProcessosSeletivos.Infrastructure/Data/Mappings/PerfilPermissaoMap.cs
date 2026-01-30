using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

namespace SistemaProcessosSeletivos.Infrastructure.Data.Mappings;

public class PerfilPermissaoMap : IEntityTypeConfiguration<PerfilPermissao>
{
    public void Configure(EntityTypeBuilder<PerfilPermissao> builder)
    {
        builder.ToTable("PerfilPermissao", "ACESSO");

        builder.HasKey(x => new { x.PerfilId, x.PermissaoId });

        builder.HasOne<Perfil>()
               .WithMany()
               .HasForeignKey(x => x.PerfilId);

        builder.HasOne<Permissao>()
               .WithMany()
               .HasForeignKey(x => x.PermissaoId);
    }
}
