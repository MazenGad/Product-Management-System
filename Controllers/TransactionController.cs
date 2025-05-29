using Microsoft.AspNetCore.Mvc;
using Product_Management_System.Data;
using Product_Management_System.DTOs.Transactions;
using Product_Management_System.Entities;
using Product_Management_System.Repository.Services.Interfaces;

namespace Product_Management_System.Controllers
{
    public class TransactionController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ITransactionRepository _transactionRepository;
		private readonly IProductRepository _productRepository;
		public TransactionController(AppDbContext context , ITransactionRepository transactionRepository , IProductRepository productRepository)
		{
			_transactionRepository = transactionRepository;
			_productRepository = productRepository;
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			ViewBag.Products = await _productRepository.GetProductsAsync();
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] AddTransactionDto transactionDto)
		{
			Console.WriteLine($"Date Received: {transactionDto.Date}");

			if (!ModelState.IsValid)
			{
				return Json(new { success = false, message = "Invalid data submitted." });
			}
			var result = await _transactionRepository.CreateTransactionAsync(transactionDto);
			if (result)
			{
				return Json(new { success = true, message = "Transaction added successfully!" });
			}
			return Json(new {
				success = false,
				message = "Failed to create transaction. Please try again.",
			});

		}

	}
}
