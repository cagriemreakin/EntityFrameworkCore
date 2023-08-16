// See https://aka.ms/new-console-template for more information
using CodeFirst;
using CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    //eager loading
    var categorWithProdcut = _context.Categories.Include(x=>x.Products).ThenInclude(x=>x.ProductFeature).First();

    categorWithProdcut.Products.ForEach(x =>

    Console.WriteLine(x.Name, x.ProductFeature.Id, x.ProductFeature.Height, x.ProductFeature.Width)
    );



}



