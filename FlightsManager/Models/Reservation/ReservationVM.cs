using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Reservation
{
    /// <summary>
    /// A viewmodel for each reservation.
    /// </summary>
    public class ReservationVM
    {
        //public string ID { get; set; }
        /// <summary>
        /// The flight to which the reservation belongs to.
        /// </summary>
        public string Flight { get; set; }
        /// <summary>
        /// The first name of the passenger.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The middle name of the passenger.
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// The last name of the passenger.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The nationality of the passenger.
        /// </summary>
        public string Nationality { get; set; }
        /// <summary>
        /// The PIN of the passenger.
        /// </summary>
        public string PIN { get; set; }
        /// <summary>
        /// The email of the passenger.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// The telephone number of the passenger.
        /// </summary>
        public string TelephoneNumber { get; set; }
        /// <summary>
        /// The type of the passenger's ticket.
        /// </summary>
        public string TicketType { get; set; }

        /// <summary>
        /// Method that returns all the information about the reservation.
        /// </summary>
        /// <returns>Returns all the information in a string format.</returns>
        public override string ToString()
        {
            return $"{FirstName} {MiddleName} {LastName} {Nationality} {PIN} {TelephoneNumber} {Email} {TicketType}";
        }
    }
}
