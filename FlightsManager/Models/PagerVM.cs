using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Base
{
    /// <summary>
    /// The viewmodel of each pager.
    /// </summary>
    public class PagerVM
    {
        /// <summary>
        /// The number of the current page.
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// The number of all pages.
        /// </summary>
        public int PagesCount { get; set; }
    }
}
