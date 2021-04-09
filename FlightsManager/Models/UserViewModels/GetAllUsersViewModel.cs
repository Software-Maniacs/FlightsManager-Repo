using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.UserViewModels
{
    /// <summary>
    /// The viewmodel through which all users can be listed.
    /// </summary>
    public class GetAllUsersViewModel
    {
        /// <summary>
        /// The ID of the user.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The user's username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The user's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The user's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The user's email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The user's PIN.
        /// </summary>
        public string UserPIN { get; set; }

        /// <summary>
        /// The user's telephone number.
        /// </summary>
        public string TelephoneNumber { get; set; }

        /// <summary>
        /// The user's address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The users' roles.
        /// </summary>
        public IEnumerable<string> Roles { get; set; }

        /// <summary>
        /// The role's id.
        /// </summary>
        public string RoleId { get; set; }
    }
}
