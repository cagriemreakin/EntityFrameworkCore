// See https://aka.ms/new-console-template for more information
using CodeFirst;
using CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    try
    {
        int id = 5;
        var rawSql = await _context.Products.FromSqlRaw("select * from Products where id={0}", id).ToListAsync();

        var interpolatedSql = await _context.Products.FromSqlInterpolated($"select * from Products where id={id}").ToListAsync();



    }
    catch (Exception ex)
    {

    }
}



