using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Flight
{
    public class FlightCreateVM
    {
        private DateTime takeOff = DateTime.Now;
        private DateTime landing = DateTime.Now;

        [Required]
        public string DestinationFrom { get; set; }

        [Required]
        public string DestinationTo { get; set; }

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
    }
}
