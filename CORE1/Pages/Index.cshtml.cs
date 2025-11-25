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
    public class IndexModel : PageModel
    {
        private readonly CORE1.Models.TallerEF2 _context;

        public IndexModel(CORE1.Models.TallerEF2 context)
        {
            _context = context;
        }

        public IList<Producto> Producto { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Producto = await _context.Productos
                .Include(p => p.CategoriaNavigation).ToListAsync();
        }
    }
}
