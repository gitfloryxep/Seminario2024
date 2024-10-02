using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManualidadesEunice.Models;

public partial class Cliente
{
    [Display(Name = "Código")]
    public int CodigoCliente { get; set; }

    [Display(Name = "Nombre")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string? NombreCliente { get; set; }

    [Display(Name = "Teléfono")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Telefono { get; set; } = null!;

    [Display(Name = "Dirección")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Direccion { get; set; } = null!;

    [Display(Name = "Estado")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public byte Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
