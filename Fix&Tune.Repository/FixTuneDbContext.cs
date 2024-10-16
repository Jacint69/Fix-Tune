using Fix_Tune.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fix_Tune.Repository
{
    public class FixTuneDbContext : IdentityDbContext<User>
    {

        public DbSet<Car> Cars { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<CarIssue> CarIssues {  get; set; }
        public virtual DbSet<User> Users {  get; set; }

        private  IConfiguration _configuration;

        public FixTuneDbContext(DbContextOptions<FixTuneDbContext> opt) : base(opt) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "Mechanic", NormalizedName = "MECHANIC" },
                new { Id = "3", Name = "Customer", NormalizedName = "CUSTOMER" }
                );

            //Create password hasher
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

            //Load appsettings_develop json
            var confbuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings_develop.json", optional: false, reloadOnChange: true);
            _configuration= confbuilder.Build();


            //Admin user
            User admin = new User()
            {
                Id = "admin",
                Email = _configuration["UserSettings:Email"],
                UserName = _configuration["UserSettings:UserName"],
                FirstName="Kovács",
                LastName="Jácint",
                NormalizedUserName = _configuration["UserSettings:NormalizedUserName"],
                
            };
            User mechanic = new User()
            {
                Id = "mechanic",
                Email = "mechanic@mechanic.com",
                UserName = "mechanic",
                FirstName = "Kovács",
                LastName = "Jácint",
                NormalizedUserName = "MECHANIC",

            };

            User customer = new User()
            {
                Id = "customer",
                Email = "customer@customer.com",
                UserName = "customer",
                FirstName = "Kovács",
                LastName = "Jácint",
                NormalizedUserName = "CUSTOMER",

            };


            admin.PasswordHash = passwordHasher.HashPassword(admin, _configuration["UserSettings:Password"]);
            mechanic.PasswordHash = passwordHasher.HashPassword(admin, _configuration["UserSettings:Password"]);
            customer.PasswordHash = passwordHasher.HashPassword(admin, _configuration["UserSettings:Password"]);

            builder.Entity<User>().HasData(admin);
            builder.Entity<User>().HasData(mechanic);
            builder.Entity<User>().HasData(customer);

            builder.Entity<Car>().HasData(
                                     new Car
                                     {
                                         CarId = 1,
                                         Brand = "VW",
                                         Type = "Golf 4",
                                         UserId = "admin",
                                         Issues = new List<Issue>(),
                                         Year = 2002,
                                         PlateNumber = "ABB-222",
                                         TypeOfFuel = TypeOfFuel.Diesel,
                                         EngineDisplacement = 1.9,
                                         Status = false
                                     },
                                     new Car
                                     {
                                         CarId = 2,
                                         Brand = "Ford",
                                         Type = "Focus",
                                         UserId = "mechanic",
                                         Issues = new List<Issue>(),
                                         Year = 2008,
                                         PlateNumber = "CDE-333",
                                         TypeOfFuel = TypeOfFuel.Petrol,
                                         EngineDisplacement = 1.6,
                                         Status = true
                                     },
                                     new Car
                                     {
                                         CarId = 3,
                                         Brand = "BMW",
                                         Type = "3 Series",
                                         UserId = "customer",
                                         Issues = new List<Issue>(),
                                         Year = 2015,
                                         PlateNumber = "FGH-444",
                                         TypeOfFuel = TypeOfFuel.Diesel,
                                         EngineDisplacement = 2.0,
                                         Status = false
                                     },
                                     new Car
                                     {
                                         CarId = 4,
                                         Brand = "Audi",
                                         Type = "A4",
                                         UserId = "admin",
                                         Issues = new List<Issue>(),
                                         Year = 2010,
                                         PlateNumber = "HIJ-555",
                                         TypeOfFuel = TypeOfFuel.Petrol,
                                         EngineDisplacement = 1.8,
                                         Status = true
                                     },
                                     new Car
                                     {
                                         CarId = 5,
                                         Brand = "Mercedes",
                                         Type = "C-Class",
                                         UserId = "mechanic",
                                         Issues = new List<Issue>(),
                                         Year = 2017,
                                         PlateNumber = "JKL-666",
                                         TypeOfFuel = TypeOfFuel.Diesel,
                                         EngineDisplacement = 2.1,
                                         Status = false
                                     },
                                     new Car
                                     {
                                         CarId = 6,
                                         Brand = "Toyota",
                                         Type = "Corolla",
                                         UserId = "customer",
                                         Issues = new List<Issue>(),
                                         Year = 2020,
                                         PlateNumber = "MNO-777",
                                         TypeOfFuel = TypeOfFuel.Petrol,
                                         EngineDisplacement = 1.6,
                                         Status = true
                                     },
                                     new Car
                                     {
                                         CarId = 7,
                                         Brand = "Honda",
                                         Type = "Civic",
                                         UserId = "admin",
                                         Issues = new List<Issue>(),
                                         Year = 2012,
                                         PlateNumber = "PQR-888",
                                         TypeOfFuel = TypeOfFuel.Diesel,
                                         EngineDisplacement = 1.6,
                                         Status = false
                                     },
                                     new Car
                                     {
                                         CarId = 8,
                                         Brand = "Opel",
                                         Type = "Astra",
                                         UserId = "mechanic",
                                         Issues = new List<Issue>(),
                                         Year = 2013,
                                         PlateNumber = "STU-999",
                                         TypeOfFuel = TypeOfFuel.Petrol,
                                         EngineDisplacement = 1.4,
                                         Status = true
                                     },
                                     new Car
                                     {
                                         CarId = 9,
                                         Brand = "Mazda",
                                         Type = "6",
                                         UserId = "customer",
                                         Issues = new List<Issue>(),
                                         Year = 2014,
                                         PlateNumber = "VWX-111",
                                         TypeOfFuel = TypeOfFuel.Diesel,
                                         EngineDisplacement = 2.2,
                                         Status = false
                                     },
                                     new Car
                                     {
                                         CarId = 10,
                                         Brand = "Skoda",
                                         Type = "Octavia",
                                         UserId = "admin",
                                         Issues = new List<Issue>(),
                                         Year = 2009,
                                         PlateNumber = "YZA-222",
                                         TypeOfFuel = TypeOfFuel.Petrol,
                                         EngineDisplacement = 1.6,
                                         Status = true
                                     },
                                     new Car
                                     {
                                         CarId = 11,
                                         Brand = "Nissan",
                                         Type = "Qashqai",
                                         UserId = "mechanic",
                                         Issues = new List<Issue>(),
                                         Year = 2016,
                                         PlateNumber = "BCD-333",
                                         TypeOfFuel = TypeOfFuel.Diesel,
                                         EngineDisplacement = 1.5,
                                         Status = false
                                     },
                                     new Car
                                     {
                                         CarId = 12,
                                         Brand = "Kia",
                                         Type = "Sportage",
                                         UserId = "customer",
                                         Issues = new List<Issue>(),
                                         Year = 2021,
                                         PlateNumber = "EFG-444",
                                         TypeOfFuel = TypeOfFuel.Petrol,
                                         EngineDisplacement = 1.6,
                                         Status = true
                                     }
                                 );



            //Cars <--> Issue N:N CarIssue 
            builder.Entity<Issue>()
                .HasMany(x => x.Cars)
                .WithMany(x => x.Issues)
                .UsingEntity<CarIssue>(
                    x => x
                        .HasOne(y => y.Car)
                        .WithMany()
                        .HasForeignKey(x => x.CarId)
                        .OnDelete(DeleteBehavior.Cascade),
                   x => x
                        .HasOne(y => y.Issue)
                        .WithMany()
                        .HasForeignKey(x => x.IssueId)
                        .OnDelete(DeleteBehavior.Cascade)
                        );

            //Cars <--> User N:1
            builder.Entity<Car>()
                .HasOne(x=>x.User)
                .WithMany(x=> x.Cars)
                .HasForeignKey(x=>x.UserId);


        }
    }
}
