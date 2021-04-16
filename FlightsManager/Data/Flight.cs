using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Data
{
    /// <summary>
    /// This class is used for each flight.
    /// </summary>
    public class Flight
    {
        /// <summary>
        /// The ID of the airplane that will be flown.
        /// </summary>
        public string AirplaneID { get; set; }
        
        /// <summary>
        /// The destination from which the airplane takes off.
        /// </summary>
        public string DestinationFrom { get; set; }

        /// <summary>
        /// The destination in which the airplane lands.
        /// </summary>
        public string DestinationTo { get; set; }

        /// <summary>
        /// The date and time of the take off.
        /// </summary>
        public DateTime TakesOff { get; set; }

        /// <summary>
        /// The expected date and time of the landing.
        /// </summary>
        public DateTime Landing { get; set; }

        /// <summary>
        /// The type of the airplane.
        /// </summary>
        public string AirplaneType { get; set; }

        /// <summary>
        /// The name of the main pilot that will operate the plane.
        /// </summary>
        public string PilotName { get; set; }

        /// <summary>
        /// The number of ordinary seats that the airplane has.
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// The number of business class seats that the airplane has.
        /// </summary>
        public int BusinessClassCapacity { get; set; }

        /// <summary>
        /// A collection of all reservations for the flight.
        /// </summary>
        public virtual ICollection<Reservation> Reservations { get; set; }

        /// <summary>
        /// Returns a short info about the destinations that the airplanes takes off and lands in.
        /// </summary>
        /// <returns>The city from which the airplane takes off and the city where it is supposed to land.</returns>
        public override string ToString()
        {
            return this.DestinationFrom + " - " + this.DestinationTo;
        }
    }
}