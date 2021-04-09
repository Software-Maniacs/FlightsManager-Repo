using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Reservation
{
    /// <summary>
    /// Viewmodel for the passenger count of a reservation.
    /// </summary>
    public class PassangerCountVM
    {
        /// <summary>
        /// The passenger count.
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Cannot be zero.")]
        public int PassangerCount { get; set; }
    }
}
