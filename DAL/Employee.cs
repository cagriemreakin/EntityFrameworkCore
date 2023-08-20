using Microsoft.EntityFrameworkCore;

namespace CodeFirst.DAL
{
	public class Employee
	{
		public int Id { get; set; }
		public Person Person { get; set; }
		[Precision(18,2)]
		public decimal Salary { get; set; }


	}
}

