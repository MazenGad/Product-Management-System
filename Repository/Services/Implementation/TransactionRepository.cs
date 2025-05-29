using Microsoft.EntityFrameworkCore;
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

		public async Task<ICollection<GetTransactionDto>> GetTransactionsAsync(DateTime? date)
		{
			var query = _context.ProductTransactions
				.Include(pt => pt.Product)
				.AsQueryable();

			if (date.HasValue)
			{
				query = query.Where(pt => pt.TransactionDate.Date == date.Value.Date);

			}

			var transactions = await query.Select(pt => new GetTransactionDto
				{
					ProductName = pt.Product.Name,
					Quantity = pt.Quantity,
					Unit = pt.Product.Unit,
					TotalPrice = pt.TotalPrice,
					Date = pt.TransactionDate
				})
				.ToListAsync();
			return transactions;
		}
	}
}
