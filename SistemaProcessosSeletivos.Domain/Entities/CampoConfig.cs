using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcessosSeletivos.Domain.Entities;

public class CampoConfig
{
    public long Id { get; private set; }

    public long FormularioSecaoId { get; private set; }

    public string Label { get; private set; } = null!;
    public string VariavelCodigo { get; private set; } = null!;
    public int TipoDado { get; private set; }

    public bool Obrigatorio { get; private set; }
    public bool EhDadoSensivel { get; private set; }

    public int Ordem { get; private set; }
}
