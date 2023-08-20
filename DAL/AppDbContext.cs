using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CodeFirst.DAL
{
	public class AppDbContext:DbContext
	{


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
               
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Owned entity definition
            modelBuilder.Entity<Manager>().OwnsOne(x => x.Person, p => {
                p.Property(x => x.FirstName).HasColumnName("FirstName");
                p.Property(x => x.LastName).HasColumnName("LastName");
                p.Property(x => x.Age).HasColumnName("Age");


            });
            modelBuilder.Entity<Employee>().OwnsOne(x => x.Person, p =>
            {
                p.Property(x => x.FirstName).HasColumnName("FirstName");
                p.Property(x => x.LastName).HasColumnName("LastName");
                p.Property(x => x.Age).HasColumnName("Age");


            });

            base.OnModelCreating(modelBuilder);
        }

    }
}

