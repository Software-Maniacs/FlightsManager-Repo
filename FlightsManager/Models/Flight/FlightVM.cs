using FlightsManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Flight
{
    /// <summary>
    /// Viewmodel for each flight.
    /// </summary>
    public class FlightVM
    {
        /// <summary>
        /// The ID of the airplane.
        /// </summary>
        public string AirplaneID { get; set; }

        /// <summary>
        /// The city from which the airplane takes off.
        /// </summary>
        public string DestinationFrom { get; set; }

        /// <summary>
        /// The city where the airplane has to land.
        /// </summary>
        public string DestinationTo { get; set; }

        /// <summary>
        /// The time when the plane is supposed to take off.
        /// </summary>
        public DateTime TakesOff { get; set; }

        /// <summary>
        /// The time when the plane is supposed to land.
        /// </summary>
        public DateTime Landing { get; set; }

        /// <summary>
        /// The type of the airplane.
        /// </summary>
        public string AirplaneType { get; set; }

        /// <summary>
        /// The name of the main pilot of this flight.
        /// </summary>
        public string PilotName { get; set; }

        /// <summary>
        /// The number of ordinary seats.
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// The number of business class seats.
        /// </summary>
        public int BusinessClassCapacity { get; set; }

        /// <summary>
        /// A collection of all the flight's reservations.
        /// </summary>
        public virtual ICollection<FlightsManager.Data.Reservation> Reservations { get; set; }

        /// <summary>
        /// The duration of the flight.
        /// </summary>
        public TimeSpan ContiniusFlight { get; set; }
    }
}
