using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcessosSeletivos.Domain.Entities;
public class InscricaoHistoricoStatus
{
    public long Id { get; set; }

    public long InscricaoId { get; set; }
    public InscricaoStatus StatusAnterior { get; set; } = null!;
    public InscricaoStatus StatusNovo { get; set; } = null!;

    public long UsuarioId { get; set; }
    public string Justificativa { get; set; } = null!;

    public DateTime DataAlteracao { get; set; }
}
