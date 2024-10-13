using Fix_Tune.Models;
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


        public FixTuneDbContext(DbContextOptions<FixTuneDbContext> opt) : base(opt) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "Mechanic", NormalizedName = "MECHANIC" },
                new { Id = "3", Name = "Customer", NormalizedName = "CUSTOMER" }
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
