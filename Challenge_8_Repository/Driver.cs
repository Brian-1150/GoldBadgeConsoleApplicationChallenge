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
            get {//can we override ToString method of just this prop in order to WriteLine the name of the vehicle?
                if (Type.TypeOfVehicle == Vehicle.VehicleType.Van || Type.TypeOfVehicle == Vehicle.VehicleType.Sedan)
                    return true;
                else return false;
            }
        }
        public double Points {
            get {
                double discount = 0;
                if (VehicleTypDiscount) discount = 1;

                return 5 + RecentInfractions.Count - (MonthsWithoutInfraction / 6) - discount;
            }
        }
       public DateTime InitialDateOfService { get; set; } = DateTime.Now;
        //public DateTime InitialDateOfService { get { return DateTime.Now; } set { InitialDateOfService = DateTime.Now; } } // = new DateTime(2020, 1, 1);// DateTime.Now;
        public List<Infractions> RecentInfractions { get; set; } = new List<Infractions>(); //{ new Infractions(InfractionType.LaneViolation, new DateTime(2020, 10, 10)) };
        public double MonthsWithoutInfraction { get { return ((DateTime.Now - DateOfLastInfraction).TotalDays) / 30; } }
        public double Premium { get { return Points * 100; } }
        public DateTime DateOfLastInfraction {
            get {
                if (RecentInfractions.Count == 0)  // if (RecentInfractions.Last().DateOfInfraction == null was not working????
                    return InitialDateOfService ;            // I want to return inital dateOfService???? InitialDateOfService;
                else return RecentInfractions.Last().DateOfInfraction; }
           
            
        } // need to add InitialDateOfService as property and add as default
        public int CustomerID { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email2 { get; set; }

        public Driver() { }

        public Driver(Vehicle type, CustomerStatus statusOfCustomer, string firstName, string lastName, string phoneNumber, string email)
            : base(statusOfCustomer, firstName, lastName, phoneNumber, email) {
            Type = type;

        }
    }

   public enum InfractionType { 
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
        public override string ToString() {
            string x = "Date:  ";
            x += DateOfInfraction.ToShortDateString();
            x += "\nType:  ";
            x += TypeOfInfraction;

            return x;
        }
    }
}




