namespace SistemaProcessosSeletivos.Domain.Entities;

public class RecursoAnalise
{
    public long Id { get; private set; }

    public long RecursoId { get; private set; }
    public long UsuarioAvaliadorId { get; private set; }

    public string ParecerTecnico { get; private set; } = null!;
    public bool DecisaoFinal { get; private set; }

    public DateTime DataAnalise { get; private set; }
}
