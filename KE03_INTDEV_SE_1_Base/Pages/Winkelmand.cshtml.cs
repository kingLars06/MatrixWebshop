using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using DataAccessLayer.Repositories;

namespace KE03_INTDEV_SE_1.Pages
{
    public class CartItem
    {
        public int id { get; set; }
        public int quantity { get; set; }
    }

    public class WinkelmandModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;


        public IList<Product> Product { get; set; }
        public Customer Customer { get; set; }

        public WinkelmandModel(IProductRepository productRepository, ICustomerRepository customerRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
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

        [BindProperty]
        public string CartData { get; set; }
        public List<CartItem> WinkelmandItems { get; set; } = new();

        public IActionResult OnPost()
        {
            // haal de gebruiker op uit de sessie en database
            var gebruikersnaam = HttpContext.Session.GetString("Gebruikersnaam");
            if (string.IsNullOrEmpty(gebruikersnaam))
            {
                return RedirectToPage("/Login");
            }
            Customer = _customerRepository.GetCustomerByName(gebruikersnaam);


            // Haal de winkelmandgegevens op uit de sessie
            Console.WriteLine(CartData);

            if (!string.IsNullOrEmpty(CartData))
            {
                try
                {
                    WinkelmandItems = JsonSerializer.Deserialize<List<CartItem>>(CartData);
                }
                catch (JsonException ex)
                {
                    // Foutafhandeling
                    Console.WriteLine("JSON Fout: " + ex.Message);
                }
            }
            
            // WinkelmandItems gebruiken
            Order order = new Order
            {
                OrderDate = DateTime.Now,
                CustomerId = Customer.Id,
                Customer = Customer,

            };

            foreach (var item in WinkelmandItems)
            {
                var product = _productRepository.GetProductById(item.id);
                if (product != null)
                {
                    order.Products.Add(product);
                    // Hier kun je eventueel extra logica toevoegen, zoals het bijhouden van de hoeveelheid
                }
            }
            // Sla de bestelling op in de database

            _orderRepository.AddOrder(order);


            return RedirectToPage("/Bedankt");
        }

    }
}
