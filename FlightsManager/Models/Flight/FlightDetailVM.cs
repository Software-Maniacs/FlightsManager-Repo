using FlightsManager.Models.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Flight
{
    /// <summary>
    /// The viewmodel through which we can see all of the flight's reservations.
    /// </summary>
    public class FlightDetailVM
    {
        /// <summary>
        /// The collection of all reservations of the flight.
        /// </summary>
        public List<ReservationDetailVM> Items { get; set; }
    }
}
