using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Reservation
{
    public class PassangerCountVM
    {
        private int passangerCount = 1;
        public int PassangerCount 
        {
            get
            {
                return this.passangerCount;
            }
            set
            {
                if(passangerCount > 0)
                {
                    this.passangerCount = value;
                }
            }
        }
    }
}
