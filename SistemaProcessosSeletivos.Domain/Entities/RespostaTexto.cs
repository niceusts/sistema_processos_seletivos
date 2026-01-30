namespace SistemaProcessosSeletivos.Domain.Entities;

public class RespostaTexto
{
    public long RespostaId { get; private set; }
    public string? Valor { get; private set; }

    public Resposta Resposta { get; private set; } = null!;
}
