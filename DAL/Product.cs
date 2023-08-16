using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.DAL
{
	public class Product
	{
		public int Id { get; set; }
		public string?  Name { get; set; }
		public decimal Price { get; set; }
		public int Stock { get; set; }
		public string? Barcode { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTime? CreatedDate { get; set; } = DateTime.Now;

		public int Kdv { get; set; }

		//this property is computed from SqlServer automatically.
		//See AppDbContext OnModelCreating
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public decimal PriceKdv { get; set; }

		//ForeignKey Shadow property
		public int CategoryId { get; set; }

		//Navigation Property
		public Category? Category { get; set; }

		public ProductFeature? ProductFeature { get; set; }
	}
}

