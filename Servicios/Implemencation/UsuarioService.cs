using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ManualidadesEunice.Models;
using ManualidadesEunice.Servicios.Contrato;

namespace ManualidadesEunice.Servicios.Implemencation
{
    public class UsuarioService : IUsuarioService
    {
        private readonly EuniceContext _dbContext;
        public UsuarioService(EuniceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> GetUsuario(string correo, string contrasena)
        {
            Usuario usuario_encontrado = await _dbContext.Usuarios.Where(u => u.Email == correo && u.Contrasena == contrasena)
                 .FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _dbContext.Usuarios.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }

        public async Task<Usuario> UpdateUsuario(Usuario modelo)
        {
            _dbContext.Usuarios.Update(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}
