using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManualidadesEunice.Models;

public partial class Categoria
{
    [Display(Name = "Código")]
    public int CodigoCategoria { get; set; }

    [Display(Name = "Nombre")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Nombrecategoria { get; set; } = null!;

    [Display(Name = "Estado")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public byte Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    public virtual ICollection<Proveedor> Proveedors { get; set; } = new List<Proveedor>();
}
