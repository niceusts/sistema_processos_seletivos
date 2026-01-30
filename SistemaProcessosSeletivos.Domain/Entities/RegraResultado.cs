namespace SistemaProcessosSeletivos.Domain.Entities;

public class RegraResultado
{
    public long Id { get; private set; }

    public long RegraPontuacaoId { get; private set; }

    public decimal Pontos { get; private set; }
    public decimal PontosMaximos { get; private set; }
}
