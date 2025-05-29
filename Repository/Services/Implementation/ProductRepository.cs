using Microsoft.EntityFrameworkCore;
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
				return false;
			}


		}

		public async Task<GetProductDto> GetProductByIdAsync(int id)
		{
			try
			{
				return await _context.Products
					.Where(p => p.Id == id)
					.Select(p => new GetProductDto
					{
						Id = p.Id,
						Name = p.Name,
						Price = p.Price,
						Unit = p.Unit,
						InitialQuantity = p.InitialQuantity
					})
					.FirstOrDefaultAsync();
			}
			catch (Exception ex)
			{
				return null;
			}

		}

		public async Task<ICollection<GetProductDto>> GetProductsAsync()
		{
			try
			{
				return 
					await _context.Products
					.Select(p => new GetProductDto
					{
						Id = p.Id,
						Name = p.Name,
						Price = p.Price,
						Unit = p.Unit,
						InitialQuantity = p.InitialQuantity
					})
					.ToListAsync();
			}
			catch (Exception ex)
			{
				return new List<GetProductDto>();
			}
		}
	}
}
