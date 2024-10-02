using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManualidadesEunice.Models;

public partial class Usuario
{
    [Display(Name = "Código")]
    public int CodigoUsuario { get; set; }

    [Display(Name = "Rol")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public byte Rol { get; set; }

    [Display(Name = "Nombre completo")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string NombreApellido { get; set; } = null!;

    [Display(Name = "Fecha de nacimiento")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public DateOnly FechaNacimiento { get; set; }

    [Display(Name = "Teléfono")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Telefono { get; set; } = null!;

    [Display(Name = "Correo")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Email { get; set; } = null!;

    [Display(Name = "Contraseña")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Contrasena { get; set; } = null!;

    [Display(Name = "Estado")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public byte Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
