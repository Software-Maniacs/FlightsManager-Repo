using FlightsManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Flight
{
    public class FlightVM
    {
        public string AirplaneID { get; set; }

        public string DestinationFrom { get; set; }

        public string DestinationTo { get; set; }

        public DateTime TakesOff { get; set; }

        public DateTime Landing { get; set; }

        public string AirplaneType { get; set; }

        public string PilotName { get; set; }

        public int Capacity { get; set; }

        public int BusinessClassCapacity { get; set; }

        public virtual ICollection<FlightsManager.Data.Reservation> Reservations { get; set; }

        public TimeSpan ContiniusFlight { get; set; }
    }
}
