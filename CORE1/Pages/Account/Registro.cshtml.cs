using CORE1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CORE1.Pages.Account
{
    public class RegistroModel : PageModel
    {
        private readonly CORE1.Models.TallerEF2 _context;

        public RegistroModel(CORE1.Models.TallerEF2 context)
        {
            _context = context;
        }
        public void OnGet(string returnURL = "/Index")
        {
            ViewData["ReturnURL"] = returnURL;
        }

        [BindProperty]
        public Usuario Usuario { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Usuarios == null || Usuario == null)
            {
                return Page();
            }
            if (Usuario != null && ValidateRegistro(Usuario.email))
            {
                // Aquí se podría establecer la sesión del usuario
                Usuario.fechaalta = DateTime.Now;
                Usuario.rol = "CLIENTE";
                Usuario.activo = "N";
                string hash = BCrypt.Net.BCrypt.HashPassword(Usuario.password);
                Usuario.password = hash;
                _context.Usuarios.Add(Usuario);
                await _context.SaveChangesAsync();
                return Redirect("/Account/Login");
            }
            else
            {
                ViewData["error2"] = "Invalid username";
            }
            return Page();
        }

        private bool ValidateRegistro(string usu)
        {

            bool res = true;

            if (!string.IsNullOrEmpty(usu) )
            {
                Usuario? user = _context.Usuarios.Where(u => u.activo == "S" && u.email == usu).FirstOrDefault();
                
                if(user==null) return true;

                return false;
                

            }
            return res;
        }
    }
}
