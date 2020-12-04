using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1_Repository {
    public class MenuItemRepo {
        private MenuItem _accessToMenuItemPoco = new MenuItem();
        public List<MenuItem> _MenuItemsList = new List<MenuItem>();
        public Dictionary<string, MenuItem> _MenuItemsDictionary = new Dictionary<string, MenuItem>();

        //Create
        public void CreateNewMenuItem() {
            string item;
            string description;
            string priceAsString;
            List<string> ingredients = new List<string>();
            Console.WriteLine("What is the name of the new item?");
            item = Console.ReadLine();

            Console.WriteLine("Provide a brief description:");
            description = Console.ReadLine();

            Console.WriteLine("What is the menu price of the item? ex. (9.99)");
            priceAsString = Console.ReadLine();
            double price = TryParse(priceAsString);

            Console.WriteLine("Would you like to add ingredients at this time? y/n");
            if (YesOrNO()) {
                Console.WriteLine($"How many ingredients would you like to list for {item}?");
                int numOfIngrdients = TryParse();
                for (int i = 0; i < numOfIngrdients; i++) {
                    Console.WriteLine("What is the next ingredient?");
                    string next = Console.ReadLine();
                    ingredients.Add(next);
                }

            }
            MenuItem newItem = new MenuItem(item, description, ingredients, price);
            _MenuItemsDictionary.Add(DictionaryCounter(), newItem);
        }

        //Read
       public void Display() {
            foreach (KeyValuePair<string, MenuItem> kvp in _MenuItemsDictionary) {
                Console.WriteLine($"#:  {kvp.Key}  {kvp.Value.Name}");
            }
        }

        //Helper Methods

        public string DictionaryCounter() {
            string count = _MenuItemsDictionary.Count.ToString();
            return count;

        }

        public int TryParse() {
            string number = Console.ReadLine();
            int.TryParse(number, out int k);
            while (k <= 0) {
                Console.WriteLine("Please enter a valid positive integer");
                number = Console.ReadLine();
                int.TryParse(number, out k);
            }
            return k;

        }
        public double TryParse(string dub) {
            double.TryParse(dub, out double d);
            while (d <= 0) {
                Console.WriteLine("Please enter a valid number without $ ex (9.99): ");
                dub = Console.ReadLine();
                double.TryParse(dub, out d);
            }
            return d;
        }

        public bool YesOrNO() {
            string yn = Console.ReadLine();
        Bool: do {
                if (yn.ToLower() == "y") {
                    return true;
                }
                else if (yn.ToLower() == "n") {
                    return false;

                }
                else {
                    Console.WriteLine("Please enter a 'y' or 'n'");
                    goto Bool;
                }

            } while (yn != "y" && yn != "n");
        }
    }
}
