using System;
using System.Collections.Generic;

namespace ManualidadesEunice.Models;

public partial class Usuario
{
    public int CodigoUsuario { get; set; }

    public byte Rol { get; set; }

    public string NombreApellido { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string Telefono { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public byte Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
