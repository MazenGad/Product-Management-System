using System.ComponentModel.DataAnnotations;

namespace Product_Management_System.Entities
{
	public class Product
	{
		public int Id { get; set; }

		[Required]
		public string GeneratedCode {get;set;}

		[Required]
		public string Name { get; set; }

		[Required]
		public string Unit { get; set; }

		[Required]
		public decimal Price { get; set; }

		[Required]
		public int InitialQuantity { get; set; }

		public ICollection<ProductTransaction> Transactions { get; set; }

	}
}
