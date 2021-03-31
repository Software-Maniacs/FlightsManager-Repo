using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string UserPIN { get; set; }

        public string Address { get; set; }

        public string Nationality { get; set; }

        public string TicketType { get; set; }

        public string ReservationID { get; set; }

        public virtual Reservation Reservation { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {MiddleName} {LastName} {UserPIN} {Email} {PhoneNumber}";
        }
    }
}