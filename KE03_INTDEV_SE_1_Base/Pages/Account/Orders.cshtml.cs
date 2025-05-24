using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KE03_INTDEV_SE_1.Pages.Account
{
    public class OrdersModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;

        public List<Order> Bestellingen { get; set; } = new();
        public string Gebruikersnaam { get; set; } = "";

        public OrdersModel(IOrderRepository orderRepository, ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        public void OnGet()
        {
            Gebruikersnaam = HttpContext.Session.GetString("Gebruikersnaam");

            if (!string.IsNullOrEmpty(Gebruikersnaam))
            {
                var customer = _customerRepository.GetCustomerByName(Gebruikersnaam);

                if (customer != null)
                {
                    Bestellingen = _orderRepository
                        .GetOrdersByCustomerId(customer.Id)
                        .OrderByDescending(o => o.OrderDate)
                        .ToList();
                }
            }
            else
            {
                // Redirect to login page if user is not logged in
                Response.Redirect("/Account/Login");
            }
        }
    }
}
