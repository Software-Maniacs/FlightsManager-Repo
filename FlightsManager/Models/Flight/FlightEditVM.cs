using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FlightsManager.Data;

namespace FlightsManager.Models.Flight
{
    public class FlightEditVM
    {
        public string AirplaneID { get; set; }

        [Required]
        public string DestinationFrom { get; set; }

        [Required]
        public string DestinationTo { get; set; }

        [Required]
        public DateTime TakesOff { get; set; }

        [Required]
        public DateTime Landing { get; set; }

        [Required]
        public string AirplaneType { get; set; }

        [Required]
        public string PilotName { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int BusinessClassCapacity { get; set; }

        public virtual ICollection<FlightsManager.Data.Reservation> Reservations { get; set; }
    }
}
