using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcessosSeletivos.Domain.Entities;

public class Edital
{
    public long Id { get; private set; }

    public long SecretariaId { get; private set; }
    public long TipoProcessoId { get; private set; }

    public string NumeroEdital { get; private set; } = null!;
    public string Titulo { get; private set; } = null!;

    public int StatusEdital { get; private set; }

    public DateTime DataInicioInscricao { get; private set; }
    public DateTime DataFimInscricao { get; private set; }

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
}
