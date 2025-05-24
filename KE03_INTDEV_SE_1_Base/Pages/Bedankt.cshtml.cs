using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KE03_INTDEV_SE_1.Pages
{
    public class BedanktModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;

        public List<Order> Orders { get; set; }

        public BedanktModel(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void OnGet()
        {
            Orders = _orderRepository.GetAllOrders().ToList();
            Console.WriteLine(Orders[3].Products[1]);
        }
    }
}
