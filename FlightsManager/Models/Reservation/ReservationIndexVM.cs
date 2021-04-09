using FlightsManager.Data;
using FlightsManager.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Reservation
{
    /// <summary>
    /// Viewmodel for the Index Reservation page.
    /// </summary>
    public class ReservationIndexVM
    {
        /// <summary>
        /// Pager for the Reservation page.
        /// </summary>
        public PagerVM Pager { get; set; }
        /// <summary>
        /// Collection of all reservations.
        /// </summary>
        public List<ReservationIndexDetailVM> Items { get; set; }
    }
}
