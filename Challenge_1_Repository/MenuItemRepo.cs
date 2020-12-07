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

        public void SeeItemDetails() {
            int selection = TryParseAllowZeroReturn(Console.ReadLine());
            string selectionString = selection.ToString();
            if (_MenuItemsDictionary.TryGetValue(selectionString, out MenuItem x)) {

                Console.Write($"Name: \t\t{ x.Name}\n" +
                                  $"Description:  \t{x.Description}\n" +
                                  $"Ingredients:  \n");
                foreach (var item in x.Ingredients) {
                    Console.Write($"  {item}\n");
                }
            }
        }
        //Update

        public void EditMenuItem() {  // same code as SeeDetails
            int selection = TryParseAllowZeroReturn(Console.ReadLine());
            string selectionString = selection.ToString();
            if (_MenuItemsDictionary.TryGetValue(selectionString, out MenuItem x)) {

                Console.Write($"Name: \t\t{ x.Name}\n" +
                                  $"Description:  \t{x.Description}\n" +
                                  $"Ingredients:  \n");
                foreach (var item in x.Ingredients) {
                    Console.Write($"  {item}\n");
                }
            }
            var tempItem = new MenuItem();
            Console.WriteLine("Would you like to change the name?");
            if (YesOrNO()) {
                Console.WriteLine("What is the new name?");
                tempItem.Name = Console.ReadLine();
                x.Name = tempItem.Name;
            }
            Console.WriteLine($"Would you like to write a new description for {tempItem.Name}?");
            if (YesOrNO()) {
                Console.WriteLine($"Please enter the new description for {tempItem.Name}");
                tempItem.Description = Console.ReadLine();
                x.Description = tempItem.Description;
            }
            Console.WriteLine($"Would you like to change the price for {tempItem.Name} at this time?");
            if (YesOrNO()) {
                Console.WriteLine($"What is the menu price for {tempItem.Name}? ex. (9.99)");
                double price = TryParse(Console.ReadLine());
                tempItem.Price = price;
                x.Price = tempItem.Price;
            }
         
            Console.WriteLine($"Would you like to remove items from the current list of ingredients?");
            if (YesOrNO()) {
                Console.WriteLine("How many ingredients do you wish to remove?");
                int numOfIngrdients = TryParse();
                for (int i = 0; i < numOfIngrdients; i++) {
                int index = 1;
                    foreach (var item in x.Ingredients) {
                        Console.WriteLine(index + item);
                        index++;

                    }
                    Console.WriteLine("Enter the number next to the ingredient you wish to remove");
                    int remove = TryParse();
                    x.Ingredients.RemoveAt(remove - 1);
                }
            }
            Console.WriteLine($"Would you like to add ingredients at this time?");
            if (YesOrNO()) {
                Console.WriteLine($"How many ingredients would you like add?");
                int numOfIngrdients = TryParse();
                for (int i = 0; i < numOfIngrdients; i++) {
                    Console.WriteLine("What is the next ingredient?");
                    string next = Console.ReadLine();
                    x.Ingredients.Add(next);
                }

            }

        }

        //Helper Methods

        public string DictionaryCounter() {
            string count = (_MenuItemsDictionary.Count + 1).ToString();
            return count;

        }
        public int TryParseAllowZeroReturn(string k) {
            int.TryParse(k, out int l);
            return l;
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
        Bool: string yn = Console.ReadLine();
        do {
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
