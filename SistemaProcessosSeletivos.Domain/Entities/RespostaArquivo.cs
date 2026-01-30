namespace SistemaProcessosSeletivos.Domain.Entities;

public class RespostaArquivo
{
    public long RespostaId { get; private set; }
    public string? Caminho { get; private set; }
    public string? Hash { get; private set; }

    public Resposta Resposta { get; private set; } = null!;
}
