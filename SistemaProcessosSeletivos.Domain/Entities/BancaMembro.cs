namespace SistemaProcessosSeletivos.Domain.Entities;

public class BancaMembro
{
    public long Id { get; private set; }

    public long BancaExaminadoraId { get; private set; }
    public long UsuarioId { get; private set; }

    public bool EhPresidente { get; private set; }
}
