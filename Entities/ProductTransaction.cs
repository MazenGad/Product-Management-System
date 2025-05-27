using System.ComponentModel.DataAnnotations;

namespace Product_Management_System.Entities
{
	public class ProductTransaction
	{
		public int Id { get; set; }

		[Required]
		public int ProductId { get; set; }

		public Product Product { get; set; }

		public DateTime TransactionDate { get; set; } = DateTime.Now;

		[Required]
		public int Quantity { get; set; }

		[Required]
		public decimal TotalPrice { get; set; }
	}
}
