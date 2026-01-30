using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcessosSeletivos.Domain.Entities;

public class Tenant
{
    public long Id { get; private set; }
    public string Nome { get; private set; } = null!;
    public string Tipo { get; private set; } = null!;

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public bool IsDeleted { get; private set; }
}
