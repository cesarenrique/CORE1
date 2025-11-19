using CORE1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CORE1.Pages
{
    public class DetalleModel : PageModel
    {
       
        public Tienda tienda;

        [BindProperty]
        public Localidad localidad{ get; set; }
        public IActionResult OnGet(decimal id)
        {
            Services.Service service = new Services.Service();
            this.tienda = service.GetTiendas().Where(p=> p.id==id).FirstOrDefault();
            if(this.tienda == null)
            {
                return NotFound();
            }
           
            this.localidad = service.GetLocalidades().Where(p => p.id == this.tienda.localidad_id).FirstOrDefault(); ;

            return Page();
        }
    }
}
