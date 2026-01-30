using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcessosSeletivos.Domain.Entities;

public class CampoOpcao
{
    public long Id { get; private set; }
    public long CampoConfigId { get; private set; }

    public string TextoVisivel { get; private set; } = null!;
    public string ValorArmazenado { get; private set; } = null!;

    public int Ordem { get; private set; }
}
