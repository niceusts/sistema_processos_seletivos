using System;

namespace SistemaProcessosSeletivos.Domain.Entities;

public class Permissao
{
    public long Id { get; private set; }

    public string Codigo { get; private set; } = null!;

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
}
