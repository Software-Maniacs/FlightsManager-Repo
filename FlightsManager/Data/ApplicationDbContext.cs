using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {

        }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }

        public virtual DbSet<Flight> Flight { get; set; }

        public virtual DbSet<Reservation> Reservation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                .HasKey(f => new { f.AirplaneID });

            modelBuilder.Entity<Reservation>()
                 .HasKey(r => new { r.ID});

            modelBuilder.Entity<Reservation>()
                 .HasOne(r => r.Flight)
                 .WithMany(f => f.Reservations)
                 .HasForeignKey(rf => rf.FlightID)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservation>()
                .HasMany(r => r.Passangers)
                .WithOne(p => p.Reservation)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);

            /*base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<ApplicationUserLogin<string>>();
            modelBuilder.Ignore<ApplicationUserRole<string>>();
            modelBuilder.Ignore<ApplicationUserClaim<string>>();
            modelBuilder.Ignore<ApplicationUserToken<string>>();
            modelBuilder.Ignore<ApplicationUser<string>>();
            modelBuilder.Ignore<ApplicationUser>();*/

            //}
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FlightsMDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
