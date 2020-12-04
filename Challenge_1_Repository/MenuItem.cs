using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1_Repository {

    public class MenuItem {
        public double Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>();

        public MenuItem() { }

        public MenuItem(string name, string description, List<string> ingredients, double price) {
            Price = price;
            Name = name;
            Description = description;
            Ingredients = ingredients;
        }


    }
}
