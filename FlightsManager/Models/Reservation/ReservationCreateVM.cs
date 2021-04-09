using FlightsManager.Data;
using FlightsManager.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Reservation
{
    /// <summary>
    /// The viewmodel through which a reservation is created.
    /// </summary>
    public class ReservationCreateVM
    {
        /// <summary>
        /// Collection of all reservations that will be made.
        /// </summary>
        public ReservationVM[] Reservations { get; set; }
        /// <summary>
        /// The passenger count of the reservation.
        /// </summary>
        public int PassangerCount { get; set; }
        /// <summary>
        /// The list of flights.
        /// </summary>
        public List<Data.Flight> Flights { get; set; }
        
        /// <summary>
        /// The flight for which the reservation is being made.
        /// </summary>
        public string Flight { get; set; }
        /// <summary>
        /// The email of the person making the reservation.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        /// <summary>
        /// Bool through which the person's checked if he has done a reservation already on the website.
        /// </summary>
        public bool IsFirstTime { get; set; }
        /// <summary>
        /// A message of the person making the reservation.
        /// </summary>
        public string Message { get; set; }
    }
}
