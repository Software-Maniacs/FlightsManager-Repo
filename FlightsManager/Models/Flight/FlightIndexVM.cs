using FlightsManager.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Flight
{
    public class FlightIndexVM
    {
        public PagerVM Pager { get; set; }
        public ICollection<FlightVM> Items { get; set; }
    }
}
