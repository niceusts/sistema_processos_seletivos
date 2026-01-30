namespace SistemaProcessosSeletivos.Domain.Entities;

public class RespostaNumero
{
    public long RespostaId { get; private set; }
    public decimal? Valor { get; private set; }

    public Resposta Resposta { get; private set; } = null!;
}
