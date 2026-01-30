using System;

namespace SistemaProcessosSeletivos.Domain.Entities;

public class Secretaria
{
    public long Id { get; private set; }

    public long TenantId { get; private set; }
    public string Nome { get; private set; } = null!;
    public string? Sigla { get; private set; }

    public bool Ativo { get; private set; } = true;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public bool IsDeleted { get; private set; }
}
