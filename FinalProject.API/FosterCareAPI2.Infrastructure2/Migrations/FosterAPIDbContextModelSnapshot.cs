﻿// <auto-generated />
using System;
using FosterCareAPI2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FosterCareAPI2.Infrastructure2.Migrations
{
    [DbContext(typeof(FosterAPIDbContext))]
    partial class FosterAPIDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("FosterCareAPI2.Core.Models.Child", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Dob");

                    b.Property<int?>("HouseId");

                    b.Property<int?>("HouseTempId");

                    b.Property<string>("MoveInDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("Children");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Dob = "01/01/01",
                            HouseTempId = 1,
                            MoveInDate = "08/08/08",
                            Name = "Ashton"
                        },
                        new
                        {
                            Id = 2,
                            Dob = "01/01/96",
                            HouseTempId = 1,
                            MoveInDate = "09/09/09",
                            Name = "Dylan"
                        },
                        new
                        {
                            Id = 3,
                            Dob = "01/01/05",
                            HouseTempId = 1,
                            MoveInDate = "02/02/12",
                            Name = "Lilly"
                        },
                        new
                        {
                            Id = 4,
                            Dob = "01/01/12",
                            HouseTempId = 1,
                            MoveInDate = "03/03/13",
                            Name = "Mariah"
                        });
                });

            modelBuilder.Entity("FosterCareAPI2.Core.Models.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Home");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Lubbock",
                            Name = "Keslin"
                        });
                });

            modelBuilder.Entity("FosterCareAPI2.Core.Models.Child", b =>
                {
                    b.HasOne("FosterCareAPI2.Core.Models.House", "House")
                        .WithMany("Children")
                        .HasForeignKey("HouseId");
                });
#pragma warning restore 612, 618
        }
    }
}
