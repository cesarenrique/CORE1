using System;
using System.Collections.Generic;

namespace CORE1.Models;

public partial class Marca
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Xurl { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
