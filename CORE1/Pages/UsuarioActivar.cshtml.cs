using CORE1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CORE1.Pages
{
    public class UsuarioActivarModel : PageModel
    {
        private readonly CORE1.Models.TallerEF2 _context;

        public UsuarioActivarModel(CORE1.Models.TallerEF2 context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(int id)

        {
            Usuario? usuario = await _context.Usuarios.Where(p => p.id == id).FirstOrDefaultAsync();
            if (usuario != null)
            {
                usuario.activo = "S";
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Usuarios");
        }
    }
}
