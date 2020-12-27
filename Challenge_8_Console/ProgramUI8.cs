﻿using System;
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
                "4.  Update Driving Record\n" +
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
            Console.Write("{0,-12} {1,-12} {2, -15} {3, -15} {4, 0}\n\n", "CustomerID", "Last Name", "First Name", "Points", "Monthly Premium");
            foreach (KeyValuePair<int, Driver> driver in dictionary) {
                Console.WriteLine("{0,-12} {1,-12} {2, -15} {3, -15} {4, 0}", driver.Value.CustomerID, driver.Value.LastName, driver.Value.FirstName, driver.Value.Points.ToString("#,#.##"), driver.Value.Premium.ToString("#,#.##"));

            }
        }
        private bool ViewDetailsForDriver(int key) {
            Driver driver = FoundDriver(key);
            if (driver == null) {
                Console.WriteLine("Driver could not be found.  Please try again.");
                return false;
            }
            Console.WriteLine($"Customer ID: {driver.CustomerID}\n" +
                              $"{0,-40}", $"First Name:             {driver.FirstName}", $"Last Name:  {driver.LastName}\n" +
                              $"{0,-40}", $"Primary Phone Number:   {driver.PhoneNumber}", $"Secondary Phone Number: {driver.PhoneNumber2}\n" +
                              $"{0,-40}", $"Email:                  {driver.Email}", $"Secondary Email:        {driver.Email2}\n");

            return true;
        }
        //Add
        private void AddDriver() {
            var sb = new StringBuilder();
            Console.WriteLine("From here you will be able to add a new driver to the system.  Would you like to proceed?");
            if (!YesOrNo()) return;
            Console.WriteLine("Enter the first name:");
            var firstName = Console.ReadLine();
            Console.WriteLine(sb.Append(firstName));
            Console.WriteLine("Enter the last name");
            var lastName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine(sb.AppendLine(lastName));
            Console.WriteLine("\nWhat is the phone number?");
            var phone = Console.ReadLine();
            Console.Clear();
            Console.WriteLine(sb.AppendLine(phone));
            Console.WriteLine("Enter the email address");
            var email = Console.ReadLine();
            Console.Clear();
            Console.WriteLine(sb.AppendLine(email));
            Console.WriteLine("Now let's get the vehicle info");
            Console.WriteLine("Enter the make and model");
            string makeModel = Console.ReadLine();
            Console.WriteLine("Enter the retail cost");
            double price = TryParseDub(Console.ReadLine());
            Console.WriteLine("Choose the number of the type from the list\n" +
                              "1.  Sedan\n" +
                              "2.  Van\n" +
                              "3.  Truck\n" +
                              "4.  Coupe\n" +
                              "5.  Other");
            int type = TryParse(Console.ReadLine());
            Vehicle newVehicle = new Vehicle(makeModel, price, (Vehicle.VehicleType)type);

            Driver newDriver = new Driver(newVehicle, CustomerStatus.Current, firstName, lastName, phone, email);
            _repo.AddDriver(newDriver);
        }


        //Edit
        private void EditDriver() {
            bool exit = false;
            ViewDrivers();
            Console.WriteLine("Enter the number of the driver you wish to update:");
            int key = TryParse(Console.ReadLine());
            if (ViewDetailsForDriver(key) == false) return;
            Console.WriteLine("Do you need to update basic contact info at this time?");
            if (YesOrNo()) {
                while (exit == false) {
                    Console.WriteLine("    Enter the number of the category you wish to edit.");
                    Console.WriteLine("\n1.  First Name\n" +
                                      "2.  Last Name\n" +
                                      "3.  Primary Phone Number\n" +
                                      "4.  Secondonary Phone Number\n" +
                                      "5.  Primary Email\n" +
                                      "6.  Secondary Email\n" +
                                      "7.  Finished Updating");
                    string input = Console.ReadLine();
                    switch (input) {
                        case "1":
                            Console.WriteLine("Enter the first name:");
                            var firstName = Console.ReadLine();
                            break;
                        case "2":
                            Console.WriteLine("Enter the last name:");
                            var lastName = Console.ReadLine();
                            break;
                        case "3":
                            Console.WriteLine("Enter the new phone number:");
                            string phone = Console.ReadLine();
                            break;
                        case "4": Console.WriteLine("Enter the secondary phone number:");
                            string phone2 = Console.ReadLine();
                            break;
                        case "5": Console.WriteLine("Enter the primary email:");
                            break;
                        case "6": Console.WriteLine("Enter the secondary email");
                            break;
                        case "7": exit = true;
                            break;
                    }
                } 
            }


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
        public double TryParseDub(string dub) {
            double.TryParse(dub, out double d);
            while (d <= 0) {
                Console.WriteLine("Please enter a valid number without $ ex (9.99): ");
                dub = Console.ReadLine();
                double.TryParse(dub, out d);
            }
            return d;
        }
        //YesNo
        private bool YesOrNo() {

            while (true) {
                string input = Console.ReadLine().ToLower();
                switch (input) {

                    case "yes":
                    case "y":
                        return true;
                    case "no":
                    case "n":
                        return false;
                }
                Console.WriteLine("Please enter 'y' or 'n' ");
            }
        }
        private Driver FoundDriver(int key) {
            if (_repo.GetDriver(key) == null) {
                return null;
            }
            else return _repo.GetDriver(key);
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
