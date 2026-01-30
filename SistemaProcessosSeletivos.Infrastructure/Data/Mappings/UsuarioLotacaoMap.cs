using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

namespace SistemaProcessosSeletivos.Infrastructure.Data.Mappings;

public class UsuarioLotacaoMap : IEntityTypeConfiguration<UsuarioLotacao>
{
    public void Configure(EntityTypeBuilder<UsuarioLotacao> builder)
    {
        builder.ToTable("UsuarioLotacao", "ACESSO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedAt)
               .HasDefaultValueSql("SYSDATETIME()");

        builder.HasOne<Usuario>()
               .WithMany()
               .HasForeignKey(x => x.UsuarioId);

        builder.HasOne<Secretaria>()
               .WithMany()
               .HasForeignKey(x => x.SecretariaId);

        builder.HasOne<Perfil>()
               .WithMany()
               .HasForeignKey(x => x.PerfilId);
    }
}
