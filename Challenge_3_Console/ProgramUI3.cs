using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge_3_Repository;
using Challenge_1_Repository; //access to y/n and tryparse helper methods

namespace Challenge_3_Console {
    class ProgramUI3 {

        private BadgesRepo _repo = new BadgesRepo();
        int nextBadgeNumber = 1004;

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
                    " 1.  See List of Badges\n" +
                    " 2.  Add a New Badge to System\n" +
                    " 3.  Edit Door Access for Existing Badge\n" +
                    " 5.  Exit");

                //Get User Input
                string input = Console.ReadLine();

                //Read Input and Invoke Appropriate Method(s)
                switch (input) {
                    case "1": //View
                        ViewDictionaryOfBadges();
                        break;
                    case "2":  //Add
                        AddBadge();
                        break;
                    case "3": //Update
                        UpdateBadge();
                        break;
                    case "4": //Delete

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
        public void ViewDictionaryOfBadges() {
            Console.Clear();
            var dictionary = _repo.DisplayListOfBadges();

            Console.WriteLine($"Badge #\t\tEmployee Name\t\tDoor Access\n");
            foreach (KeyValuePair<int, Badges> kvp in dictionary) {

                Console.Write($"{kvp.Key}\t\t{kvp.Value.EmployeeName}\t\t\t");
                kvp.Value.HasAccessTo.Sort();  // this will sort the list of doors in order
                foreach (var door in kvp.Value.HasAccessTo) {

                    Console.Write($"{door} ");
                }
                Console.WriteLine();
            }
        }

        //Update
        public void UpdateBadge() {
            Console.Clear();
            ViewDictionaryOfBadges();
            Console.WriteLine("Enter the BadgeID to update door access:  ");
            string input = Console.ReadLine();
            int badgeID = TryParse(input);
            var badgeToUpdate = _repo.GetBadgeByKey(badgeID);
            if (badgeToUpdate != null) {
                UpdateMenu(badgeToUpdate);
            }
            else Console.WriteLine($"Start over!  {input} is not a valid BadgeID on this list");

        }
        //Add Doors
        public void AddDoors(Badges badge) {
            Console.WriteLine($"{badge.BadgeID} has access to the following doors:");
            foreach (var currentDoor in badge.HasAccessTo) {
                Console.Write(currentDoor + " ");
            }
            var list = _repo.ListOfDoors();
            foreach (var door in list) {
                foreach (var currentDoor in badge.HasAccessTo) {
                    if ()
                    Console.WriteLine(door);
                }
                Console.WriteLine(");
        } }

        //Remove Doors
        public void RemoveDoors(Badges badge) { }

        //Deactivate Badge
        public void DeactivateBadge(Badges badge) { }

        //Update Menu
        public void UpdateMenu(Badges badge) {

            bool exit = false;
            do {
                //Display Menu
                Console.WriteLine("Would you like to:  \n" +
                    $" 1.  Add Door Access to Badge# {badge.BadgeID}\n" +
                    $" 2.  Remove Door Access from Badge# {badge.BadgeID}\n" +
                    $" 3.  Deactivate Badge# {badge.BadgeID}\n" +
                    " 4.  Return to the Main Menu");

                //Get User Input
                string input = Console.ReadLine();

                //Read Input and Invoke Appropriate Method(s)
                switch (input) {
                    case "1": //Add
                        AddDoors(badge);
                        break;
                    case "2":  //Remove
                        RemoveDoors(badge);
                        break;
                    case "3": //Deactivate
                        DeactivateBadge(badge);
                        break;
                    case "4": //Exit
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number 1-4");
                        break;
                }

                Console.Clear(); // clears the console window to remove all the previous menues etc..

            } while (exit == false);
        }

        //Add
        public void AddBadge() {
            var newBadge = new Badges();

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
        public int BadgeIDAssignment() {
            nextBadgeNumber++;
            return nextBadgeNumber;

        }

        //Seed
        private void Seed() {
            Badges seedBadge = new Badges(1001, "Sean", new List<string>() { "A1", "A2", "A5" });
            Badges seedBadge2 = new Badges(1002, new List<string>() { "A1", "A9", "A2" }); //the display method will show A1 A2 A9 in order by invoking sort()
            Badges seedBadge3 = new Badges(1003, "Josh", new List<string>() { "A1", "A2", "A3", "A4", "A5" });
            var seedBadge4 = new Badges(1004, "Adam", new List<string>() { "A1", "A2", "A3", "A4", "A5" });

            seedBadge2.EmployeeName = "Brian";
            _repo.CreateNewBadge(seedBadge.BadgeID, seedBadge);
            _repo.CreateNewBadge(seedBadge2.BadgeID, seedBadge2);
            _repo.CreateNewBadge(seedBadge3.BadgeID, seedBadge3);
            _repo.CreateNewBadge(seedBadge4.BadgeID, seedBadge4);
        }

    }
}
