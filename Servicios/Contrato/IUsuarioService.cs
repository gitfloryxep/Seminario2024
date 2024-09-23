using ManualidadesEunice.Models;
using Microsoft.EntityFrameworkCore;

namespace ManualidadesEunice.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuario(string correo, string contrasena);
        Task<Usuario> SaveUsuario(Usuario modelo);
        Task<Usuario> UpdateUsuario(Usuario modelo);

    }
}
