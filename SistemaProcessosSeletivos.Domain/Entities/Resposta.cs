namespace SistemaProcessosSeletivos.Domain.Entities;

public class Resposta
{
    public long Id { get; private set; }

    public long InscricaoId { get; private set; }
    public long CampoConfigId { get; private set; }

    public int TipoDado { get; private set; }

    public Inscricao Inscricao { get; private set; } = null!;
}
