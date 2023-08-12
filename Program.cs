// See https://aka.ms/new-console-template for more information
using CodeFirst;
using CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var _context = new AppDbContext())
{
    var newProduct = new Product {
         Name="Pencil",
         Barcode="98374017123",
         Price=200,
         Stock=100
    };
    #region Observing entity state before and after adding 
    //detached
    Console.WriteLine($"State before add: {_context.Entry(newProduct).State}");

    await _context.AddAsync(newProduct);
    //added
    Console.WriteLine($"State add: {_context.Entry(newProduct).State}");

    //unchanged
    await _context.SaveChangesAsync();
    Console.WriteLine($"State save changes: {_context.Entry(newProduct).State}");

    #endregion



    #region Observing entity state before and after updating
    //unchanged
    var existingProduct = await _context.Products.FirstAsync();
    Console.WriteLine($"State before update: {_context.Entry(existingProduct).State}");
    existingProduct.Stock = 50;
    //modified
    Console.WriteLine($"State after changing value of stock: {_context.Entry(existingProduct).State}");

    //unchanged
    await _context.SaveChangesAsync();
    Console.WriteLine($"State save changes: {_context.Entry(existingProduct).State}");
    #endregion




    #region Observing entity state before and after delete
    //unchanged
    var product = await _context.Products.FirstAsync();
    Console.WriteLine($"State before delete: {_context.Entry(existingProduct).State}");
    //deleted
     _context.Remove(product);
    Console.WriteLine($"State after delete: {_context.Entry(existingProduct).State}");

    //detached removed from memory
    await _context.SaveChangesAsync();
    Console.WriteLine($"State save changes: {_context.Entry(existingProduct).State}");
    #endregion
    var products = await _context.Products.ToListAsync();
    products.ForEach(p => {

        var state = _context.Entry(p).State;
        Console.WriteLine($"Id: dotnet {p.Id}, Name: {p.Name}, Price: {p.Price}, Stock: {p.Stock}, State : {state}");
    });

}
