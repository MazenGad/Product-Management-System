namespace Product_Management_System.DTOs.Product
{
	public class GetProductDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string Unit { get; set; }

		public int InitialQuantity { get; set; }

	}
}
