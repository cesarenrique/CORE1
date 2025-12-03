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
    public class UsuariosModel : PageModel
    {
        private  CORE1.Models.TallerEF2 _context;

        public IList<Usuario> Usuarios { get; set; } = default!;
        public UsuariosModel(CORE1.Models.TallerEF2 context)
        {
            _context = context;
        }

        

        public async Task OnGetAsync()
        {
             this.Usuarios = await _context.Usuarios.ToListAsync();
        }
    }
}
