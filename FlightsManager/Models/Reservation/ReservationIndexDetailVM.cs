using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Reservation
{
    /// <summary>
    /// A viewmodel for the Index page for ReservationDetail.
    /// </summary>
    public class ReservationIndexDetailVM
    {
        /// <summary>
        /// ID of the reservation.
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// The flight that the reservation belongs to.
        /// </summary>
        public string Flight { get; set; }
        /// <summary>
        /// The amount of passengers in the reservation.
        /// </summary>
        public int PassangerCount { get; set; }
        /// <summary>
        /// Is the reservation confirmed or not.
        /// </summary>
        public bool IsConfirm { get; set; }
    }
}
