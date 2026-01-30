using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcessosSeletivos.Domain.Entities;

public class EditalEtapa
{
    public long Id { get; private set; }

    public long EditalId { get; private set; }

    public string Nome { get; private set; } = null!;
    public int Ordem { get; private set; }

    public int TipoAvaliacao { get; private set; }
    public bool EhEliminatoria { get; private set; }

    public decimal PesoPonderado { get; private set; }

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
}
