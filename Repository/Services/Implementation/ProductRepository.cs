using Product_Management_System.Data;
using Product_Management_System.DTOs.Product;
using Product_Management_System.Entities;
using Product_Management_System.Repository.Services.Interfaces;

namespace Product_Management_System.Repository.Services.Implementation
{
	public class ProductRepository : IProductRepository
	{
		private readonly AppDbContext _context;
		public ProductRepository(AppDbContext context)
		{
			_context = context;
		}
		public async Task<bool> CreateProductAsync(AddProductDto productDto)
		{
			try
			{
				var product = new Product
				{
					Name = productDto.Name,
					Unit = productDto.Unit,
					Price = productDto.Price,
					InitialQuantity = productDto.InitialQuantity,
					GeneratedCode = $"PR-{Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper()}"
				};
				_context.Products.Add(product);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				// Log the exception (ex) as needed
				return false;
			}


		}
	}
}
