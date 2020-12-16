using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge_5_Repository;

namespace Challenge_5_Console {
    class ProgramUI5 {
        CustomerRepo _repo = new CustomerRepo();
        public void Run() {
            Seed();
            while (Menu()) {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public bool Menu() {
            Console.WriteLine("\t\tOptions\n");
            // Console.WriteLine("{0,-10}", "Options:"); formatting not working
            Console.WriteLine(
                "1.  View List(s) of Customers\n" +
                "2.  Add New Customers to Database\n" +
                "3.  Edit Customers\n" +
                "4.  View/Edit Emails\n" +
                "5.  Send Emails\n" +
                "6.  Exit");

            Console.WriteLine("What would you like to do next?  Please choose a number from the menu");
            var input = TryParse(Console.ReadLine());

            switch (input) {
                case 1:  //View
                    ViewCustomers();
                    break;
                case 2: //Add
                    AddCustomer();
                    break;
                case 3: //Edit
                    break;
                case 4: //View edit emails
                    break;
                case 5:  //Send email
                    break;
                case 6: //Exit
                    Console.WriteLine("Have a great day!");
                    return false;
                default:
                    Console.WriteLine("Please enter a valid digit 1-6");
                    break;
            }
            return true;
        }
        //View
        private void ViewCustomers() {
            while (true) {
                Console.Clear();
                Console.WriteLine("Which list of customers would you like to view?\n" +
                                   "1.  Current Customers\n" +
                                   "2.  Former Customers\n" +
                                   "3.  Prospective Customers\n" +
                                   "4.  All Customers\n" +
                                   "5.  Return to Main Menu");
                var input = TryParse(Console.ReadLine());
                Console.Clear();
                switch (input) {
                    case 1:
                        ViewAllCustomers(SortListABC(1));
                        break;
                    case 2:
                        ViewAllCustomers(SortListABC(2));
                        break;
                    case 3:
                        ViewAllCustomers(SortListABC(3));
                        break;
                    case 4:
                        ViewAllCustomers(SortListABC(4));
                        break;
                    case 5: return;

                    default:
                        Console.WriteLine("Enter a valid number 1-5");
                        break;
                }
                Console.WriteLine("\nPress any key...");
                Console.ReadLine();
                    
            }
        }

        private void ViewAllCustomers(List<Customer> list) {
            Console.Write("{0,-12} {1,-12} {2, -25} {3, 0}\n\n", "Last Name", "First Name", "Email", "Status");
            foreach (var customer in list) {
                Console.WriteLine("{0,-12} {1,-12} {2, -25} {3, 0}", customer.LastName, customer.FirstName, customer.Email, customer.StatusOfCustomer);
            }
        }
        //Add
        private void AddCustomer() {
            Console.Clear();
            var newCustomer = new Customer();
            Console.WriteLine("What is the first name of the new customer?");
            newCustomer.FirstName = Console.ReadLine();
            Console.WriteLine($"What is {newCustomer.FirstName}'s last name?");
            newCustomer.LastName = Console.ReadLine();
            Console.WriteLine($"What is {newCustomer.FirstName}'s email address?");
            newCustomer.Email = Console.ReadLine();
            int status = 5;
            while (status > 3) {
                Console.WriteLine($"What is {newCustomer.FirstName}'s status?\n" +
                    $"1.  Current Customer\n" +
                    $"2.  Past Customer\n" +
                    $"3.  Prospective Customer");
                status = TryParse(Console.ReadLine());
                if (status < 4) {
                    newCustomer.StatusOfCustomer = (CustomerStatus)status;
                }
                else {
                    Console.WriteLine("Please enter 1, 2, or 3");
                }
            }
            foreach (var cust in _repo.ListOfCustomers()) {//Check for duplicate and confirm before proceeding
                
            if (newCustomer.FirstName == cust.FirstName && newCustomer.LastName == cust.LastName) {
                    Console.WriteLine($"Exact match for {newCustomer.FirstName} {newCustomer.LastName} was found.  Are you sure " +
                        $"you want to add as a new customer?");
                    if (!YesOrNo()) { Console.WriteLine("New customer additon cancelled"); return; }

                }
            }
            _repo.AddToList(newCustomer);
            Console.WriteLine("New customer added!");
        }
        //Update

        //Delete





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
        private List<Customer> SortListABC(int choice) {
            var list = _repo.ListOfCustomers(choice);
            list.Sort((x, y) => string.Compare(x.LastName, y.LastName));
            return list;

        }

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


        public void Seed() {
            Customer _seedCustomer = new Customer(CustomerStatus.Current, "Brian", "Campassi", "317-765-1234", "brian@1150.com");
            Customer _seedCustomer2 = new Customer((CustomerStatus)2, "Joe", "Johnson", "317-317-3173", "joe@elevenfifty.com");
            Customer _seedCustomer3 = new Customer();
            Customer _seedCustomer4 = new Customer((CustomerStatus)3, "Jack", "Johnson", "377-317-3173", "jj@elevenfifty.com");
            _seedCustomer3.FirstName = "Ellen";
            _seedCustomer3.Email = "ellen@elevenfifty.com";
            _repo.AddToList(_seedCustomer4, _seedCustomer3, _seedCustomer2, _seedCustomer);
        }
    }
}
