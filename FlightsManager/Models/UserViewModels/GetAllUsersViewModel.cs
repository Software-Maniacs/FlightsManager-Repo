using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.UserViewModels
{
    public class GetAllUsersViewModel
    {
        public string UserId { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserPIN { get; set; }

        public string TelephoneNumber { get; set; }

        public string Address { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public string RoleId { get; set; }
    }
}
