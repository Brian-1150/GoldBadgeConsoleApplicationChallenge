using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Challenge_5_Repository;
using System.Collections.Generic;
using System.Linq;

namespace Challenge_5_Tests {
    [TestClass]
    public class CustomerTests {
        private Customer _seedCustomer = new Customer(CustomerStatus.Current, "Brian", "Campassi", "317-765-1234", "brian@1150.com");
        private Customer _seedCustomer2 = new Customer((CustomerStatus)2, "Joe", "Johnson", "317-317-3173", "joe@elevenfifty.com");
        private CustomerRepo _repo = new CustomerRepo();

        [TestInitialize]
        public void Arrange() {
            _repo.AddToList(_seedCustomer2, _seedCustomer);
        }






        [TestMethod]
        public void View() {
            //Arrange

            //Act
            var x = _repo.ListOfCustomers("1");
            var y = _repo.ListOfCustomers("2");
            //Assert
            Assert.IsNotNull(x);
            Assert.AreEqual(y.Count, 1);
        }

        [TestMethod]
        public void Add() {

            //Arrange
            Customer _seedCustomer3 = new Customer();
            Customer _seedCustomer4 = new Customer((CustomerStatus)3, "Jack", "Johnson", "377-317-3173", "jj@elevenfifty.com");
            _seedCustomer3.FirstName = "Ellen";
            _seedCustomer3.Email = "ellen@elevenfifty.com";
            //Act
            _repo.AddToList(_seedCustomer4, _seedCustomer3);
            var x = _repo.ListOfCustomers();
            var y = x.ElementAt(2);
            //Assert
            Assert.IsTrue(_repo.ListOfCustomers("4").Count == 4);
            Assert.IsTrue(y.LastName == null);
        }

        [TestMethod]
        public void Delete() {

            //Arrange

            //Act

            //Assert
        }
        [TestMethod]
        public void Update() {

            //Arrange

            //Act

            //Assert
        }
        [TestMethod]
        public void Test() {

            //Arrange

            //Act

            //Assert
        }
    }
}
