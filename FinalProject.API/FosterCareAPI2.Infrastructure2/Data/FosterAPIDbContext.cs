using System;
using System.Collections.Generic;
using FosterCareAPI2.Core.Models;
using Microsoft.EntityFrameworkCore;


namespace FosterCareAPI2.Infrastructure.Data
{
    public class FosterAPIDbContext : DbContext
    {
        public DbSet<Child> Children { get; set; }

        public DbSet<ChildHome> ChildHomes { get; set; }

        public DbSet<House> Home { get; set; }

        //public DbSet<Appointment> Appts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChildHome>()
        .HasKey(bc => new { bc.ChildId, bc.HouseId });
            modelBuilder.Entity<ChildHome>()
                .HasOne(bc => bc.Child)
                .WithMany(b => b.ChildHomes)
                .HasForeignKey(bc => bc.ChildId);
            modelBuilder.Entity<ChildHome>()
                .HasOne(bc => bc.House)
                .WithMany(c => c.ChildHomes)
                .HasForeignKey(bc => bc.HouseId);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Child>().HasData(
                 new Child { Id = 1, Name = "Ashton", Dob = "01/01/01", MoveInDate = "08/08/08" },
                 new Child { Id = 2, Name = "Dylan", Dob = "01/01/96", MoveInDate = "09/09/09" },
                 new Child { Id = 3, Name = "Lilly", Dob = "01/01/05", MoveInDate = "02/02/12" },
                 new Child { Id = 4, Name = "Mariah", Dob = "01/01/12", MoveInDate = "03/03/13" });

            //modelBuilder.Entity<Appointment>().HasData(
            //   new Appointment { Id = 1, Type = "Medical", DrName = "Vuelvas" });

            modelBuilder.Entity<House>().HasData(
                new House { Id = 1, Name = "Keslin", City = "Lubbock" });

            modelBuilder.Entity<ChildHome>().HasData(
               new ChildHome {ChildId= 1, HouseId=1});
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("DataSource=../FosterCareAPI2.Infrastructure2/Children.db");
        }
    }
}
