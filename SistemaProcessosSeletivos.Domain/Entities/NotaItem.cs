namespace SistemaProcessosSeletivos.Domain.Entities;

public class NotaItem
{
    public long Id { get; private set; }

    public long DistribuicaoAvaliacaoId { get; private set; }
    public long RegraPontuacaoId { get; private set; }

    public decimal NotaAtribuida { get; private set; }
    public string? JustificativaTexto { get; private set; }
}
