using FlightsManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models
{
    public static class AdminLayoutVM
    {
        public static int UsersCount()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            return db.ApplicationUser.Where(u => u.ReservationID == null).Count();
        }

        public static int RolesCount()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            return db.Roles.Count();
        }

        public static int FlightsCount()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            return db.Flight.Count();
        }

        public static int ReservationsCount()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            return db.Reservation.Count();
        }
    }
}
