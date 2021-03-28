using FlightsManager.Data;
using FlightsManager.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Reservation
{
    public class ReservationCreateVM
    {
        public ReservationVM[] Reservations { get; set; }
        public int PassangerCount { get; set; }
        public List<Data.Flight> Flights { get; set; }
        public string Flight { get; set; }
    }
}
