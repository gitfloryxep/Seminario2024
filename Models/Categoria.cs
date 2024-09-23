using System;
using System.Collections.Generic;

namespace ManualidadesEunice.Models;

public partial class Categoria
{
    public int CodigoCategoria { get; set; }

    public string Nombrecategoria { get; set; } = null!;

    public byte Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
