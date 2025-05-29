using Product_Management_System.Data;
using Product_Management_System.DTOs.Transactions;
using Product_Management_System.Repository.Services.Interfaces;

namespace Product_Management_System.Repository.Services.Implementation
{
	public class TransactionRepository : ITransactionRepository
	{
		private readonly AppDbContext _context;
		public TransactionRepository(AppDbContext context)
		{
			_context = context;
		}
		public async Task<bool> CreateTransactionAsync(AddTransactionDto dto)
		{
			var product = await _context.Products.FindAsync(dto.ProductId);
			if (product == null)
			{
				return false;
			}
			if (dto.Quantity > product.InitialQuantity)
			{
				return false;
			}

			decimal totalPrice = dto.Quantity * product.Price;

			var transaction = new Entities.ProductTransaction
			{
				ProductId = dto.ProductId,
				Quantity = dto.Quantity,
				TotalPrice = totalPrice,
				TransactionDate = dto.Date ?? DateTime.Now
			};

			try
			{
				await _context.ProductTransactions.AddAsync(transaction);
				product.InitialQuantity -= dto.Quantity;
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}

		}
	}
}
