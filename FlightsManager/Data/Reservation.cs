using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Data
{
    public class Reservation
    {
        [ForeignKey("FlightID")]
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public string Nationality { get; set; }

        public string TicketType { get; set; }

        [ForeignKey("FlightID")]
        public string FlightID { get; set; }

        public virtual Flight Flight { get; set; }
    }
}
