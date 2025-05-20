using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using KE03_INTDEV_SE_1_Base.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KE03_INTDEV_SE_1.Pages
{
    public class ProductenModel : PageModel
    {
        private readonly ILogger<ProductenModel> _logger;
        private readonly IProductRepository _productRepository;

        public IList<Product> Product { get; set; }

        public ProductenModel(ILogger<ProductenModel> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            Product = new List<Product>();
        }

        public void OnGet()
        {
            Product = _productRepository.GetAllProducts().ToList();
            _logger.LogInformation($"getting all {Product.Count} Product");
        }

    }
}
