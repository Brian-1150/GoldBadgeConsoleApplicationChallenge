﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge_4_Repository;

namespace Challenge_4_Console {
    class ProgramUI4 {
        OutingsRepo _repo = new OutingsRepo();

        public void Run() {
            //Main Menu
            Seed();
            Menu();

        }
        private void Menu() {
            bool exit = false;
            while (exit == false) {
                Console.WriteLine("     ****Main Menu****\n\n\n" +
                                  "Please make a selection\n\n" +
                                  "1.  View Outing Details\n" +
                                  "2.  Add a New Outing\n" +
                                  "3.  Edit Detials for an Outing\n" +
                                  "4.  Exit\n");

                string input = Console.ReadLine();
                switch (input) {
                    case "1": //View
                        ViewOutingsByDate();
                        break;
                    case "2": //View by type
                        AddNewOuting();
                        break;
                    case "3": //Edit
                        EditOuting();
                        break;
                    case "4": //Exit
                        Console.WriteLine("Have a great day!");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please make a valid selection");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //View
        private void ViewOutingsByDate() {
            Console.Clear();
            decimal total = 0;
            var list = ListOfOutingsByDate();
            Console.WriteLine("\t\t\t\tCOST PER");
            Console.WriteLine("DATE\t\tEVENT TYPE\t PERSON\t\tTOTAL COST\n\n");
            foreach (var outing in list) {
                if (outing.TypeOfOuting == OutingType.Theme_Park) {
                    Console.WriteLine($"{outing.DateOfEvent.ToShortDateString()}\t{outing.TypeOfOuting}\t" +
                        $"${outing.CostPerPerson.ToString("#,#")}\t\t${outing.EventCost.ToString("#,#")}");
                    total += outing.EventCost; //we could show decimal if we wanted To.String("#,#.00")
                }
                else {
                    Console.WriteLine($"{outing.DateOfEvent.ToShortDateString()}\t{outing.TypeOfOuting}\t\t" +
                        $"${outing.CostPerPerson.ToString("#,#.")}\t\t${outing.EventCost.ToString("#,#")}");
                    total += outing.EventCost;
                }
            }
            Console.WriteLine($"\nTotal combined cost for all outings :\t  ${total.ToString("#,#")}\n" +
                $"*values are rounded to nearest dollar for convenience\n\n");
            Console.WriteLine("\nWould you like to refine resuts by category? y/n");
            if (!YesOrNO(Console.ReadLine())) { return; }
            OutingSubMenu();
        }
        //View Submenu
        private void OutingSubMenu() {
            Console.Clear();
            bool exit = false;
            while (exit == false) {
                Console.WriteLine("Details by Category:\n\n" +
                "1.  Bowling\n" +
                "2.  Golf\n" +
                "3.  Theme Park\n" +
                "4.  Concert\n" +
                "5.  Return to Main Menu");
                string input = Console.ReadLine();
                decimal total = 0;
                switch (input) {
                    case "1": //Bowling
                        var bowlingList = ListByCategory("1");
                        Console.WriteLine("\t\t\t\tCOST PER");
                        Console.WriteLine("DATE\t\tEVENT TYPE\t PERSON\t\tATTENDANCE\tTOTAL COST\n\n");
                        foreach (var outing in bowlingList) {

                            Console.WriteLine($"{outing.DateOfEvent.ToShortDateString()}\t{outing.TypeOfOuting}\t\t" +
                        $"${outing.CostPerPerson.ToString("#,#")}\t\t{outing.Attendance}\t\t${outing.EventCost.ToString("#,#")}");
                            total += outing.EventCost;
                        }
                        Console.WriteLine($"\nTotal cost for all bowling events :\t\t\t ${total.ToString("#,#")}\n");
                        break;
                    case "2": //Golf
                        var golfList = ListByCategory("2");
                        Console.WriteLine("\t\t\t\tCOST PER");
                        Console.WriteLine("DATE\t\tEVENT TYPE\t PERSON\t\tATTENDANCE\tTOTAL COST\n\n");
                        foreach (var outing in golfList) {

                            Console.WriteLine($"{outing.DateOfEvent.ToShortDateString()}\t{outing.TypeOfOuting}\t\t" +
                        $"${outing.CostPerPerson.ToString("#,#")}\t\t{outing.Attendance}\t\t${outing.EventCost.ToString("#,#")}");
                            total += outing.EventCost;
                        }
                        Console.WriteLine($"\nTotal cost for all golf events :   \t\t        ${total.ToString("#,#")}\n");
                        break;
                    case "3": //Theme Park
                        var themeParkList = ListByCategory("3");
                        Console.WriteLine("\t\t\t\tCOST PER");
                        Console.WriteLine("DATE\t\tEVENT TYPE\t PERSON\t\tATTENDANCE\tTOTAL COST\n\n");
                        foreach (var outing in themeParkList) {

                            Console.WriteLine($"{outing.DateOfEvent.ToShortDateString()}\t{outing.TypeOfOuting}\t" +
                        $"${outing.CostPerPerson.ToString("#,#")}\t\t{outing.Attendance}\t\t${outing.EventCost.ToString("#,#")}");
                            total += outing.EventCost;
                        }
                        Console.WriteLine($"\nTotal cost for all bowling events: \t\t          ${total.ToString("#,#")}\n");
                        break;
                    case "4": //Concert
                        var concertList = ListByCategory("4");
                        Console.WriteLine("\t\t\t\tCOST PER");
                        Console.WriteLine("DATE\t\tEVENT TYPE\t PERSON\t\tATTENDANCE\tTOTAL COST\n\n");
                        foreach (var outing in concertList) {

                            Console.WriteLine($"{outing.DateOfEvent.ToShortDateString()}\t{outing.TypeOfOuting}\t\t" +
                         $" ${outing.CostPerPerson.ToString("#,#")}\t\t{outing.Attendance}\t\t${outing.EventCost.ToString("#,#")}");
                            total += outing.EventCost;
                        }
                        Console.WriteLine($"\nTotal cost for all bowling events : \t\t        ${total.ToString("#,#")}\n");
                        break;
                    case "5": //Return
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please make a valid selection");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //Add
        private void AddNewOuting() {
            Console.Clear();
            int type;
            DateTime date = new DateTime(1111, 11, 11);

            do {
                Console.WriteLine("Enter the category index number of the type");
                Console.WriteLine("1.  Theme Park\n2.  Bowling\n3.  Concert\n4.  Golf");
                type = TryParse(Console.ReadLine());

                if (type < 1 || type > 4) { Console.WriteLine("Please choose a number 1-4"); }
            } while (type < 1 || type > 4);
            Console.WriteLine("When did this event take place?  Please enter the four digit year. ex(2020)");
            int year = TryParse(Console.ReadLine());
            Console.WriteLine("Now enter the two digit month.  ex (01 for January)");
            int month = TryParse(Console.ReadLine());
            Console.WriteLine("Now enter the two digit day. ex (11)");
            int day = TryParse(Console.ReadLine());
            Console.WriteLine("How many people attended the event?");
            int attendance = TryParse(Console.ReadLine());
            Console.WriteLine("What was the cost per person?");
            decimal cost = TryParseDec(Console.ReadLine());
            try {
                date = new DateTime(year, month, day); //try.catch for invalid day month or year
            } catch (Exception badDate) {
                Console.WriteLine($"The date you entered({month}/{day}/{year}) is invalid and will not be added.  Default date is 11/11/1111.\n" +
                    $"You can edit this outing from the main menu later.");
            }
            var newOuting = new Outings(attendance, date, cost, (OutingType)type);
            _repo.AddListingToList(newOuting);

        }

        //Edit
        private void EditOuting() {
            int index = 1;
            var list = _repo.ListOfOutings();
            Console.WriteLine("  \t\t\t\tCOST PER");
            Console.WriteLine("  DATE\t\tEVENT TYPE\t PERSON\t\tTOTAL COST\n\n");
            foreach (var outing in list) {
                Console.Write(index + "  ");
                if (outing.TypeOfOuting == OutingType.Theme_Park) {
                    Console.WriteLine($"{outing.DateOfEvent.ToShortDateString()}\t{outing.TypeOfOuting}\t" +
                        $"${outing.CostPerPerson.ToString("#,#")}\t\t${outing.EventCost.ToString("#,#")}");
                    index++;
                }
                else {
                    Console.WriteLine($"{outing.DateOfEvent.ToShortDateString()}\t{outing.TypeOfOuting}\t\t" +
                        $"${outing.CostPerPerson.ToString("#,#")}\t\t${outing.EventCost.ToString("#,#")}");
                    index++;
                }
            }
            Console.WriteLine("Do you wish to edit one of these outings?");
            if (!YesOrNO(Console.ReadLine())) { return; }
            Console.WriteLine("Enter the index number of the event you wish to edit");
            int choice = TryParse(Console.ReadLine());
            while (choice > list.Count) {
                Console.WriteLine("Please choose a valid index number");
                choice = TryParse(Console.ReadLine());
            }
            var outingToEdit = list.ElementAt(choice - 1);
            Console.Clear();
            Console.WriteLine("\t\t\t\tCOST PER");
            Console.WriteLine("DATE\t\tEVENT TYPE\t PERSON\t\tATTENDANCE\tTOTAL COST\n\n");
            Console.WriteLine($"{outingToEdit.DateOfEvent.ToShortDateString()}\t{outingToEdit.TypeOfOuting}\t" +
                        $"\t${outingToEdit.CostPerPerson.ToString("#,#")}\t\t{outingToEdit.Attendance}\t\t${outingToEdit.EventCost.ToString("#,#")}");

            int type;
            int year = outingToEdit.DateOfEvent.Year;
            int month = outingToEdit.DateOfEvent.Month;
            int day = outingToEdit.DateOfEvent.Day;
            var date = outingToEdit.DateOfEvent;
            var updatedOuting = new Outings();

            int attendance = outingToEdit.Attendance; ;
            decimal cost = outingToEdit.CostPerPerson; ;
            OutingType newType = outingToEdit.TypeOfOuting;

            Console.WriteLine($"Was this event canceled?  Choose 'y' to remove all evidence that this event was ever planned");
            if (YesOrNO(Console.ReadLine())) {
                if (_repo.DeleteOuting(outingToEdit)) {
                    Console.WriteLine("Event has been removed");
                }
                else { Console.WriteLine("Failed to remove event.  So sorry!"); }
                return;
            }
            Console.WriteLine("Do you wish to edit the date?");
            if (YesOrNO(Console.ReadLine())) {
                Console.WriteLine("When did this event take place?  Please enter the four digit year. ex(2020)");
                year = TryParse(Console.ReadLine());
                Console.WriteLine("Now enter the two digit month.  ex (01 for January)");
                month = TryParse(Console.ReadLine());
                Console.WriteLine("Now enter the two digit day. ex (11)");
                day = TryParse(Console.ReadLine());
                try {
                    date = new DateTime(year, month, day); //try.catch for invalid month or year
                } catch (Exception badDate) {
                    Console.WriteLine($"The date you entered({month}/{day}/{year}) is invalid and will not be updated at this time");
                }
                Console.WriteLine("Do you wish to edit the attendance?");
                if (YesOrNO(Console.ReadLine())) {
                    Console.WriteLine("What was the actual attendance?");
                    attendance = TryParse(Console.ReadLine());
                }
                Console.WriteLine("Do you need to change the cost per person at this time?");
                if (YesOrNO(Console.ReadLine())) {
                    Console.WriteLine("What was the actual cost per person?");
                    cost = TryParseDec(Console.ReadLine());
                }
                Console.WriteLine($"Event was originally booked as {outingToEdit.TypeOfOuting}.  Do you need to change this?");
                if (YesOrNO(Console.ReadLine())) {
                    do {
                        Console.WriteLine("Enter the category index number of the type");
                        Console.WriteLine("1.  Theme Park\n2.  Bowling\n3.  Concert\n4.  Golf");
                        type = TryParse(Console.ReadLine());
                        newType = (OutingType)type;
                        if (type < 1 || type > 4) { Console.WriteLine("Please choose a number 1-4"); }
                    } while (type < 1 || type > 4);
                }

                updatedOuting = new Outings(attendance, date, cost, newType);
                _repo.UpdateOuting(outingToEdit, updatedOuting);
                return;
            }
        }
        //Helper Methods
        //View by category
        private List<Outings> ListByCategory(string choice) {
            var tempList = new List<Outings>();
            var list = _repo.ListOfOutings();
            switch (choice) {
                case "1":
                    foreach (var outing in list) {
                        if (outing.TypeOfOuting == OutingType.Bowling) {
                            tempList.Add(outing);
                        }
                    }
                    break;
                case "2":
                    foreach (var outing in list) {
                        if (outing.TypeOfOuting == OutingType.Golf) {
                            tempList.Add(outing);
                        }
                    }
                    break;
                case "3":
                    foreach (var outing in list) {
                        if (outing.TypeOfOuting == OutingType.Theme_Park) {
                            tempList.Add(outing);
                        }
                    }
                    break;
                case "4":
                    foreach (var outing in list) {
                        if (outing.TypeOfOuting == OutingType.Concert) {
                            tempList.Add(outing);
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Sorry there was problem.  Please try again!");
                    break;
            }
            return tempList;
        }

        private List<Outings> ListOfOutingsByDate() {
            var list = _repo.ListOfOutings();
            list.Sort((a, b) => a.DateOfEvent.CompareTo(b.DateOfEvent));
            return list;
        }

        //Parse
        private int TryParse(string number) {

            int.TryParse(number, out int k);
            while (k <= 0) {
                Console.WriteLine("Please enter a valid number");
                number = Console.ReadLine();
                int.TryParse(number, out k);
            }
            return k;
        }
        private decimal TryParseDec(string number) {
            decimal.TryParse(number, out decimal k);
            while (k <= 0) {
                Console.WriteLine("Please enter a valid number");
                number = Console.ReadLine();
                decimal.TryParse(number, out k);
            }
            return k;
        }
        //Yes/No
        private bool YesOrNO(string yn) {
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

        //Seed
        private void Seed() {
            Outings _seedOuting = new Outings(25, new DateTime(2020, 10, 31), 25.25m, OutingType.Bowling); //rounding issue
            Outings _seedOuting2 = new Outings(150, new DateTime(2020, 12, 31), 150, (OutingType)3);
            Outings _seedOuting3 = new Outings(50, new DateTime(2020, 10, 8), 1000, OutingType.Golf);
            Outings _seedOuting4 = new Outings(5, new DateTime(2020, 1, 1), 28, (OutingType)2);
            Outings _seedOuting5 = new Outings(25, new DateTime(2020, 2, 14), 25, OutingType.Bowling);
            Outings _seedOuting6 = new Outings(5, new DateTime(2020, 5, 5), 150, (OutingType)1);
            _repo.AddListingToList(_seedOuting, _seedOuting6, _seedOuting5, _seedOuting4, _seedOuting3, _seedOuting2);
        }
    }
}
