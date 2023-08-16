// See https://aka.ms/new-console-template for more information
using CodeFirst;
using CodeFirst.DAL;

Initializer.Build();

using (var _context = new AppDbContext())
{
    var category = new Category { Name = "Pencil", Products = new List<Product> {
        new Product{Name="Rotring", Price=500, Stock=100, Barcode="qwewq", Kdv=1},
        new Product{Name="Faber", Price=500, Stock=100, Barcode="qwewq2",Kdv=2},
    }
    };
    _context.Add(category);
    _context.SaveChanges();
}



