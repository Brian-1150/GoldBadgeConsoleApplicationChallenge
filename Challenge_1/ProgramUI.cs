using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge_1_Repository;

namespace Challenge_1_Console {
    class ProgramUI {
            private MenuItemRepo _menuItemRepo = new MenuItemRepo();
            
        public void Run() {
            //Seed
            Seed();
            //Menu
            Menu();
        }

        //Main Menu
        private void Menu() {

            bool exit = false; //Why do I have to assign false since default bool should be false
            do {
                //Display Menu
                Console.WriteLine("Select an option:  \n" +
                    " 1.  View Menu\n" +
                    " 2.  Add a Menu Item\n" +
                    " 3.  Edit a Menu Item\n" +
                    " 4.  Delete a Menu Item\n" +
                    " 5.  .........\n" +
                   
                    "10.  Exit");

                //Get User Input
                string input = Console.ReadLine();

                //Read Input and Invoke Appropriate Method(s)
                switch (input) {
                    case "1": //View
                        ViewMenuItems();
                        break;
                    case "2":  //Add
                       
                        break;
                    case "3": //Edit
                        
                        break;
                    case "4": //Delete
                       
                        break;
                    case "5":  //???
                        
                        break;
                    case "6": //???                                            
                       
                        break;
                   
                    case "10": //Exit
                        Console.WriteLine("Have a great rest of your day!");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number 1-10");
                        break;
                }
                Console.WriteLine("Please press any key to continue..."); //just to pause and let user know he is in control of proceeding
                Console.ReadKey();

                Console.Clear(); // clears the console window to remove all the previous menues etc..

            } while (exit == false);


        }

        // View all menu items
        private void ViewMenuItems() {
            Console.Clear();
            _menuItemRepo.Display();
            Console.WriteLine("\nSelect a number to see details for that item.  Any other entry to return to main menu");
            _menuItemRepo.SeeItemDetails();
        }

        
        
        
        
        
        
        
        
        
        
        //Seed Method
        private void Seed() {
            MenuItem chkParm = new MenuItem("Chicken Parm", "Breaded Chicken with side of spaghetti, topped with sauce and cheese", new List<string>() { "bread", "cheese" }, 9.99);
            _menuItemRepo._MenuItemsDictionary.Add("1", chkParm);
        }
    }
}
