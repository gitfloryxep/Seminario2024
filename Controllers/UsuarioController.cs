using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManualidadesEunice.Models;
using ManualidadesEunice.Servicios.Contrato;
using System.Collections;
using ManualidadesEunice.Recursos;

namespace ManualidadesEunice.Controllers
{
    public class UsuarioController : Controller
    { 
        private readonly EuniceContext _context;

        public UsuarioController(EuniceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Usuario> lista = await _context.Usuarios.ToListAsync();
            return View(lista);

            //return View(await _context.Usuarios.ToListAsync());
        }


        [HttpGet]
        public async Task<IActionResult> Editar(int? Codigo)
        {
            Usuario usuario = await _context.Usuarios.FirstAsync(usu => usu.CodigoUsuario == Codigo);
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Editar( Usuario usuario)
        {
            usuario.FechaRegistro = DateTime.Now;
            _context.Usuarios.Update(usuario);
            usuario.Contrasena = Utilidades.EncriptarClave(usuario.Contrasena);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Usuario");
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int Codigo)
        {
            var usuario = await _context.Usuarios.FindAsync(Codigo);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            //Usuario usuario = await _context.Usuarios.FirstAsync(usu => usu.CodigoUsuario == Codigo);
            //_context.Usuarios.Remove(usuario);
            //await _context.SaveChangesAsync();
            //return RedirectToAction("Index", "Usuario");
        }
    }
}
