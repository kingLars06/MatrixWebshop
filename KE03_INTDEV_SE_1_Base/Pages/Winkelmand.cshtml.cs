using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace KE03_INTDEV_SE_1.Pages
{
    public class WinkelmandModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;

        public IList<Product> Product { get; set; }
        public Customer Customer { get; set; }

        public WinkelmandModel(IProductRepository productRepository, ICustomerRepository customerRepository)
        {
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }
        
        public void OnGet()
        {
            var gebruikersnaam = HttpContext.Session.GetString("Gebruikersnaam");

            Product = _productRepository.GetAllProducts().ToList();
            if (gebruikersnaam != null)
            {
                Customer = _customerRepository.GetCustomerByName(gebruikersnaam);
               
            }
        }

    }
}
