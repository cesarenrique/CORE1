using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CORE1.Pages.Account
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
            HttpContext.Session.Clear();
            HttpContext.SignOutAsync();
            Redirect("/Index");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync();
            return Redirect("/Index");
        }
    }
}
