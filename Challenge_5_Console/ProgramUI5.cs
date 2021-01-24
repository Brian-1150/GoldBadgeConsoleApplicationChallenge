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
                "4.  View/Send Emails\n" +
                "5.  Exit");

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
                    EditCustomer();
                    break;
                case 4: //View edit emails
                    Send();
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
                Console.ReadKey();

            }
        }
        private void ViewEmails() {
            Console.Clear();
            var x = _repo.EmailDictionary();
            foreach (var kvp in x) {
                Console.WriteLine($"{kvp.Key}:  {kvp.Value}\n");
            }
        }

        private void ViewAllCustomers(List<Customer> list) {
            Console.Write("{0,-12} {1,-12} {2, -25} {3, -15} {4, 0}\n\n", "Last Name", "First Name", "Email", "Phone Number", "Status");
            foreach (var customer in list) {
                Console.WriteLine("{0,-12} {1,-12} {2, -25} {3, -15} {4, 0}", customer.LastName, customer.FirstName, customer.Email, customer.PhoneNumber, customer.StatusOfCustomer);
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
        private void EditCustomer() {
            Console.Clear();
            var custToEdit = Search();
            if (custToEdit == null) {
                return;
            }
          
                var replacement = new Customer();
                Console.WriteLine($"Do you wish to remove {custToEdit.FirstName} {custToEdit.LastName} from database?");
                if (YesOrNo()) {
                    Console.WriteLine($"Are you sure?  {custToEdit.FirstName} {custToEdit.LastName} will be placed on a (DO NOT CONTACT) list.");
                    if (YesOrNo()) {
                        _repo.DeleteCustomer(custToEdit);
                        return;
                    }

                }
                Console.WriteLine("Do you need to change the first name?");
                if (YesOrNo()) {// can I write a foreach loop for every prop in object properties to do all these things
                    Console.WriteLine("Enter the new first name:");
                    replacement.FirstName = Console.ReadLine();
                }
                Console.WriteLine("Do you need to change the last name?");
                if (YesOrNo()) {
                    Console.WriteLine("Enter the new last name:");
                    replacement.LastName = Console.ReadLine();
                }
                Console.WriteLine("Do you need to change the email address?");
                if (YesOrNo()) {
                    Console.WriteLine("Enter the new email address");
                    replacement.Email = Console.ReadLine();
                }
                Console.WriteLine("Do you need to change the phone number?");
                if (YesOrNo()) {
                    Console.WriteLine("Enter the new phone number with no dashes");
                    replacement.PhoneNumber = Console.ReadLine();
                }
                Console.WriteLine("Change or confirm the status:\n" +
                    "1.  Current Customer\n" +
                    "2.  Past Customer\n" +
                    "3.  Prospective Customer");
                int status = 5;
                while (status > 3) {
                    status = TryParse(Console.ReadLine());
                    if (status < 4) {

                        replacement.StatusOfCustomer = (CustomerStatus)status;
                    }
                    else {
                        Console.WriteLine("Please enter 1, 2, or 3");
                    }
                }

                _repo.EditCustomer(custToEdit, replacement);
            }
        
        private void Send() {
            ViewEmails();
            Console.WriteLine("Press 's' to send these emails now.  Any other key to return to previous menu");
            var x = Console.ReadLine();
            if (x == "s")
                Console.WriteLine("Emails sent!");

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
        private List<Customer> SortListABC(int choice) {
            var list = _repo.ListOfCustomers(choice);
            list.Sort((x, y) => string.Compare(x.LastName, y.LastName));
            return list;

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
        //Search
        private Customer Search() {
            Console.WriteLine("To search for a customer, simply enter the first name, last name, phone number, or email.\n  You may " +
               "also enter a portion of one of these.  Example:  Enter (Brian) or (bri) or (3174567890) or (3174)\n" +
               "Who would you like to search for?");

            var tempList = new List<Customer>();
            string search = Console.ReadLine();
            var list = _repo.ListOfCustomers();
            foreach (var x in list) {
                if (x.FirstName.ToLower().Contains(search.ToLower()) || x.LastName.ToLower().Contains(search.ToLower()) || x.Email.Contains(search) || x.PhoneNumber.Contains(search)) {
                    tempList.Add(x);
                }
            }
            if (tempList.Count == 0) {
                Console.WriteLine("No customers were found using that search criteria.  Start over\n" +
                    " and try adding fewer characters to return a larger list of customers");
                return null;
            }
            //ViewAllCustomers(tempList);
            int index = 1;
            Console.Write("{0,-12} {1,-12} {2, -25} {3, -15} {4, 0}\n\n", "Last Name", "First Name", "Email", "Phone Number", "Status");
            foreach (var y in tempList) {
                Console.WriteLine("{0,-5}{1,-12} {2,-12} {3, -25} {4, -15} {5, 0}", index, y.LastName, y.FirstName, y.Email, y.PhoneNumber, y.StatusOfCustomer);
                index++;
            }
            Console.WriteLine("If the customer you wish to edit is shown, enter the index number.  Or enter 0 to return the previous menu");
            int selection = TryParse(Console.ReadLine());
            if (selection <= 0 || selection > tempList.Count) { return null; }
            var custToEdit = tempList.ElementAt(selection - 1);
            return custToEdit;

        }

        public void Seed() {
            Customer _seedCustomer = new Customer(CustomerStatus.Current, "Brian", "Campassi", "317-765-1234", "brian@1150.com");
            Customer _seedCustomer2 = new Customer((CustomerStatus)2, "Joe", "Johnson", "317-317-3173", "joe@elevenfifty.com");
            Customer _seedCustomer3 = new Customer();
            Customer _seedCustomer4 = new Customer((CustomerStatus)3, "Jack", "Johnson", "377-317-3173", "jj@elevenfifty.com");
            _seedCustomer3.FirstName = "Ellen";
            _seedCustomer3.Email = "ellen@elevenfifty.com";
            _repo.AddToList(_seedCustomer4, _seedCustomer3, _seedCustomer2, _seedCustomer);

            var currentEmail = new KeyValuePair<string, string>("Current", "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");
            var pastEmail = new KeyValuePair<string, string>("Past", "It's been a long time since we've heard from you, we want you back");
            var prospectEmail = new KeyValuePair<string, string>("Prospect", "We currently have the lowest rates on Helicopter Insurance!");
            _repo.AddEmails(pastEmail);
            _repo.AddEmails(currentEmail);
            _repo.AddEmails(prospectEmail);



        }
    }
}
