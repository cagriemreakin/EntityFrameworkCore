using System;
namespace CodeFirst.DAL
{
	public class Teacher
	{
        public int Id { get; set; }
        public string Name { get; set; }

        //NAvigation Property
        public List<Student> Students { get; set; } = new List<Student>();
    }
}

