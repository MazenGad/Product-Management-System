using System.ComponentModel.DataAnnotations;

namespace Product_Management_System.DTOs.Transactions
{
	public class AddTransactionDto
	{
		[Required]
		public int ProductId { get; set; }

		[Required]
		public int Quantity { get; set; }

		public DateTime? Date { get; set; }
	}
}
