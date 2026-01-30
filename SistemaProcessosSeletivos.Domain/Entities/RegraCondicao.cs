namespace SistemaProcessosSeletivos.Domain.Entities;

public class RegraCondicao
{
    public long Id { get; private set; }

    public long RegraPontuacaoId { get; private set; }
    public long CampoConfigId { get; private set; }

    public string Operador { get; private set; } = null!;
    public string ValorReferencia { get; private set; } = null!;
}
