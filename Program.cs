// See https://aka.ms/new-console-template for more information
using System;
using CodeFirst;
using CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    var category = _context.Categories.First(x=>x.Name=="Pencils");

    //Product -> Parent
    //ProductFeature -> Child

    // we can add parent independently
    var product = new Product {
        Name = "ruler",
        Price = 10,
        Stock = 10,
        Barcode = "1" ,
        CategoryId=category.Id,
        ProductFeature=new ProductFeature {
            Width=1,
            Height=5
        }
    };
    _context.Products.Add(product);

    //child-> parent
    var product2 = new Product
    {
        Name = "ruler",
        Price = 10,
        Stock = 10,
        Barcode = "1",
        CategoryId = category.Id,

    };
    var productFeature = new ProductFeature
    {
        Width = 1,
        Height = 5,
        Product =product2
    };

    _context.ProductFeatures.Add(productFeature);


    
    _context.SaveChanges();



}



 