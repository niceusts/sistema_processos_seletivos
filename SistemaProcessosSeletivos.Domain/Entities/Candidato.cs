using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcessosSeletivos.Domain.Entities;

public class Candidato
{
    public long Id { get; private set; }

    public long UsuarioId { get; private set; }
    public string? NomeSocial { get; private set; }
    public DateTime DataNascimento { get; private set; }

    public bool Pcd { get; private set; }
    public bool PossuiCadUnico { get; private set; }

    public ICollection<Inscricao> Inscricoes { get; private set; } = new List<Inscricao>();
}