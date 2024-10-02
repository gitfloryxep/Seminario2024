using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManualidadesEunice.Models;

public partial class Proveedor
{
    [Display(Name = "Código")]
    public int CodigoProveedor { get; set; }

    [Display(Name = "Categoría")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public int CodigoCategoria { get; set; }

    [Display(Name = "Proveedor")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string NombreProveedor { get; set; } = null!;

    [Display(Name = "Dirección")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string? Direccion { get; set; }

    [Display(Name = "Cuenta bancaria")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string NumeroCuenta { get; set; } = null!;

    [Display(Name = "Teléfono")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Telefono { get; set; } = null!;

    [Display(Name = "Banco")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string NombreBanco { get; set; } = null!;

    [Display(Name = "Estado")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public byte Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Categoria CodigoCategoriaN { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
