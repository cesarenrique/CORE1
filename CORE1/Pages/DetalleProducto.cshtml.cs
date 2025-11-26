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

        public Categoria Categoria { get; set; } = default!;

        public Marca Marca { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(decimal? id)
        {
            if (id != null)
            {
                //return NotFound();
                this.Producto = null;
                this.Categoria = null;
                this.Marca = null;
            }

            this.Producto = await _context.Productos.Include(p => p.CategoriaNavigation).FirstOrDefaultAsync(m => m.Id == id);
            
            if (id!=null)
            {   
                var Producto2 = await _context.Productos.Where(m => m.Id == id).FirstOrDefaultAsync();
                if (Producto2.Categoria!=null) this.Categoria = await _context.Categorias.Where(m => m.Id == Producto2.Categoria).FirstOrDefaultAsync();

                if (Producto2.Marca != null) this.Marca = await _context.Marcas.Where(m => m.Id == Producto2.Marca).FirstOrDefaultAsync();
            }
                /*if (producto != null)
            {
               /* return NotFound();
            }
            else
            {
                Producto = producto;
            }*/
            return Page();
        }
    }
}
