using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

namespace CodeFirst.DAL
{
	public class AppDbContext:DbContext
	{


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductFull> ProductFulls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
               
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.Id);
            modelBuilder.Entity<ProductFull>().HasNoKey();

            //Index
            modelBuilder.Entity<Product>().HasIndex(x => x.Name).IncludeProperties(x => new { x.Price, x.Stock });

            //composite index
            modelBuilder.Entity<Product>().HasIndex(x => new { x.Name, x.Url });

            //check constraint
            modelBuilder.Entity<Product>().HasCheckConstraint("PriceDiscountChek", "[Price]>[DiscountPrice]");

            //not mapped
            modelBuilder.Entity<Product>().Ignore(x => x.Barcode);

            //save as varchar
            modelBuilder.Entity<Product>().Property(x => x.Name).IsUnicode(false);

            modelBuilder.Entity<Product>().Property(x => x.Url).HasColumnType("varchar(500)").HasColumnName("Url");
            base.OnModelCreating(modelBuilder);
        }

    }
}

