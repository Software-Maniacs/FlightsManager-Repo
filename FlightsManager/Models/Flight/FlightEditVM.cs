using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FlightsManager.Data;

namespace FlightsManager.Models.Flight
{
    /// <summary>
    /// The viewmodel through which a flight is edited.
    /// </summary>
    public class FlightEditVM
    {
        /// <summary>
        /// The ID of the airplane.
        /// </summary>
        public string AirplaneID { get; set; }

        /// <summary>
        /// The city from which the airplane takes off.
        /// </summary>
        [Required]
        public string DestinationFrom { get; set; }

        /// <summary>
        /// The city where the airplane has to land.
        /// </summary>
        [Required]
        public string DestinationTo { get; set; }

        /// <summary>
        /// The time when the plane is supposed to take off.
        /// </summary>
        [Required]
        public DateTime TakesOff { get; set; }

        /// <summary>
        /// The time when the plane is supposed to land.
        /// </summary>
        [Required]
        public DateTime Landing { get; set; }

        /// <summary>
        /// The type of the airplane.
        /// </summary>
        [Required]
        public string AirplaneType { get; set; }

        /// <summary>
        /// The name of the main pilot of this flight.
        /// </summary>
        [Required]
        public string PilotName { get; set; }

        /// <summary>
        /// The number of ordinary seats.
        /// </summary>
        [Required]
        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }

        /// <summary>
        /// The number of business class seats.
        /// </summary>
        [Required]
        [Range(0, int.MaxValue)]
        public int BusinessClassCapacity { get; set; }

        /// <summary>
        /// A collection of all the flight's reservations.
        /// </summary>
        public virtual ICollection<FlightsManager.Data.Reservation> Reservations { get; set; }

        public bool IsFirstTime { get; set; }

        public string Message { get; set; }
    }
}
