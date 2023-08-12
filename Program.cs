// See https://aka.ms/new-console-template for more information
using System;
using CodeFirst;
using CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    //AsNoTracking
    var products = await _context.Products.AsNoTracking().ToListAsync();
    products.ForEach(p => {

        var state = _context.Entry(p).State;
        Console.WriteLine($"Id: dotnet {p.Id}, Name: {p.Name}, Price: {p.Price}, Stock: {p.Stock}, State : {state}");
    });



    #region ChangeTracker it allows us to acces objects tracked by ef core.But we use AsNoTracking.

    _context.ChangeTracker.Entries().ToList().ForEach(e =>
    {
        if(e.Entity is Product product)
        {
            product.Stock = 500;
        }
    });

    #endregion


    #region Using ChangeTracker property 
    //to set common property CreatedDate of Product object for newly added objects
    //we will override SaveChanges for this
    _context.Products.Add(new Product { Name = "eraser", Price = 10, Stock = 10, Barcode = "1" });
    _context.Products.Add(new Product { Name = "book", Price = 10, Stock = 10, Barcode = "2" });
    _context.Products.Add(new Product { Name = "ruler", Price = 10, Stock = 10, Barcode = "3" });
    _context.SaveChanges();

    #endregion

}



