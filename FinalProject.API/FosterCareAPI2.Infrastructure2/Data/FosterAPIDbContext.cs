using FosterCareAPI2.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FosterCareAPI2.Infrastructure.Data
{
    public class FosterAPIDbContext : DbContext
    {
        public DbSet<Child> Children { get; set; }
        public DbSet<House> Home { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<House>().HasData(
                new House { Id = 1, Name = "Keslin", City = "Lubbock" });

            modelBuilder.Entity<Child>().HasData(
                 new Child { Id = 1, Name = "Ashton", Dob = "2001-01-01", MoveInDate = "2008-08-08", HouseId = 1 },
                 new Child { Id = 2, Name = "Dylan", Dob = "2001-01-01", MoveInDate = "2009-09-09", HouseId = 1 },
                 new Child { Id = 3, Name = "Lilly", Dob = "2001-01-01", MoveInDate = "2002-02-12", HouseId = 1 },
                 new Child { Id = 4, Name = "Mariah", Dob = "2001-01-01", MoveInDate = "2003-03-13", HouseId = 1 });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("DataSource=../FosterCareAPI2.Infrastructure2/Children.db");
        }
    }
}