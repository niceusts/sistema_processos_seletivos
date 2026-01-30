namespace SistemaProcessosSeletivos.Domain.Entities;

public class Recurso
{
    public long Id { get; private set; }

    public long InscricaoId { get; private set; }
    public long EditalEtapaId { get; private set; }

    public int TipoRecurso { get; private set; }
    public int StatusRecurso { get; private set; }

    public DateTime DataAbertura { get; private set; }
}
