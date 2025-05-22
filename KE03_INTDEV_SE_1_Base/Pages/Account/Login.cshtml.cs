using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KE03_INTDEV_SE_1.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string GebruikersNaam { get; set; }

        [BindProperty]
        public string Wachtwoord { get; set; }

        private readonly ICustomerRepository _customerRepository;

        public LoginModel(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public Customer Customer { get; set; }

        public IActionResult OnPost()
        {
            // Simpele controle (vervang met je eigen gebruikersvalidatie)  
            Customer customer = _customerRepository.GetCustomerByName(GebruikersNaam);
            if (customer == null)
            {
                ModelState.AddModelError("GebruikersNaam", "Geen gebruiker gevonden met deze gebruikersnaam.");
                return Page();
            }
            // Succesvolle login
            HttpContext.Session.SetString("Gebruikersnaam", GebruikersNaam);
            TempData["Melding"] = "Je bent succesvol ingelogd!";
            return RedirectToPage("/Index");
        }
    }
}
