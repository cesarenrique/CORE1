using CORE1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CORE1.Pages
{
    public class LocalidadModel : PageModel
    {

        [BindProperty]
        public List<Tienda> Tiendas { get; set; }

        [BindProperty]
        public List<Localidad> Localidades { get; set; }

        [BindProperty]
        public Localidad localidad { get; set; }
        public string orden { get; set; }
        public string sentido { get; set; }

        public void OnGet(int id,string orden = "N", string sentido = "A")
        {
            Services.Service service = new Services.Service();
            IQueryable<Tienda> query = service.GetTiendas().AsQueryable();

            if (string.IsNullOrEmpty(orden))
            {
                this.orden = orden;
            }

            if (string.IsNullOrEmpty(sentido))
            {
                this.sentido = sentido;
            }
            switch (orden + sentido)
            {
                case "ND":
                    query = query.OrderByDescending(t => t.nombre);
                    break;
                case "NA":
                    query = query.OrderBy(t => t.nombre);
                    break;
                case "PD":
                    query = query.OrderByDescending(t => t.localidad_id);
                    break;
                case "PA":
                    query = query.OrderBy(t => t.localidad_id);
                    break;
                default:
                    query = query.OrderBy(t => t.nombre);
                    break;

            }

            this.sentido = (sentido == "A") ? "D" : "A";
            this.orden = orden;
            this.Tiendas = query.Where(p=> p.localidad_id ==id).ToList();
            this.Localidades = service.GetLocalidades();

            IQueryable<Localidad> query2 = service.GetLocalidades().AsQueryable();
            this.localidad = query2.Where(l => l.id == id).FirstOrDefault();

        }


    }

}
