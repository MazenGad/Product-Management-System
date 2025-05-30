using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Product_Management_System.Entities
{
	public class Product
	{
		public int Id { get; set; }

		public string GeneratedCode { get; set; }

		public string Name { get; set; }

		public string Unit { get; set; }

		public decimal Price { get; set; }

		public int InitialQuantity { get; set; }

		public ICollection<ProductTransaction> Transactions { get; set; }
	}
}
