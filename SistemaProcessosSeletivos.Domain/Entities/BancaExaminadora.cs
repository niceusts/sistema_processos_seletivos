namespace SistemaProcessosSeletivos.Domain.Entities;

public class BancaExaminadora
{
    public long Id { get; private set; }

    public long EditalEtapaId { get; private set; }
    public string Nome { get; private set; } = null!;
}
