using FlightsManager.Data;
using FlightsManager.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Reservation
{
    public class ReservationIndexVM
    {
        public PagerVM Pager { get; set; }
        public List<ReservationIndexDetailVM> Items { get; set; }
    }
}
