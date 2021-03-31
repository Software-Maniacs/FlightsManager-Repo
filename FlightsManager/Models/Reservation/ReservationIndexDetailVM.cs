using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Reservation
{
    public class ReservationIndexDetailVM
    {
        public string ID { get; set; }
        public string Flight { get; set; }
        public int PassangerCount { get; set; }
        public bool IsConfirm { get; set; }
    }
}
