using Product_Management_System.DTOs.Transactions;

namespace Product_Management_System.Repository.Services.Interfaces
{
	public interface ITransactionRepository
	{
		Task<bool> CreateTransactionAsync(AddTransactionDto dto);
		Task<ICollection<GetTransactionDto>> GetTransactionsAsync(DateTime? date);
	}
}
