using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManualidadesEunice.Models;

public partial class TipoProducto
{
    [Display(Name = "Código")]
    public int CodigoTipoProducto { get; set; }

    [Display(Name = "Nombre")]
    [Required(ErrorMessage = "El campo {0} es requerido.")]
    public string NombreTipoProducto { get; set; } = null!;

    [Display(Name = "Estado")]
    [Required(ErrorMessage = "El campo {0} es requerido.")]
    public byte Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
