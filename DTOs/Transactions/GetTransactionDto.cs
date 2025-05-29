namespace Product_Management_System.DTOs.Transactions
{
	public class GetTransactionDto
	{
		public string ProductName { get; set; }

		public int Quantity { get; set; }

		public string Unit { get; set; }

		public decimal TotalPrice { get; set; }

		public DateTime Date { get; set; }

	}
}
