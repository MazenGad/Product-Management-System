using System.ComponentModel.DataAnnotations;

namespace Product_Management_System.DTOs.Transactions
{
	public class AddTransactionDto
	{
		[Required]
		public int ProductId { get; set; }

		[Required]
		[Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative number.")]
		public int Quantity { get; set; }


		public DateTime? Date { get; set; }
	}
}
