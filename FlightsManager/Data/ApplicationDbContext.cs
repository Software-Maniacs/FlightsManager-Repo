using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsManager.Data
{
    /// <summary>
    /// The database context that the database of FlightsManager uses.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        /// <summary>
        /// The default constructor through which the database context can be initialized.
        /// </summary>
        public ApplicationDbContext()
        {

        }

        /// <summary>
        /// Constructor through which you can pass options to the context when you initialize it.
        /// </summary>
        /// <param name="options">The context options themselves.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        /// <summary>
        /// A table for all the users.
        /// </summary>
        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }

        /// <summary>
        /// A table for all the flights.
        /// </summary>
        public virtual DbSet<Flight> Flight { get; set; }

        /// <summary>
        /// A table for all the reservations.
        /// </summary>
        public virtual DbSet<Reservation> Reservation { get; set; }

        /// <summary>
        /// Method that configures the schema needed for the framework.
        /// </summary>
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

        }

        /// <summary>
        /// Method that configures the server where the database will be stored.
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FlightsMDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
