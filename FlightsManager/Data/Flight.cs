using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Data
{
    public class Flight
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

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
