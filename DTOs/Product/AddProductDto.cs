using System.ComponentModel.DataAnnotations;

namespace Product_Management_System.DTOs.Product
{
	public class AddProductDto
	{
		[Required(ErrorMessage = "Product name is required.")]
		[StringLength(100, MinimumLength = 2, ErrorMessage = "Product name must be at least 2 characters.")]
		[RegularExpression(@"^[a-zA-Z\u0621-\u064A][a-zA-Z\u0621-\u064A0-9\s\-]*$", ErrorMessage = "Name must start with a letter and contain only letters, digits, spaces, or hyphens.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Unit is required.")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Unit must be at least 2 characters.")]
		[RegularExpression(@"^[a-zA-Z\u0621-\u064A][a-zA-Z\u0621-\u064A0-9\s\-]*$", ErrorMessage = "Unit must start with a letter and contain only letters, digits, spaces, or hyphens.")]
		public string Unit { get; set; }

		[Required]
		[Range(1, double.MaxValue, ErrorMessage = "Price must be at least 1.")]
		public decimal Price { get; set; }

		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "Initial quantity must be at least 1.")]
		public int InitialQuantity { get; set; }
	}
}
