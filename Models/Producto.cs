using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManualidadesEunice.Models;


public partial class Producto
{
    [Display(Name = "Código")]
    public int CodigoProducto { get; set; }

    [Display(Name = "Categoría")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public int CodigoCategoria { get; set; }

    [Display(Name = "Marca")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public int CodigoMarca { get; set; }

    [Display(Name = "Presentación")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public int CodigoPresentacion { get; set; }

    [Display(Name = "Tipo producto")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public int CodigoTipoProducto { get; set; }

    [Display(Name = "Proveedor")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public int CodigoProveedor { get; set; }

    [Display(Name = "Código único")]
    public string? Codigo { get; set; }

    [Display(Name = "Nombre")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Nombre { get; set; } = null!;

    [Display(Name = "Costo")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Costo { get; set; } = null!;

    [Display(Name = "Cantidad")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Cantidad { get; set; } = null!;

    [Display(Name = "Precio unitario")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string PrecioUnidad { get; set; } = null!;

    [Display(Name = "Precio docena")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string PrecioDocena { get; set; } = null!;

    [Display(Name = "Precio mayorista")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string PrecioMayorista { get; set; } = null!;

    [Display(Name = "Stock")]
    public int? Stock { get; set; }

    [Display(Name = "Estado")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public byte Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Categoria CodigoCategoriaNavigation { get; set; } = null!;

    public virtual Marca CodigoMarcaNavigation { get; set; } = null!;

    public virtual Presentacion CodigoPresentacionNavigation { get; set; } = null!;

    public virtual Proveedor CodigoProveedorNavigation { get; set; } = null!;

    public virtual TipoProducto CodigoTipoProductoNavigation { get; set; } = null!;
}

