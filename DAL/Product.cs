using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.DAL
{
	public class Product
	{
		public int Id { get; set; }
		public string?  Name { get; set; }
        [Precision(18, 2)]

        public decimal Price { get; set; }
        [Precision(18, 2)]

        public decimal DiscountPrice { get; set; }

        public int Stock { get; set; }

		public string Url { get; set; }
		public string? Barcode { get; set; }

		public int Kdv { get; set; }

		//this property is computed from SqlServer automatically.
		//See AppDbContext OnModelCreating
		[Precision(18,2)]
		public decimal PriceKdv { get; set; }

		//ForeignKey Shadow property
		public int CategoryId { get; set; }

		//Navigation Property
		public  Category? Category { get; set; }

		public  ProductFeature? ProductFeature { get; set; }
	}
}

