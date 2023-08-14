using System;
namespace CodeFirst.DAL
{
	public class Product
	{
		public int Id { get; set; }
		public string?  Name { get; set; }
		public decimal Price { get; set; }
		public int Stock { get; set; }
		public string? Barcode { get; set; }

		//ForeignKey Shadow property
		public int CategoryId { get; set; }

		//Navigation Property
		public Category? Category { get; set; }

		public ProductFeature ?ProductFeature { get; set; }
	}
}

