using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Reservation
{
    public class ReservationVM
    {
        //public string ID { get; set; }
        public string Flight { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string PIN { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string TicketType { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {MiddleName} {LastName} {Nationality} {PIN} {TelephoneNumber} {Email} {TicketType}";
        }
    }
}
