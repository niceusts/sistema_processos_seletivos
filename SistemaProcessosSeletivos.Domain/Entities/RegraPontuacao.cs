using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcessosSeletivos.Domain.Entities;

public class RegraPontuacao
{
    public long Id { get; private set; }

    public long EditalEtapaId { get; private set; }

    public string Nome { get; private set; } = null!;
    public string TipoResultado { get; private set; } = null!;
}
