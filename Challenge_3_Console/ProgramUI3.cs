using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge_3_Repository;

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

        //Update Menu
        public void UpdateMenu(Badges badge) {

            bool exit = false;
            do {
                //Display Menu
                Console.Clear();
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
        //Add Doors
        public void AddDoors(Badges badge) {
            var listOfAddedDoors = new List<string>();
            var listOfDoors = _repo.ListOfDoors(); //temporary list to add to.  Then send it to repo to be added to actual badge
            Console.Clear();
            Console.Write($"{badge.BadgeID} has access to the following doors:");
            foreach (var currentDoor in badge.HasAccessTo) {
                Console.Write(currentDoor + " ");
            }
            Console.WriteLine("\n\nAvialable doors to add:\n");
            var doorsNotAlreadyOnBadge = listOfDoors.Except(badge.HasAccessTo).ToList(); //shows only doors not already assigned to this badge
            foreach (var door in doorsNotAlreadyOnBadge) {
                Console.WriteLine(door);
            }
            int doorsToAdd;
            do {
                Console.WriteLine($"How many additional doors would you like to give {badge.BadgeID} access to?");
                doorsToAdd = TryParse(Console.ReadLine());
                if (doorsToAdd <= 0 || doorsToAdd > doorsNotAlreadyOnBadge.Count) {
                    Console.WriteLine("Please enter a valid number no greater than the number of doors on the list");
                }
            } while (doorsToAdd <= 0 || doorsToAdd > doorsNotAlreadyOnBadge.Count);

            for (int i = 0; i < doorsToAdd; i++) {
                string input;
                Console.WriteLine("Which door would you like to add next?");
                int count = listOfAddedDoors.Count;
                input = Console.ReadLine();
                foreach (var door in doorsNotAlreadyOnBadge) {

                    if (input.ToLower() == door.ToLower()) {
                        listOfAddedDoors.Add(door);
                    }
                }
                Console.Clear();
                if (count == listOfAddedDoors.Count) {
                    Console.WriteLine($" {input} not a valid selection and was not added to badge {badge.BadgeID}\n\n");
                }
                else { Console.WriteLine($" {input.ToUpper()} successfully added to badge {badge.BadgeID}\n\n"); }
                doorsNotAlreadyOnBadge = doorsNotAlreadyOnBadge.Except(listOfAddedDoors).ToList();
                Console.WriteLine($"Remaining availabel doors to add to {badge.BadgeID}: \n");
                foreach (var door in doorsNotAlreadyOnBadge) { //foreach loop to print updated available door list
                    Console.WriteLine(door);
                }
            }
            _repo.AddDoorsToBadge(badge.BadgeID, listOfAddedDoors);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        //Remove Doors
        public void RemoveDoors(Badges badge) {
            var listOfRemovedDoors = new List<string>();
            Console.Clear();
            Console.Write($"{badge.BadgeID} has access to the following doors:\n\n");
            foreach (var currentDoor in badge.HasAccessTo) {
                Console.WriteLine(currentDoor + " ");
            }
            int doorsToRemove;
            do {
                Console.WriteLine($"\n\nHow many doors do you wish to remove form {badge.BadgeID}?");
                doorsToRemove = TryParse(Console.ReadLine());
                if (doorsToRemove <= 0 || doorsToRemove > badge.HasAccessTo.Count) {
                    Console.WriteLine("Please enter a valid number no greater than the number of doors on the list");
                }
            } while (doorsToRemove <= 0 || doorsToRemove > badge.HasAccessTo.Count);

            for (int i = 0; i < doorsToRemove; i++) {
                string input;
                Console.WriteLine("Which door would you like to remove next?");
                int count = listOfRemovedDoors.Count;
                input = Console.ReadLine();
                foreach (var door in badge.HasAccessTo) {

                    if (input.ToLower() == door.ToLower()) {
                        listOfRemovedDoors.Add(door);
                    }
                }
                if (count == listOfRemovedDoors.Count) {
                    Console.WriteLine($" {input} not a valid selection and was not successfully removed from badge {badge.BadgeID}\n\n");
                }
                else { Console.WriteLine($" {input.ToUpper()} successfully removed from badge {badge.BadgeID}\n\n"); }
                var tempEditedList = badge.HasAccessTo.Except(listOfRemovedDoors).ToList();
                Console.WriteLine($"\nRemaining doors accessible by {badge.BadgeID}: \n");
                foreach (var door in tempEditedList) { //foreach loop to print updated available door list
                    Console.WriteLine(door);
                }
            }
            _repo.RemoveDoorsFromBadge(badge.BadgeID, listOfRemovedDoors);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        //Deactivate Badge
        public void DeactivateBadge(Badges badge) {
            string yn;
            Console.WriteLine($"Are you sure you want to deactivate this badge {badge.BadgeID}?  This cannot be undone!");
            yn = Console.ReadLine();
            if (!YesOrNO(yn)) {
                Console.WriteLine("Press any key to return to the previous menu");
                Console.ReadKey();
                return;
            }
            else {
                Console.WriteLine($"Be sure to destroy badge {badge.BadgeID}.  For security purposes, a deactivated badge\n" +
             $"will be treated as if lost or stolen.  Door handles will be electified if the card \nattempts to access a \nforbidden door. " +
             $"The deactivation is permanent. \n\n\nCarefully type in the badgeID to permanently deactivate");
            }
            int confirm = TryParse(Console.ReadLine());
            if (confirm == badge.BadgeID) {
                _repo.DeactivateBadge(badge.BadgeID);
                Console.WriteLine($"Badge {badge.BadgeID} has been deactivated");
            }
            else {
                Console.WriteLine("Not a match.  Please try again later");
            }
            Console.WriteLine("Press any key to return to the previous menu");
            Console.ReadKey();
        }

    //Add 
        public void AddBadge() {
            Console.Clear();
            string yn;
            var doorsForNewBadge = new List<string>();
            var doorsList = _repo.ListOfDoors();
            int numOfDoors;
            string name;
            var newBadge = new Badges();
            newBadge.BadgeID = BadgeIDAssignment();
            do {
                Console.WriteLine($"What is the name of the employee you wish to assign to this new badge?");
                name = Console.ReadLine();
                Console.WriteLine($"You entered {name}.  Is this correct?  The name cannot be changed after badge is assigned");
                yn = Console.ReadLine();
                if (!YesOrNO(yn)) { 
                    Console.Clear();
                    Console.WriteLine("Please enter the name again");
                }
                newBadge.EmployeeName = name;
            } while (!YesOrNO(yn));
            Console.Clear();
            Console.WriteLine("Doors");
            foreach (var door in doorsList) { Console.WriteLine(door); }
            Console.WriteLine("Would you like to assign door access at this time?");
            yn = Console.ReadLine();
            if (YesOrNO(yn)) {
                do {
                    Console.WriteLine($"How many doors would you like grant to {name} access to?");
                    numOfDoors = TryParse(Console.ReadLine());
                    if (numOfDoors <= 0 || numOfDoors > doorsList.Count) {
                        Console.WriteLine("Please enter a valid number no greater than the number of doors on the list");

                    }
                    else {
                        for (int i = 0; i < numOfDoors; i++) {
                            int count = doorsForNewBadge.Count;
                            Console.WriteLine("Which door would you like to assign next?");
                            string nextDoor = Console.ReadLine();
                            foreach (var door in doorsList) {
                                if (door == nextDoor.ToUpper()) {
                                    doorsForNewBadge.Add(nextDoor.ToUpper());
                                }
                            }
                            if (count == doorsForNewBadge.Count) {
                                Console.WriteLine($"{nextDoor} is not a valid door from the list and was not added");

                            }
                        }
                    }
                } while (numOfDoors <= 0 || numOfDoors > doorsList.Count);
            }
            Console.Clear();

                Console.WriteLine("Your new badge will be automatically assigned an ID and the information is as follows:\n");
                Console.Write($"New BadgeID: {newBadge.BadgeID}\n" +
                              $"Employeed Name:  {newBadge.EmployeeName}\n" +
                              $"Door Access:  ");
                foreach (var door in doorsForNewBadge) {
                    Console.Write(door + " ");
                }
            Console.WriteLine("\n\nName and badge number cannot be changed, but door access can be updated later.\n" +
                "Would you like to add this new badge now?");
            yn = Console.ReadLine();
            if (YesOrNO(yn)) {
                newBadge.HasAccessTo = doorsForNewBadge;
                _repo.CreateNewBadge(newBadge.BadgeID, newBadge);
                Console.WriteLine("Congratulations!  Your new badge is activated.");
            }
            else { Console.WriteLine("Sorry about that!  Please try again."); 
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
         
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

        public bool YesOrNO(string yn) {
        Bool:
            
            do {
                if (yn.ToLower() == "y") {
                    return true;
                }
                else if (yn.ToLower() == "n") {
                    return false;
                }
                else {
                    Console.WriteLine("Please enter a 'y' or 'n'");
                    yn = Console.ReadLine();
                    goto Bool; //goto and label scheme because bool was saying not all paths return value(even though it should because it is in a do while loop
                }

            } while (yn != "y" && yn != "n");
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
