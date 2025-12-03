using CORE1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE1.Pages
{
    [Authorize]
    public class BorrarModel : PageModel
    {
        private readonly CORE1.Models.TallerEF2 _context;

        public BorrarModel(CORE1.Models.TallerEF2 context)
        {
            _context = context;
        }

        [BindProperty]
        public Producto Producto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null || _context.Productos==null)
            {
                //return NotFound();
                TempData["ErrorMessage"] = "No se ha especificado un producto para borrar.";
                return RedirectToPage("./Index");
            }

            var producto = await _context.Productos.FirstOrDefaultAsync(m => m.Id == id);

            if (producto == null)
            {
                //return NotFound();
                TempData["ErrorMessage"] = "No se ha especificado un producto para borrar.";
                return RedirectToPage("./Index");
            }
            else
            {
                Producto = producto;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                Producto = producto;
                _context.Productos.Remove(Producto);
                await _context.SaveChangesAsync();
                TempData["ok"] = "Producto borrado correctamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "No se ha encontrado el producto para borrar.";
            }

                return RedirectToPage("./Index");
        }
    }
}
