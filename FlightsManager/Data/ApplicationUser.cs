using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Data
{
    /// <summary>
    /// Implementation of a default user.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// The first name of the user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The middle name of the user.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// The last name of the user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The user's PIN.
        /// </summary>
        public string UserPIN { get; set; }

        /// <summary>
        /// The address where the user lives.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The nationality of the user.
        /// </summary>
        public string Nationality { get; set; }

        /// <summary>
        /// The type of the user's ticket.
        /// </summary>
        public string TicketType { get; set; }

        /// <summary>
        /// The ID of the user's reservation.
        /// </summary>
        public string ReservationID { get; set; }

        /// <summary>
        /// The user's reservation.
        /// </summary>
        public virtual Reservation Reservation { get; set; }

        /// <summary>
        /// Method that returns all the info about the user in a string format.
        /// </summary>
        /// <returns>String that contains all the info about the user.</returns>
        public override string ToString()
        {
            return $"{this.FirstName} {MiddleName} {LastName} {UserPIN} {Email} {PhoneNumber}";
        }
    }
}