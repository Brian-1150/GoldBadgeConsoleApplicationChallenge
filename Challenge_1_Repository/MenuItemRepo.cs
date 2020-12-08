using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1_Repository {
    public class MenuItemRepo {
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
            _MenuItemsDictionary.Add(DictionaryCounter(), newItem); //makes the key 1 higher than current count
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
                Console.Clear();
                Console.Write($"\nName: \t\t{ x.Name}\n" +
                              $"Description:  \t{x.Description}\n" +
                              $"Price:  \t${ x.Price}\n" +
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
                Console.Clear();
                Console.Write($"\nName: \t\t{ x.Name}\n" +
                                  $"Description:  \t{x.Description}\n" +
                                  $"Price:  \t${x.Price}\n" +
                                  $"Ingredients:  \n");
                foreach (var item in x.Ingredients) {
                    Console.Write($"  {item}\n");
                }
            }
            else { return; }  // exits out of current method
            Console.WriteLine("Would you like to change the name?");
            if (YesOrNO()) {
                Console.WriteLine("What is the new name?");
                //tempItem.Name = Console.ReadLine();   //Unnecessary step
                x.Name = Console.ReadLine();  //switch to this style for remaining similar redundencies
            }
            Console.WriteLine($"Would you like to write a new description?");
            if (YesOrNO()) {
                Console.WriteLine($"Please enter the new description.");
                x.Description = Console.ReadLine();
            }
            Console.WriteLine($"Would you like to change the price at this time?");
            if (YesOrNO()) {
                Console.WriteLine($"What is the menu price? ex. (9.99)");
                double price = TryParse(Console.ReadLine());
                x.Price = price;
            }
            if (x.Ingredients.Count > 0) { //if there are no ingredients do not run the next loop
            Console.WriteLine($"Would you like to remove items from the current list of ingredients?");
                if (YesOrNO()) {
                    Console.WriteLine("How many ingredients do you wish to remove?");
                    int numOfIngrdients = TryParse();
                    while (numOfIngrdients > x.Ingredients.Count) {
                        Console.WriteLine("Invalid entry.  Please choose a number less than the total number of ingredients");
                        numOfIngrdients = TryParse();
                    }
                    Console.Clear();
                    for (int i = 0; i < numOfIngrdients; i++) {
                        int index = 1;
                        foreach (var item in x.Ingredients) {
                            Console.WriteLine($"# {index}  {item}");
                            index++;

                        }
                        Console.WriteLine("Enter the number next to the ingredient you wish to remove");
                        int remove = TryParse();
                        if (remove <= x.Ingredients.Count) {
                            x.Ingredients.RemoveAt(remove - 1);

                        }
                        else {

                            while (remove > x.Ingredients.Count) {
                                Console.WriteLine("Invalid entry.  Please enter a number corresponding to the list above");
                                remove = TryParse();
                            }
                            x.Ingredients.RemoveAt(remove - 1);
                        }
                    }
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
        //Delete
        public void Remove() {
            int selection = TryParseAllowZeroReturn(Console.ReadLine());
            string selectionString = selection.ToString();
            if (_MenuItemsDictionary.TryGetValue(selectionString, out MenuItem x)) {

                Console.Write($"\nName: \t\t{ x.Name}\n" +
                                  $"Description:  \t{x.Description}\n" +
                                  $"Price:  \t${x.Price}\n" +
                                  $"Ingredients:  \n");
                foreach (var item in x.Ingredients) {
                    Console.Write($"  {item}\n");
                }
                Console.WriteLine($"Are you sure you wish to permanently remove {x.Name} from the menu?");
                if (YesOrNO()) {
                    _MenuItemsDictionary.Remove(selectionString);

                    //if removed item was last on list then we are done, hence return;
                    if (TryParseAllowZeroReturn(selectionString) == _MenuItemsDictionary.Count+1) { return; } 

                    //else replace removed item key with last item in list value then delete that last item in list to give us a freshly ordered item list
                    int count = _MenuItemsDictionary.Count + 1;                  
                    _MenuItemsDictionary.Add(selection.ToString(), _MenuItemsDictionary[count.ToString()]);
                    _MenuItemsDictionary.Remove(count.ToString());
                }
            }
        }

        //Helper Methods
        //To establish key for new items
        public string DictionaryCounter() { 
            string count = (_MenuItemsDictionary.Count + 1).ToString();
            return count;

        }
        //Frequently used code
        public int TryParseAllowZeroReturn(string k) {
            int.TryParse(k, out int l);
            return l;
        }
        //Like above but does not allow "0" to be returned
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
        //Overload for double
        public double TryParse(string dub) {
            double.TryParse(dub, out double d);
            while (d <= 0) {
                Console.WriteLine("Please enter a valid number without $ ex (9.99): ");
                dub = Console.ReadLine();
                double.TryParse(dub, out d);
            }
            return d;
        }
        //frequently used code
        public bool YesOrNO() {
        Bool:
            string yn = Console.ReadLine();
            do {
                if (yn.ToLower() == "y") {
                    return true;
                }
                else if (yn.ToLower() == "n") {
                    return false;
                }
                else {
                    Console.WriteLine("Please enter a 'y' or 'n'");

                    goto Bool; //goto and label scheme because bool was saying not all paths return value(even though it should because it is in a do while loop
                }

            } while (yn != "y" && yn != "n");
        }
    }
}
