using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge_8_Repository;
using Challenge_6_Repository;
using Challenge_5_Repository;

namespace Challenge_8_Console {
    public class ProgramUI8 {
        DriverRepo _repo = new DriverRepo();

        public void Run() {
            Seed();
            while (Menu()) {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private bool Menu() {
            Console.WriteLine("\t\tOptions\n");
            // Console.WriteLine("{0,-10}", "Options:"); formatting not working
            Console.WriteLine(
                "1.  View List of Drivers\n" +
                "2.  Add New Drivers to Database\n" +
                "3.  Edit Drivers\n" +
                "4.  \n" +
                "5.  Exit");

            Console.WriteLine("What would you like to do next?  Please choose a number from the menu");
            var input = TryParse(Console.ReadLine());

            switch (input) {
                case 1:  //View
                    ViewDrivers();
                    break;
                case 2: //Add
                    AddDriver();
                    break;
                case 3: //Edit
                    EditDriver();
                    break;
                case 4:

                    break;
                case 5:  //Exit
                    Console.WriteLine("Have a great day!");
                    return false;

                default:
                    Console.WriteLine("Please enter a valid digit 1-6");
                    break;
            }
            return true;
        }

        //View
        private void ViewDrivers() {
           var dictionary = _repo.GetDictionaryOfDrivers();
            Console.Write("{0,-12} {1,-12} {2, -25} {3, -15} {4, 0}\n\n", "CustomerID", "Last Name", "First Name", "Points", "Monthly Premium");
            foreach (KeyValuePair<int, Driver> driver in dictionary) {
                Console.WriteLine("{0,-12} {1,-12} {2, -25} {3, -15} {4, 0}", driver.Value.CustomerID, driver.Value.LastName, driver.Value.FirstName, driver.Value.Points.ToString("#,#.##"), driver.Value.Premium.ToString("#,#.##"));

            }
        }
        //Add
        private void AddDriver() {

        }
        //Edit
        private void EditDriver() {

        }
        //Helper Methods
        public int TryParse(string number) {

            int.TryParse(number, out int k);
            while (k <= 0) {
                Console.WriteLine("Please enter a valid number");
                number = Console.ReadLine();
                int.TryParse(number, out k);
            }
            return k;
        }

        //Seed
        private void Seed() {
            Vehicle vehicle1 = new Vehicle("Dodge Grand Caravan", 27000, Vehicle.VehicleType.Van);
            Vehicle vehicle2 = new Vehicle("Honda Civic", 18000, Vehicle.VehicleType.Sedan);
            Vehicle vehicle3 = new Vehicle("Ford Mustang", 32000, Vehicle.VehicleType.Coupe);
            Vehicle vehicle4 = new Vehicle("Chevrolet Silverado", 42000, Vehicle.VehicleType.Truck);
            Driver seed1 = new Driver(vehicle1, CustomerStatus.Current, "Brian", "Campassi", "317-123-4567", "brian@1150.edu");
            Driver seed3 = new Driver(vehicle2, (CustomerStatus)1, "Joe", "Johnson", "317-317-3173", "joe@elevenfifty.com");
            Driver seed4 = new Driver(vehicle3, (CustomerStatus)1, "Jack", "Johnson", "377-317-3173", "jj@elevenfifty.com");
            Driver seed5 = new Driver(vehicle4, CustomerStatus.Current, "Elli", "Belly", "123-456-7890", "Ellbell@123.org");
            Driver seed2 = new Driver(vehicle4, (CustomerStatus)1, "Sean", "Stevens", "555-555-5555", "@gmail.com");
            _repo.AddDriver(seed5, seed4, seed3, seed1, seed2);
        }


    }
}
