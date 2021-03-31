using FlightsManager.Models.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Flight
{
    public class FlightDetailVM
    {
        public List<ReservationDetailVM> Items { get; set; }
    }
}
