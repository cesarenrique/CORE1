using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CORE1.Models;

public partial class Categoria
{

    [Display(Description = "Código del producto",
    Name = "Código",
    Prompt = "Código del producto",
    ShortName = "Cód."
    )]
    [Required(ErrorMessage = "Este campo es obligatorio")]
    public decimal Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
