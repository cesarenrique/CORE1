using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CORE1.Models;
using System.Security.AccessControl;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace CORE1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CORE1.Models.TallerEF2 _context;

        public string orden { get; set; }

        public string dir { get; set; }

        public string cat { get; set; }

        public IndexModel(CORE1.Models.TallerEF2 context)
        {
            _context = context;
            orden = "N";
            dir= "ASC";
            cat = "";
        }

        public IList<Producto> Producto { get;set; } = default!;
        public IList<SelectListItem> Categorias { get; set; } = default!;

        public async Task OnGetAsync(string o = "N", string d = "ASC", string c = "")
        {
            IQueryable<Producto> list = null;
            if (String.IsNullOrEmpty(c))
            {
                list = from p in _context.Productos select p;
            }
            else
            {
                try
                {
                    decimal idCat = decimal.Parse(c);
                    list = from p in _context.Productos
                           where p.Categoria == idCat
                           select p;
                }
                catch (Exception)
                {
                    list = from p in _context.Productos select p;
                }

            }
            cat = c;
            Expression<Func<Producto, object>> expresion = (x => x.Nombre);

            switch (o)
            {
                case "N":
                    expresion = (x => x.Nombre);

                    break;

                case "P":
                    expresion = (x => x.Precio);
                    break;

                case "C":
                    expresion = (x => x.CategoriaNavigation.Nombre);
                    break;
            }
            if (d == "ASC")
            {
                list = list.OrderBy(expresion);
            }
            else
            {
                list = list.OrderByDescending(expresion);
            }
            dir = (d == "ASC") ? "DESC" : "ASC";

            Producto = await list.AsNoTracking()
                .Include(p => p.CategoriaNavigation).ToListAsync();

            var cats = await _context.Categorias.OrderBy(c => c.Nombre).ToListAsync();
            Categorias = new List<SelectListItem>();

            Categorias.Add(new SelectListItem { Value = "", Text = "Todas" });

            foreach (var aux in cats)
            {
                Categorias.Add(new SelectListItem
                {
                    Value = aux.Id.ToString(),
                    Text = aux.Nombre
                });
            }
        }
    }
}
