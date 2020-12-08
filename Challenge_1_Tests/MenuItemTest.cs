using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Challenge_1_Repository;
using System.Collections.Generic;

namespace Challenge_1_Tests {
    [TestClass]
    public class MenuItemTest {

        private MenuItem _menuItem;
        private MenuItemRepo _repo = new MenuItemRepo();

        [TestInitialize]
        public void Arrange() {

            _menuItem = new MenuItem("Chicken Parm", "Breaded Chicken with side of spaghetti, topped with sauce and cheese", new List<string>() { "bread", "cheese" }, 9.99);
            _repo._MenuItemsDictionary.Add("5", _menuItem);


        }
        [TestMethod]
        public void AddNewItemToDictionary_NotNull() {
            //Arrange
            MenuItem item = new MenuItem();
            item.Name = "Salad";

            _repo._MenuItemsDictionary.Add("6", item);

            //MenuItem itemFromDictionary = _repo.





        }
    }
}

        //Assert
        //Act