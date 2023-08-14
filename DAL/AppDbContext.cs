using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CodeFirst.DAL
{
	public class AppDbContext:DbContext
	{
		public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
               
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.Id);




            // EF Core version >= 5 creates cross table for the tables which have many to many relationship with each other.

            // if we want to create cross table using ef core convention, we need to define it on model creating


            modelBuilder.Entity<Student>().HasMany(x => x.Teachers)
                                          .WithMany(x => x.Students)
                                          .UsingEntity<Dictionary<string, object>>(
                                             "StudentTeacherCrossTable",
                                             x => x.HasOne<Teacher>().WithMany().HasForeignKey("Teacher_Id").HasConstraintName("FK__TeacherId"),
                                             x=> x.HasOne<Student>().WithMany().HasForeignKey("Student_Id").HasConstraintName("FK__StudentId")) ;

            base.OnModelCreating(modelBuilder);
        }

    }
}

