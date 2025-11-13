using CORE1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CORE1.Pages
{
    public class TiendaModel:PageModel
    {
        [BindProperty]
        public List<Tienda> Tiendas { get; set; }
        public void OnGet()
        {
            Services.Service service = new Services.Service();
            Tiendas = service.GetTiendas();
        }

    }
}
