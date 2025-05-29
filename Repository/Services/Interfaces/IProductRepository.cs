using Product_Management_System.DTOs.Product;
using Product_Management_System.Entities;

namespace Product_Management_System.Repository.Services.Interfaces
{
	public interface IProductRepository
	{
		public Task<bool> CreateProductAsync(AddProductDto product);
	}
}
