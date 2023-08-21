// See https://aka.ms/new-console-template for more information
using CodeFirst;
using CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    try
    {

        //var category = new Category { Name = "Pencils" };
        //_context.Categories.Add(category);

        //category.Products.Add(new Product { Name = "Rotring", Price = 100, Kdv = 10, PriceKdv = 20, Barcode = "sad", Stock = 200, ProductFeature = new ProductFeature { Height = 10, Width = 2 } });
        //category.Products.Add(new Product { Name = "Rotring2", Price = 100, Kdv = 10, PriceKdv = 20, Barcode = "sad", Stock = 200, ProductFeature = new ProductFeature { Height = 10, Width = 2 } });
        //category.Products.Add(new Product { Name = "Rotring3", Price = 100, Kdv = 10, PriceKdv = 20, Barcode = "sad", Stock = 200, ProductFeature = new ProductFeature { Height = 10, Width = 2 } });

        //_context.SaveChanges();
        // 1th. 
        var productFull = _context.ProductFulls.FromSqlRaw(@"SELECT p.Id as Product_Id, c.Name as CategoryName,p.Name,p.Price,pf.Width from Products p JOIN
ProductFeatures pf on p.Id =pf.Id
JOIN Categories c on c.Id = p.CategoryId").ToList();


    }
    catch (Exception ex)
    {

    }
}



