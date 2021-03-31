using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Base
{
    public class PagerVM
    {
        public int CurrentPage { get; set; }
        public int PagesCount { get; set; }
    }
}
