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

            bool exit = false; 
            do {
                //Display Menu
                Console.WriteLine("Select an option:  \n" +
                    " 1.  View Menu\n" +
                    " 2.  Add a Menu Item\n" +
                    " 3.  Edit a Menu Item\n" +
                    " 4.  Delete a Menu Item\n" +
                    " 5.  Exit");

                //Get User Input
                string input = Console.ReadLine();

                //Read Input and Invoke Appropriate Method(s)
                switch (input) {
                    case "1": //View
                        ViewMenuItems();
                        break;
                    case "2":  //Add
                        AddToMenu();
                        break;
                    case "3": //Edit
                        EditItem();
                        break;
                    case "4": //Delete
                        RemoveItemFromList();
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

        // View 
        private void ViewMenuItems() {
            Console.Clear();
            _menuItemRepo.Display();
            Console.WriteLine("\nSelect a number to see details for that item.  Any other entry to return to main menu");
            _menuItemRepo.SeeItemDetails();
        }
        //Add
        private void AddToMenu() {
            Console.Clear();
            _menuItemRepo.CreateNewMenuItem();

        }
        //Edit
        private void EditItem() {
            Console.Clear();
            _menuItemRepo.Display();
            Console.WriteLine("\nSelect the number of the item you wish to edit.  Any other entry to return to the main menu");
            
            _menuItemRepo.EditMenuItem();

        }
        //Remove
        private void RemoveItemFromList() {
            Console.Clear();
            _menuItemRepo.Display();
            Console.WriteLine("\nSelect the number of the item you wish to remove from menu.  Any other entry will return you to the main menu");

            _menuItemRepo.Remove();
        }

        //Seed Method
        private void Seed() {
            MenuItem chkParm = new MenuItem("Chicken Parm", "Breaded Chicken with side of spaghetti, topped with sauce and cheese", new List<string>() { "bread", "cheese", "marinaria", "garlic" }, 9.99);
            _menuItemRepo._MenuItemsDictionary.Add("1", chkParm);
        }
    }
}
