using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManualidadesEunice.Models.ViewModels
{
    public class ProveedorVM
    {
        public Proveedor oProveedor { get; set; }

        public List<SelectListItem> oListaCategoria { get; set; }
    }
}
