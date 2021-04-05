﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.UserViewModels
{
    public class EditUserViewModel
    {
        public string UserId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6,
            ErrorMessage = "Username cannot be shorter than 6 characters and longer than 50.")]
        public string Username { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10,
            ErrorMessage = "User PIN must be 10 characters long")]
        public string UserPIN { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10,
            ErrorMessage = "Telephone number must be 10 characters long")]
        public string TelephoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

       /* [Required]
        [StringLength(100, ErrorMessage = "Тhe password cannot be shorter than 6 characters and longer than 100.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }*/

        [Required]
        public string Roles { get; set; }

        public string RoleId { get; set; }
    }
}