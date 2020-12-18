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
        public bool VehicleTypDiscount {
            get {
                if (Type.TypeOfVehicle == Vehicle.VehicleType.Van || Type.TypeOfVehicle == Vehicle.VehicleType.Sedan)
                    return true;
                else return false;
            }
        }
        public double Points {
            get {
                double discount = 0;
                if (VehicleTypDiscount) discount = 1;


                return 5 + RecentInfractions.Count / 10 - (MonthsWithoutInfraction / 6) - discount;
            }
        }
        public List<Infractions> RecentInfractions { get; set; } = new List<Infractions>() { new Infractions(InfractionType.LaneViolation, new DateTime(2020, 10, 10)) };
        public double MonthsWithoutInfraction { get { return ((DateTime.Now - DateOfLastInfraction).TotalDays)/30; } }
        public double Premium { get { return Points * 100; } }
        public DateTime DateOfLastInfraction {
            get {
                if (RecentInfractions.Last().DateOfInfraction != null)
                    return RecentInfractions.Last().DateOfInfraction;
                else return DateTime.Now;
            }
        } // need to add InitialDateOfService as property and add as default
        public int CustomerID { get; set; }
        public Driver() { }

        public Driver(Vehicle type, CustomerStatus statusOfCustomer, string firstName, string lastName, string phoneNumber, string email)
            : base(statusOfCustomer, firstName, lastName, phoneNumber, email) {
            Type = type;

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




