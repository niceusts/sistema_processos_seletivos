namespace SistemaProcessosSeletivos.Domain.Entities;

public class RespostaData
{
    public long RespostaId { get; private set; }
    public DateTime? Valor { get; private set; }

    public Resposta Resposta { get; private set; } = null!;
}
