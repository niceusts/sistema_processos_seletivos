using System;

namespace SistemaProcessosSeletivos.Domain.Entities;

public class UsuarioLotacao
{
    public long Id { get; private set; }

    public long UsuarioId { get; private set; }
    public long SecretariaId { get; private set; }
    public long PerfilId { get; private set; }

    public DateTime? DataExpiracao { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
}
