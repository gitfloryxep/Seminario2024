using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManualidadesEunice.Models;

public partial class Marca
{
    [Display(Name = "Código")]
    public int CodigoMarca { get; set; }

    [Display(Name = "Nombre")]
    [Required(ErrorMessage = "El campo {0} es requerido.")]
    public string NombreMarca { get; set; } = null!;

    [Display(Name = "Estado")]
    [Required(ErrorMessage = "El campo {0} es requerido.")]
    public byte Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
