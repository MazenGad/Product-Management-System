using Microsoft.AspNetCore.Mvc;
using Product_Management_System.Data;
using Product_Management_System.DTOs.Product;
using Product_Management_System.Repository.Services.Interfaces;

namespace Product_Management_System.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
		private readonly IProductRepository _productRepository;

		public ProductController(AppDbContext context , IProductRepository productRepository)
		{
			_context = context;
			_productRepository = productRepository;
		}
		[HttpGet]
		public IActionResult Create()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] AddProductDto productDto)
		{
			if (ModelState.IsValid)
			{
				var result = await _productRepository.CreateProductAsync(productDto);
				if (result)
				{
					return Json(new { success = true, message = "Product added successfully!" });
				}
				return Json(new { success = false, message = "Failed to create product. Please try again." });
			}

			return Json(new { success = false, message = "Invalid data submitted." });
		}

		[HttpGet]
		public async Task<IActionResult> GetProduct(int id)
		{
			var product = await _productRepository.GetProductByIdAsync(id);
			if (product == null)
				return NotFound();

			return Json(product);
		}


	}
}
