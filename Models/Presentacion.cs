using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManualidadesEunice.Models;

public partial class Presentacion
{
    [Display(Name = "Código")]
    public int CodigoPresentacion { get; set; }

    [Display(Name = "Nombre")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string NombrePresentacion { get; set; } = null!;

    [Display(Name = "Estado")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public byte Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
