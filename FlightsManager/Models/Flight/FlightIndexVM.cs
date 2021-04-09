using FlightsManager.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Flight
{
    /// <summary>
    /// The viewmodel of the Flight Index.
    /// </summary>
    public class FlightIndexVM
    {
        /// <summary>
        /// The pager of Index.
        /// </summary>
        public PagerVM Pager { get; set; }

        /// <summary>
        /// All of the flights.
        /// </summary>
        public ICollection<FlightVM> Items { get; set; }
    }
}
