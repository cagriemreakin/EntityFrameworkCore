// See https://aka.ms/new-console-template for more information
using CodeFirst;
using CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    _context.Employees.Add(new Employee { FirstName = "Emre", LastName = "Akın", Age = 30, Salary = 10 });
    _context.Managers.Add(new Manager { FirstName = "Ali", LastName = "Akın", Age = 30, Grade=5 });
    _context.SaveChanges();
}



