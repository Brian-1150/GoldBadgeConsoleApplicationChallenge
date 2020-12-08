using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge_2_Repository;


namespace Challenge_2_Console {
    class ProgramUI2 {
        private ClaimsRepo _claimsRepo = new ClaimsRepo();

        public void Run() {
            //Seed
            Seed();
            //Menu
            Menu();

        }
        //Main Menu
        private void Menu() {

            bool exit = false;
            do {
                //Display Menu
                Console.WriteLine("Select an option:  \n" +
                    " 1.  View Queue\n" +
                    " 2.  Add a New Claim to the Queue\n" +
                    " 3.  Pull Next Claim from Queue\n" +
                    " 5.  Exit");

                //Get User Input
                string input = Console.ReadLine();

                //Read Input and Invoke Appropriate Method(s)
                switch (input) {
                    case "1": //View
                        ViewQueue();
                        break;
                    case "2":  //Add
                        CreateNewClaim();
                        break;
                    case "3": //Next Queue
                        NextItemInQueue();
                        break;
                    case "4": //Delete
                              // RemoveItemFromList();
                        break;
                    case "5": //Exit
                        Console.WriteLine("Have a great rest of your day!");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number 1-5");
                        break;
                }
                Console.WriteLine("Please press any key to continue..."); //just to pause and let user know they are in control of proceeding
                Console.ReadKey();

                Console.Clear(); // clears the console window to remove all the previous menues etc..

            } while (exit == false);
        }

        //View
        public void ViewQueue() {
            Console.Clear();
            _claimsRepo.ViewQueue();

        }

        //Add
        //user inputs one category at a time and then it as added to queue all together as one new claims object
        public void CreateNewClaim() {
            Console.WriteLine("What is the ID for the new claim?");
            int id = _claimsRepo._accesssToChallenge1RepoMethods.TryParse();
            Console.WriteLine("What type of claim is this? (Auto, Home, Theft)");
            string type = Console.ReadLine();
            Console.WriteLine($"Provide a brief description for claim { id}:");
            string description = Console.ReadLine();
            Console.WriteLine("Enter the amount of the claim.  ex(400.00)");
            double amount = _claimsRepo._accesssToChallenge1RepoMethods.TryParse(Console.ReadLine());
            Console.WriteLine("Enter the year the in which the incident took place:  ex(2020)");
            int year = _claimsRepo._accesssToChallenge1RepoMethods.TryParse();
            Console.WriteLine("Enter the month:  ex (01 for January)");
            int month = _claimsRepo._accesssToChallenge1RepoMethods.TryParse();
            Console.WriteLine("Enter the day:  ex (25)");
            int day = _claimsRepo._accesssToChallenge1RepoMethods.TryParse();
            DateTime incident = new DateTime(year, month, day);

            Console.WriteLine("Enter the year the in which the claim was filed:  ex(2020)");
            int yearClaim = _claimsRepo._accesssToChallenge1RepoMethods.TryParse();
            Console.WriteLine("Enter the month:  ex (01 for January)");
            int monthClaim = _claimsRepo._accesssToChallenge1RepoMethods.TryParse();
            Console.WriteLine("Enter the day:  ex (25)");
            int dayClaim = _claimsRepo._accesssToChallenge1RepoMethods.TryParse();
            DateTime claimDate = new DateTime(yearClaim, monthClaim, dayClaim);
            //bool isValid;  this way does not work.  I must set it to false.  why????
            bool isValid = false;
            //check to see if difference between incident and claim is 30 days or less
            TimeSpan incidentClaimDiff = claimDate - incident;
            double daysElapsed = incidentClaimDiff.Days;
            if (daysElapsed <= 30.0) {
                isValid = true;
            }
            Claims newClaim = new Claims(id, type, description, amount, incident, claimDate, isValid);
            _claimsRepo.AddClaim(newClaim);

        }

        //Edit
        public void NextItemInQueue() {
            _claimsRepo.NextItemInQueue();
            Console.WriteLine("Would you like to proceed with this claim now?");
            if (!_claimsRepo._accesssToChallenge1RepoMethods.YesOrNO()) {
                Console.WriteLine($"The claim will remain in the queue");
                return;
            }
            if (_claimsRepo.Dequeue()) {
                Console.WriteLine("Claim successfully permanently removed from queue");
            }
            else
                Console.WriteLine("Unable to remove claim from queue at this time.  Please try agian");
        }

        //Seed
        public void Seed() {
            var seedClaim1 = new Claims(1, "Auto", "Crash", 500, new DateTime(2020, 12, 12), new DateTime(2020, 12, 25), true);
            var seedClaim2 = new Claims(2, "Home", "A silly roofer was jumping up and down and crashed into my living room", 8000, new DateTime(2020, 10, 8), new DateTime(2020, 12, 7), true);
            _claimsRepo.AddClaim(seedClaim2);//is there a way to add multiple seed claims in one line???
            _claimsRepo.AddClaim(seedClaim1);//instead of 2 separate lines like this


            //Fixes needed:  User must choose Auto, Home, Theft, not just any string.  
            //               Catch future dates as invalid and do not allow claim date to be before incident
            //Should we add an edit method for manually changing a claim that is already in queue??
            //invalid day or month throws exception.  consider user entering full date in one read line and check it for validity
            //Prevent user from entering the same claim id of an existing claim. Consider implementing auto generated id
        }
    }
}
