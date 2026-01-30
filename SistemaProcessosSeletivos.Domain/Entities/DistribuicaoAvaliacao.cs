namespace SistemaProcessosSeletivos.Domain.Entities;

public class DistribuicaoAvaliacao
{
    public long Id { get; private set; }

    public long InscricaoId { get; private set; }
    public long BancaMembroId { get; private set; }

    public int StatusAvaliacao { get; private set; }
}
