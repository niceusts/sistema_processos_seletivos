using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcessosSeletivos.Domain.Entities;

public class Usuario
{
    public long Id { get; private set; }

    public string Cpf { get; private set; } = null!;
    public string NomeCompleto { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string SenhaHash { get; private set; } = null!;

    public DateTime? UltimoLogin { get; private set; }
    public byte[]? RowVer { get; private set; }

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public bool IsDeleted { get; private set; }
}
