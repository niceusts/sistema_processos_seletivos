using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcessosSeletivos.Domain.Entities;

public class InscricaoStatus
{
    public int Id { get; private set; }

    public int TenantId { get; private set; }
    public int TipoProcessoId { get; private set; }

    public string NumeroEdital { get; private set; } = null!;
    public string Titulo { get; private set; } = null!;
    public string DescricaoHtml { get; private set; } = null!;

    public DateTime DataInicioInscricao { get; private set; }
    public DateTime DataFimInscricao { get; private set; }

    public int StatusEdital { get; private set; }

    public string? ConfiguracoesJson { get; private set; }

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
}
