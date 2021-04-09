using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Data
{
    /// <summary>
    /// This class is used for each reservation the unassigned user creates.
    /// </summary>
    public class Reservation 
    {
        /// <summary>
        /// The ID of the said reservation.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// The ID of the flight for which the reservation is made.
        /// </summary>
        public string FlightID { get; set; }

        /// <summary>
        /// The flight for which the reservation is made.
        /// </summary>
        public virtual Flight Flight { get; set; }

        /// <summary>
        /// The collection of passengers that are in the reservation.
        /// </summary>
        public virtual ICollection<ApplicationUser> Passangers { get; set; }
    }
}