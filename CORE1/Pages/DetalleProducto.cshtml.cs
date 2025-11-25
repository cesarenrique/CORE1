using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CORE1.Models;

namespace CORE1.Pages
{
    public class DetalleProductoModel : PageModel
    {
        private readonly CORE1.Models.TallerEF2 _context;

        public DetalleProductoModel(CORE1.Models.TallerEF2 context)
        {
            _context = context;
        }

        public Producto Producto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            else
            {
                Producto = producto;
            }
            return Page();
        }
    }
}
