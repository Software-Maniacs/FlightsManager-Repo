using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models
{
    /// <summary>
    /// Viewmodel for the user roles.
    /// </summary>
    public class UserRolesViewModel
    {
        /// <summary>
        /// The ID of the role.
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// The name of the role.
        /// </summary>
        public string RoleName { get; set; }
    }
}
