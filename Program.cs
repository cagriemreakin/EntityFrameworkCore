// See https://aka.ms/new-console-template for more information
using CodeFirst;
using CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    try
    {
        //join
        var result = (from c in _context.Categories
                      join p in _context.Products on c.Id equals p.CategoryId
                      select new {p}
                      ).ToListAsync();

        //left join
        var leftJoin = await (from c in _context.Categories
                      join pl in _context.Products on c.Id equals pl.CategoryId into plist

                      from pl in plist.DefaultIfEmpty()
                      select new {c, pl }
                ).ToListAsync();
        //right join
        var rightJoin = await (from pl in _context.Products
                              join c in _context.Categories on pl.CategoryId equals c.Id into plist

                              from c in plist.DefaultIfEmpty()
                              select new { c, pl }
                ).ToListAsync();

        //full outer join
        var fullOurterJoin = leftJoin.Union(rightJoin);


    }
    catch (Exception ex)
    {

    }
}



