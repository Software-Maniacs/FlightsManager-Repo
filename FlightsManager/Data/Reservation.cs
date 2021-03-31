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
        public string ID { get; set; }

        public string FlightID { get; set; }

        public virtual Flight Flight { get; set; }

        public virtual ICollection<ApplicationUser> Passangers { get; set; }
    }
}