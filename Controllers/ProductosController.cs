using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManualidadesEunice.Models;
using ManualidadesEunice.Models.ViewModels;

namespace ManualidadesEunice.Controllers
{
    public class ProductosController : Controller
    {
        private readonly EuniceContext _context;

        public ProductosController(EuniceContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            var euniceContext = _context.Productos.Include(p => p.CodigoCategoriaNavigation).Include(p => p.CodigoMarcaNavigation).Include(p => p.CodigoPresentacionNavigation).Include(p => p.CodigoProveedorNavigation).Include(p => p.CodigoTipoProductoNavigation);
            return View(await euniceContext.ToListAsync());
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.CodigoCategoriaNavigation)
                .Include(p => p.CodigoMarcaNavigation)
                .Include(p => p.CodigoPresentacionNavigation)
                .Include(p => p.CodigoProveedorNavigation)
                .Include(p => p.CodigoTipoProductoNavigation)
                .FirstOrDefaultAsync(m => m.CodigoProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["CodigoCategoria"] = new SelectList(_context.Categoria, "CodigoCategoria", "Nombrecategoria");
            ViewData["CodigoMarca"] = new SelectList(_context.Marcas, "CodigoMarca", "NombreMarca");
            ViewData["CodigoPresentacion"] = new SelectList(_context.Presentacion, "CodigoPresentacion", "NombrePresentacion");
            ViewData["CodigoProveedor"] = new SelectList(_context.Proveedores, "CodigoProveedor", "NombreProveedor");
            ViewData["CodigoTipoProducto"] = new SelectList(_context.TipoProductos, "CodigoTipoProducto", "NombreTipoProducto");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoProducto,CodigoCategoria,CodigoMarca,CodigoPresentacion,CodigoTipoProducto,CodigoProveedor,Codigo,Nombre,Costo,Cantidad,PrecioUnidad,PrecioDocena,PrecioMayorista,Stock,Estado,FechaRegistro")] Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["CodigoCategoria"] = new SelectList(_context.Categoria, "CodigoCategoria", "Nombrecategoria", producto.CodigoCategoria);
            ViewData["CodigoMarca"] = new SelectList(_context.Marcas, "CodigoMarca", "NombreMarca", producto.CodigoMarca);
            ViewData["CodigoPresentacion"] = new SelectList(_context.Presentacion, "CodigoPresentacion", "NombrePresentacion", producto.CodigoPresentacion);
            ViewData["CodigoProveedor"] = new SelectList(_context.Proveedores, "CodigoProveedor", "NombreProveedor", producto.CodigoProveedor);
            ViewData["CodigoTipoProducto"] = new SelectList(_context.TipoProductos, "CodigoTipoProducto", "NombreTipoProducto", producto.CodigoTipoProducto);
            return View(producto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoProducto,CodigoCategoria,CodigoMarca,CodigoPresentacion,CodigoTipoProducto,CodigoProveedor,Codigo,Nombre,Costo,Cantidad,PrecioUnidad,PrecioDocena,PrecioMayorista,Stock,Estado,FechaRegistro")] Producto producto)
        {
            if (id != producto.CodigoProducto)
            {
                return NotFound();
            }
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Productos");
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.CodigoCategoriaNavigation)
                .Include(p => p.CodigoMarcaNavigation)
                .Include(p => p.CodigoPresentacionNavigation)
                .Include(p => p.CodigoProveedorNavigation)
                .Include(p => p.CodigoTipoProductoNavigation)
                .FirstOrDefaultAsync(m => m.CodigoProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.CodigoProducto == id);
        }
    }
}
