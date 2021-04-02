﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Reservation
{
    public class PassangerCountVM
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Cannot be zero.")]
        public int PassangerCount { get; set; }
    }
}
