using System;

namespace SistemaProcessosSeletivos.Domain.Entities;

public class Perfil
{
    public long Id { get; private set; }

    public string Codigo { get; private set; } = null!;
    public string Nome { get; private set; } = null!;

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
}
