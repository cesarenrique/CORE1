using CORE1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;


namespace CORE1.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly CORE1.Models.TallerEF2 _context;

        public LoginModel(CORE1.Models.TallerEF2 context)
        {
            _context = context;
        }
        public void OnGet(string returnURL = "/Index")
        {
            ViewData["ReturnURL"] = returnURL;
        }

        public async Task<IActionResult> OnPostAsync(string usu, string pwd, string returnURL = "/Index")
        {
            if (!ModelState.IsValid)
            {
                ViewData["error"] = "Invalid input.";
                return Page();
            }
            ViewData["ReturnURL"] = returnURL;
           
            int tipo = ValidateLogin(usu, pwd);
            if (tipo==0)
            {
                // Aquí se podría establecer la sesión del usuario
               

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme,ClaimTypes.Name,ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, usu));
                identity.AddClaim(new Claim(ClaimTypes.Name, usu));
                identity.AddClaim(new Claim(ClaimTypes.Role, "Usuario"));

                var principal = new ClaimsPrincipal(identity);
                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.Now.AddDays(1),
                    IsPersistent = true,
                    
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(principal), authProperties);

                if (Url.IsLocalUrl(returnURL))
                {
                    return RedirectToPage(returnURL);

                }
                else
                {
                    return Redirect("/Index");
                }
            }
            else
            {
                if(tipo==2)
                    ViewData["error"] = "User inactive.";
                else if(tipo==3)
                    ViewData["error"] = "Invalid  password.";
                else
                    ViewData["error"] = "Invalid  username.";
            }
            return Page();
        }

        private int ValidateLogin(string usu, string pwd)
        {
            
            int res= 1;

            if (!string.IsNullOrEmpty(usu) && !string.IsNullOrEmpty(pwd)) {
                Usuario? user = _context.Usuarios.Where(u => u.email == usu).FirstOrDefault();
               
                if (user != null && user.activo == "S")

                {
                    if (BCrypt.Net.BCrypt.Verify(pwd, user.password)) {
                        HttpContext.Session.SetString("usuario", user.email);
                        HttpContext.Session.SetString("nombreUsuario", user.nombre + " " + user.apellidos);
                        HttpContext.Session.SetString("rol", user.rol);
                        res = 0;
                    }
                    else
                    {
                        res = 3;
                    }
                }
                else if(user!=null && user.activo=="N"){ 

                    res = 2;
                }
            }
            return res;
        }
    }
}
