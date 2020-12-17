using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge_5_Repository;
using Challenge_6_Repository;

namespace Challenge_8_Repository {
    public class Driver : Customer {
        public Vehicle Type { get; set; }
        public bool VehicleTypDiscount { get; set; } 
        public int Points { get; set; } = 5;
        public int MonthsWithoutInfraction { get; set; }
    }
}
