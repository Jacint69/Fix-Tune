﻿// <auto-generated />
using System;
using Fix_Tune.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fix_Tune.Repository.Migrations
{
    [DbContext(typeof(FixTuneDbContext))]
    partial class FixTuneDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Fix_Tune.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CarId"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("EngineDisplacement")
                        .HasColumnType("double");

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TypeOfFuel")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            CarId = 1,
                            Brand = "VW",
                            EngineDisplacement = 1.8999999999999999,
                            PlateNumber = "ABB-222",
                            Status = false,
                            Type = "Golf 4",
                            TypeOfFuel = 1,
                            UserId = "admin",
                            Year = 2002
                        },
                        new
                        {
                            CarId = 2,
                            Brand = "Ford",
                            EngineDisplacement = 1.6000000000000001,
                            PlateNumber = "CDE-333",
                            Status = true,
                            Type = "Focus",
                            TypeOfFuel = 0,
                            UserId = "mechanic",
                            Year = 2008
                        },
                        new
                        {
                            CarId = 3,
                            Brand = "BMW",
                            EngineDisplacement = 2.0,
                            PlateNumber = "FGH-444",
                            Status = false,
                            Type = "3 Series",
                            TypeOfFuel = 1,
                            UserId = "customer",
                            Year = 2015
                        },
                        new
                        {
                            CarId = 4,
                            Brand = "Audi",
                            EngineDisplacement = 1.8,
                            PlateNumber = "HIJ-555",
                            Status = true,
                            Type = "A4",
                            TypeOfFuel = 0,
                            UserId = "admin",
                            Year = 2010
                        },
                        new
                        {
                            CarId = 5,
                            Brand = "Mercedes",
                            EngineDisplacement = 2.1000000000000001,
                            PlateNumber = "JKL-666",
                            Status = false,
                            Type = "C-Class",
                            TypeOfFuel = 1,
                            UserId = "mechanic",
                            Year = 2017
                        },
                        new
                        {
                            CarId = 6,
                            Brand = "Toyota",
                            EngineDisplacement = 1.6000000000000001,
                            PlateNumber = "MNO-777",
                            Status = true,
                            Type = "Corolla",
                            TypeOfFuel = 0,
                            UserId = "customer",
                            Year = 2020
                        },
                        new
                        {
                            CarId = 7,
                            Brand = "Honda",
                            EngineDisplacement = 1.6000000000000001,
                            PlateNumber = "PQR-888",
                            Status = false,
                            Type = "Civic",
                            TypeOfFuel = 1,
                            UserId = "admin",
                            Year = 2012
                        },
                        new
                        {
                            CarId = 8,
                            Brand = "Opel",
                            EngineDisplacement = 1.3999999999999999,
                            PlateNumber = "STU-999",
                            Status = true,
                            Type = "Astra",
                            TypeOfFuel = 0,
                            UserId = "mechanic",
                            Year = 2013
                        },
                        new
                        {
                            CarId = 9,
                            Brand = "Mazda",
                            EngineDisplacement = 2.2000000000000002,
                            PlateNumber = "VWX-111",
                            Status = false,
                            Type = "6",
                            TypeOfFuel = 1,
                            UserId = "customer",
                            Year = 2014
                        },
                        new
                        {
                            CarId = 10,
                            Brand = "Skoda",
                            EngineDisplacement = 1.6000000000000001,
                            PlateNumber = "YZA-222",
                            Status = true,
                            Type = "Octavia",
                            TypeOfFuel = 0,
                            UserId = "admin",
                            Year = 2009
                        },
                        new
                        {
                            CarId = 11,
                            Brand = "Nissan",
                            EngineDisplacement = 1.5,
                            PlateNumber = "BCD-333",
                            Status = false,
                            Type = "Qashqai",
                            TypeOfFuel = 1,
                            UserId = "mechanic",
                            Year = 2016
                        },
                        new
                        {
                            CarId = 12,
                            Brand = "Kia",
                            EngineDisplacement = 1.6000000000000001,
                            PlateNumber = "EFG-444",
                            Status = true,
                            Type = "Sportage",
                            TypeOfFuel = 0,
                            UserId = "customer",
                            Year = 2021
                        });
                });

            modelBuilder.Entity("Fix_Tune.Models.CarIssue", b =>
                {
                    b.Property<int>("CarIssueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CarIssueId"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("IssueId")
                        .HasColumnType("int");

                    b.HasKey("CarIssueId");

                    b.HasIndex("CarId");

                    b.HasIndex("IssueId");

                    b.ToTable("CarIssues");
                });

            modelBuilder.Entity("Fix_Tune.Models.Issue", b =>
                {
                    b.Property<int>("IssueID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IssueID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IssueID");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("Fix_Tune.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateOfRegistration")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "admin",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "be96f9ac-e233-4eda-bde7-30c52d55e15f",
                            DateOfRegistration = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "kovacs.jacint02@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Kovács",
                            LastName = "Jácint",
                            LockoutEnabled = false,
                            NormalizedUserName = "Jaco",
                            PasswordHash = "AQAAAAIAAYagAAAAEFYv5+jlEBHXVD5oPPlGBXDyGpzTO8m5b0qcH/9CjG6FJl2CxdQm7qyOOQeIO/MsMA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "10e97100-14f4-4da7-832e-b1a356fce4df",
                            TwoFactorEnabled = false,
                            UserName = "Jaco"
                        },
                        new
                        {
                            Id = "mechanic",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7b6cddbf-f31e-44ca-b46c-481b1aa2a2f7",
                            DateOfRegistration = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mechanic@mechanic.com",
                            EmailConfirmed = false,
                            FirstName = "Kovács",
                            LastName = "Jácint",
                            LockoutEnabled = false,
                            NormalizedUserName = "MECHANIC",
                            PasswordHash = "AQAAAAIAAYagAAAAEAL+uSzepAzyGD/OQPPqmB47f3J6bQu+UYgyyTob4KedFNhYr/15jfzvQVFLxTrubw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "75923553-bead-4683-8ac4-dc444cd759f3",
                            TwoFactorEnabled = false,
                            UserName = "mechanic"
                        },
                        new
                        {
                            Id = "customer",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "198a2980-87e0-42f8-95f0-e6652501d245",
                            DateOfRegistration = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "customer@customer.com",
                            EmailConfirmed = false,
                            FirstName = "Kovács",
                            LastName = "Jácint",
                            LockoutEnabled = false,
                            NormalizedUserName = "CUSTOMER",
                            PasswordHash = "AQAAAAIAAYagAAAAEAmwmqb9Q7WtXTJUAsZpOha0dKIWoWYnJIayUFRpHsLJ6/hJigiFd6hf25MYOnDWwA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "52a78ecc-0581-4605-a038-cb7660a50228",
                            TwoFactorEnabled = false,
                            UserName = "customer"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2",
                            Name = "Mechanic",
                            NormalizedName = "MECHANIC"
                        },
                        new
                        {
                            Id = "3",
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Fix_Tune.Models.Car", b =>
                {
                    b.HasOne("Fix_Tune.Models.User", "User")
                        .WithMany("Cars")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Fix_Tune.Models.CarIssue", b =>
                {
                    b.HasOne("Fix_Tune.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fix_Tune.Models.Issue", "Issue")
                        .WithMany()
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Issue");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Fix_Tune.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Fix_Tune.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fix_Tune.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Fix_Tune.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fix_Tune.Models.User", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
