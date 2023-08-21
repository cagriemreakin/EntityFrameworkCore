using Microsoft.EntityFrameworkCore;
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
            modelBuilder.Entity<User>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }

    }
}

