using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcessosSeletivos.Domain.Entities;

public class FormularioSecao
{
    public long Id { get; private set; }
    public long EditalId { get; private set; }

    public string Titulo { get; private set; } = null!;
    public int Ordem { get; private set; }
}
