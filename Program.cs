// See https://aka.ms/new-console-template for more information
using System;
using CodeFirst;
using CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    var category = new Category { Name = "Pencils" };

     
    //Using Product Entity To add entity 
    _context.Products.Add(new Product { Name = "rotring", Price = 10, Stock = 10, Barcode = "1" ,Category=category});


    // using Category to add products. We dont have to give category entity to product. 
    var product = new Product { Name = "ruler", Price = 10, Stock = 10, Barcode = "1" };
    category.Products.Add(product);

    //using categoryId

    var categoryEntity = _context.Categories.First(x=>x.Name == "Pencils");

    var product2 = new Product { Name = "faber castel", Price = 10, Stock = 10, Barcode = "1",CategoryId= categoryEntity.Id };
    _context.Products.Add(product2);
    _context.SaveChanges();



}



