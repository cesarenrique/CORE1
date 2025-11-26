using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CORE1.Models;

namespace CORE1.Pages
{
    public class NuevoModel : PageModel
    {
        private readonly CORE1.Models.TallerEF2 _context;

        public NuevoModel(CORE1.Models.TallerEF2 context)
        {
            _context = context;
        }


        [BindProperty]
        public Producto Producto { get; set; } = default!;

        public IList<SelectListItem> Categorias { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Productos==null || Producto==null)
            {
                return Page();
            }

            _context.Productos.Add(Producto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public IActionResult OnGet()
        {
            var listCats = (from c in _context.Categorias
                           select new SelectListItem
                           {
                               Value = c.Id.ToString(),
                               Text = c.Nombre
                           }).ToList<SelectListItem>();
            listCats.Insert(0, new SelectListItem { Value = "", Text = "Seleccione una categoría" });
            ViewData["Categorias"] = listCats;
            Categorias = listCats;
            return Page();
        }
    }
}
