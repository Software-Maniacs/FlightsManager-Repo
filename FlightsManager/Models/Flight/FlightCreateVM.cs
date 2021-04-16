using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Flight
{
    /// <summary>
    /// The viewmodel through which a flight is created.
    /// </summary>
    public class FlightCreateVM
    {
        private DateTime takeOff = DateTime.Now;
        private DateTime landing = DateTime.Now;

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
        public DateTime TakesOff 
        {
            get
            {
                return this.takeOff;
            }
            set
            {
                this.takeOff = value;
            }
        }

        /// <summary>
        /// The time when the plane is supposed to land.
        /// </summary>
        [Required]
        public DateTime Landing 
        {
            get
            {
                return this.landing;
            }
            set
            {
                if(value < this.TakesOff)
                {
                    throw new Exception();
                }
                else
                {
                    this.landing = value;
                }
            }
        }


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
    }
}
