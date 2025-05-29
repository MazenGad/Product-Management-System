using System.ComponentModel.DataAnnotations;

namespace Product_Management_System.DTOs.Product
{
	public class AddProductDto
	{

		[Required]
		public string Name { get; set; }

		[Required]
		public string Unit { get; set; }

		[Required]
		public decimal Price { get; set; }

		[Required]
		public int InitialQuantity { get; set; }
	}
}
