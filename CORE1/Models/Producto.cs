using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CORE1.Models;

public partial class Producto
{
    [Display(Description="Código del producto",
        Name = "Código",
        Prompt = "Código del producto",
        ShortName = "Cód."
        )]
    [Required(ErrorMessage ="Este campo es obligatorio")]
    public decimal Id { get; set; }

    [Display(Description = "Nombre del producto",
    Name = "Nombre",
    Prompt = "Nombre del producto",
    ShortName = "Nom."
    )]
    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string Nombre { get; set; } = null!;

    [Display(Description = "Descripcion del producto",
    Name = "Descripcion",
    Prompt = "Descripcion del producto",
    ShortName = "Desc."
    )]
    [Required(ErrorMessage = "Este campo es obligatorio")]
    public string? Descripcion { get; set; }


    [Display(Description = "Precio del producto",
        Name = "Precio",
        Prompt = "Precio del producto",
        ShortName = "Pre."
        )]
    [Required(ErrorMessage = "Este campo es obligatorio")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2")]
    [Range(0,Double.MaxValue,ErrorMessage = "El valor del campo{0} debe ser mayor que {1}")]
    public decimal Precio { get; set; }

    public decimal Categoria { get; set; }

    public virtual Categoria CategoriaNavigation { get; set; } = null!;
}
