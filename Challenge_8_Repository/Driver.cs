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
        public double Points { get { return 5 + Infractions.Count - (MonthsWithoutInfraction / 6); } }
        // - ( if (VehicleTypDiscount) { 1} else { 0})
        public List<Infractions> Infractions { get; set; }
        public double MonthsWithoutInfraction { get { return (DateTime.Now - DateOfLastInfraction).TotalDays; } }
        public double Premium { get { return Points * 100; } }
        public DateTime DateOfLastInfraction { get; set; }
        public int CustomerID { get; set; }
        public Driver() { }
        public Driver(Vehicle type, bool vehicleTypeDiscount, int points,
            CustomerStatus statusOfCustomer, string firstName, string lastName, string phoneNumber, string email)
            : base(statusOfCustomer, lastName, phoneNumber, email, firstName) {
            Type = type;
            VehicleTypDiscount = vehicleTypeDiscount;




        }
    }

    public enum InfractionType { // error without enum being public??
        Speeding = 1,
        RollingStop,
        LaneViolation,
        Tailgaiting
    }
    public class Infractions {
        public InfractionType TypeOfInfraction { get; set; }
        public DateTime DateOfInfraction { get; set; }

        public Infractions(InfractionType typeOfInfraction, DateTime dateOfInfraction) {
            TypeOfInfraction = typeOfInfraction;
            DateOfInfraction = dateOfInfraction;
        }
    }
}




