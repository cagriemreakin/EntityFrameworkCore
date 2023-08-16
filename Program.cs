// See https://aka.ms/new-console-template for more information
using CodeFirst;
using CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    //explicit loading
    //sonradan ihtiyaç duyulacak navigation property'e ulaşmayı sağlar
    var category = _context.Categories.First();


    //some codes here. maybe business code
    //
    //
    //
    //Now I need products. To get product of a category I need to use explicit loading using navigation property -> product

    //we need use collection for one to many relationships
    await _context.Entry(category).Collection(x => x.Products).LoadAsync();

    //For one to one relationships we need to use reference
    var product = _context.Products.First();
    await _context.Entry(product).Reference(x => x.ProductFeature).LoadAsync();


}



