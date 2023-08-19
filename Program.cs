// See https://aka.ms/new-console-template for more information
using CodeFirst;
using CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    //lazy loading
    var category = _context.Categories.First();
    //lazy loading stars here. It makes second query to access products of category;
    var products = category.Products;


}



