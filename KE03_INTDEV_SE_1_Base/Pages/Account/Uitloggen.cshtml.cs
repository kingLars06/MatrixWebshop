using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KE03_INTDEV_SE_1.Pages.Account
{
    public class UitloggenModel : PageModel
    {
        public IActionResult OnGet()
        {
            // Verwijder sessie
            HttpContext.Session.Remove("Gebruikersnaam");
            // Laat een melding zien
            TempData["Melding"] = "Je bent uitgelogd.";

            // Ga terug naar de vorige pagina
            var referer = Request.Headers["Referer"].ToString();

            // Als we een geldige vorige pagina hebben, redirect daarheen
            if (!string.IsNullOrEmpty(referer))
            {
                return Redirect(referer);
            }

            // Anders gewoon terug naar home
            return RedirectToPage("/Index");
        }
    }
}
