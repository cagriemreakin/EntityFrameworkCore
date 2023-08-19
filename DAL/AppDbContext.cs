using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CodeFirst.DAL
{
	public class AppDbContext:DbContext
	{


        public DbSet<BasePerson> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
               
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TPT
            modelBuilder.Entity<BasePerson>().ToTable("Persons");
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Manager>().ToTable("Managers");

            base.OnModelCreating(modelBuilder);
        }

    }
}

