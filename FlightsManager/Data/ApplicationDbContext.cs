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
                 .HasKey(rf => new { rf.FlightID, rf.UserId });

            modelBuilder.Entity<Reservation>()
                 .HasOne(rf => rf.Flight)
                 .WithMany(r => r.Reservations)
                 .HasForeignKey(rf => rf.FlightID);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.ApplicationUser)
                .WithOne(u => u.Reservation)
                .HasForeignKey<Reservation>(r => r.UserId);

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
    }
}
