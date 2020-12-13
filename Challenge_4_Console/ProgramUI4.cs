using System;
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

        public void Menu() {
            bool exit = false;
            while (exit == false) {
                Console.WriteLine("   ****Main Menu****\n" +
                                  "Please make a selection\n" +
                                  "1.  View Outings\n" +
                                  "2.  View Outings by Category\n" +
                                  "3.  Add a New Outing\n" +
                                  "4.  See Costs for Outings\n" +
                                  "5.  Edit Detials for an Outing\n" +
                                  "6.  Exit\n");
                string input = Console.ReadLine();
                switch (input) {
                    case "1": //View
                        ViewAllOutings();
                        break;
                    case "2": //View by type
                        ViewOutingsByDate();
                        break;
                    case "6": //Exit
                        Console.WriteLine("Have a great day!");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please make a valid selection");
                        break;
                }
            }
        }

        public void ViewAllOutings() {
            var list = _repo.ListOfOutings();
            Console.WriteLine("\t\t\t\tCOST PER");
            Console.WriteLine("DATE\t\tEVENT TYPE\t PERSON\t\tTOTAL COST\n\n");
            foreach (var outing in list) {
                if (outing.TypeOfOuting == OutingType.Theme_Park) {
                    Console.WriteLine($"{outing.DateOfEvent.ToShortDateString()}\t{outing.TypeOfOuting}\t" +
                        $"${outing.CostPerPerson.ToString("#,#")}\t\t${outing.EventCost.ToString("#,#")}");
                }
                else {
                    Console.WriteLine($"{outing.DateOfEvent.ToShortDateString()}\t{outing.TypeOfOuting}\t\t" +
                        $"${outing.CostPerPerson.ToString("#,#")}\t\t${outing.EventCost.ToString("#,#")}");
                }
            }
            Console.WriteLine("\nWould you like to refine resuts by category? y/n");
            if (!YesOrNO(Console.ReadLine())) { return; }

            

        }

        public void ViewOutingsByDate() {
            var list = ListOfOutingsByDate();
            Console.WriteLine("\t\t\t\tCOST PER");
            Console.WriteLine("DATE\t\tEVENT TYPE\t PERSON\t\tTOTAL COST\n\n");
            foreach (var outing in list) {
                if (outing.TypeOfOuting == OutingType.Theme_Park) {
                    Console.WriteLine($"{outing.DateOfEvent.ToShortDateString()}\t{outing.TypeOfOuting}\t" +
                        $"${outing.CostPerPerson.ToString("#,#")}\t\t${outing.EventCost.ToString("#,#")}");
                }
                else {
                    Console.WriteLine($"{outing.DateOfEvent.ToShortDateString()}\t{outing.TypeOfOuting}\t\t" +
                        $"${outing.CostPerPerson.ToString("#,#")}\t\t${outing.EventCost.ToString("#,#")}");
                }
            }
        }




        //Helper Method
        public List<Outings> ListOfOutingsByDate() {
            var list = _repo.ListOfOutings();
            list.Sort((a, b) => a.DateOfEvent.CompareTo(b.DateOfEvent));
            return list;
            }
        //Parse
        public int TryParse(string number) {

            int.TryParse(number, out int k);
            while (k <= 0) {
                Console.WriteLine("Please enter a valid number");
                number = Console.ReadLine();
                int.TryParse(number, out k);
            }
            return k;
        }
        //Yes/No
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


        //Seed
        private void Seed() {
            Outings _seedOuting = new Outings(25, new DateTime(2020, 10, 31), 25, OutingType.Bowling);
            Outings _seedOuting2 = new Outings(150, new DateTime(2020, 12, 31), 150, (OutingType)3);
            Outings _seedOuting3 = new Outings(50, new DateTime(2020, 10, 8), 1000, OutingType.Golf);
            Outings _seedOuting4 = new Outings(5, new DateTime(2020, 1, 1), 28, (OutingType)2);
            Outings _seedOuting5 = new Outings(25, new DateTime(2020, 2, 14), 25, OutingType.Bowling);
            Outings _seedOuting6 = new Outings(5, new DateTime(2020, 5, 5), 150, (OutingType)1);
            _repo.AddListingToList(_seedOuting, _seedOuting6, _seedOuting5, _seedOuting4, _seedOuting3, _seedOuting2);
    } }
}
