using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Reservation
{
    /// <summary>
    /// The viewmodel for the Reservation Detail page.
    /// </summary>
    public class ReservationDetailVM
    {
        /// <summary>
        /// All reservations.
        /// </summary>
        public List<ReservationVM> Items { get; set; }
    }
}
