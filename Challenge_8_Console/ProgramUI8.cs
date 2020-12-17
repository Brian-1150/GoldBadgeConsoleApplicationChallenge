using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge_8_Repository;

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

        }


    }
}