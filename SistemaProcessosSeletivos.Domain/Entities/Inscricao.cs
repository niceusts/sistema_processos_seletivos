using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcessosSeletivos.Domain.Entities;

public class Inscricao
{
    public long Id { get; private set; }

    public long EditalId { get; private set; }
    public long CandidatoId { get; private set; }

    public string ProtocoloGerado { get; private set; } = null!;
    public int StatusInscricao { get; private set; }

    public decimal? NotaFinal { get; private set; }
    public int? ClassificacaoAtual { get; private set; }
    public byte[]? RowVer { get; private set; }

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public Candidato Candidato { get; private set; } = null!;

    public ICollection<Resposta> Respostas { get; private set; } = new List<Resposta>();
}
