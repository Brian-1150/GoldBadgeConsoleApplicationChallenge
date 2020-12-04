using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Challenge_1_Repository;
using System.Collections.Generic;

namespace Challenge_1_Tests {
    [TestClass]
    public class MenuItemTest {

        private MenuItem _menuItem;
        private MenuItemRepo _repo;


        [TestMethod]
        public void Arrange() {
       
            _menuItem = new MenuItem("Chicken Parm", "Breaded Chicken with side of spaghetti, topped with sauce and cheese", new List<string>(){ "bread", "cheese" }, 9.99);
            _repo.Display();
        }
    }
}
