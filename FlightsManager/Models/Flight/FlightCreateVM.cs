using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Flight
{
    public class FlightCreateVM
    {
        private DateTime takeOff = DateTime.Now;
        private DateTime landing = DateTime.Now;

        public string DestinationFrom { get; set; }

        public string DestinationTo { get; set; }

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

        public string AirplaneType { get; set; }

        public string PilotName { get; set; }

        public int Capacity { get; set; }

        public int BusinessClassCapacity { get; set; }
    }
}
