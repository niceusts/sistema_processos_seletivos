using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcessosSeletivos.Domain.Entities;

public class TipoProcesso
{
    public long Id { get; private set; }
    public string Nome { get; private set; } = null!;

    public bool RequerVagaReserva { get; private set; }
    public bool RequerIntegracaoSalarial { get; private set; }
}
