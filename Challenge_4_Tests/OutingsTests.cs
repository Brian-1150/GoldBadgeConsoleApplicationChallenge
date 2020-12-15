using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Challenge_4_Repository;

namespace Challenge_4_Tests {
    [TestClass]
    public class OutingsTests {
        private Outings _seedOuting = new Outings(25, new DateTime(2020, 10, 31), 25, OutingType.Bowling);
        private Outings _seedOuting2 = new Outings(150, new DateTime(2020, 12, 31), 150, (OutingType)3);
        private OutingsRepo _repo = new OutingsRepo();

        [TestInitialize]
        public void Arrange() {
            _repo.AddListingToList(_seedOuting2, _seedOuting);
        }


        [TestMethod]
        public void TwoArgumentAdd() {

            //Arrange
            Outings _seedOuting3 = new Outings(50, new DateTime(2020, 12, 25), 1000, OutingType.Golf);
            Outings _seedOuting4 = new Outings(5, new DateTime(2020, 7, 4), 150, (OutingType)1);
            //Act
            _repo.AddListingToList(_seedOuting4, _seedOuting3);
            //Assert
            Assert.IsTrue(_repo.ListOfOutings().Contains(_seedOuting4));
        }
        [TestMethod]
        public void OverloadedAdd() {

            //Arrange
            int count =_repo.ListOfOutings().Count;
            Outings _seedOuting3 = new Outings(50, new DateTime(2020, 10, 8), 1000, OutingType.Golf);
            Outings _seedOuting4 = new Outings(5, new DateTime(2020, 1, 1), 28, (OutingType)2);
            Outings _seedOuting5 = new Outings(25, new DateTime(2020, 2, 14), 25, OutingType.Bowling);
            Outings _seedOuting6 = new Outings(5, new DateTime(2020, 5, 5), 150, (OutingType)1);
            //Act
            _repo.AddListingToList(_seedOuting6, _seedOuting5, _seedOuting4, _seedOuting3);
            //Assert
            Assert.IsTrue(_repo.ListOfOutings().Count > count);
            Assert.AreEqual(_repo.ListOfOutings().Count, 6); //2 seeds plus the array of 4 = 6
        }
        [TestMethod]
        public void Update() {

            //Arrange
            var newOuting = new Outings();
            newOuting.Attendance = 1;
            newOuting.DateOfEvent = new DateTime(2020, 5, 1);
            newOuting.CostPerPerson = 3.5m;
            newOuting.TypeOfOuting = OutingType.Golf;
            var x = _repo.GetOutingByDate(new DateTime(2020, 10, 31));
            //Act
           
            _repo.UpdateOuting(x, newOuting);
           
            //Assert
            Assert.AreEqual(_repo.GetOutingByDate(new DateTime(2020, 5, 1)).CostPerPerson, newOuting.CostPerPerson);
            //the update is only outing to have 3.50 costPerPerson
        }
        [TestMethod]
        public void Delete() {

            //Arrange
            var x = _repo.GetOutingByDate(new DateTime(2020, 10, 31));
            //Act
            bool didItWork= _repo.DeleteOuting(x);
            //Assert
            Assert.IsNull(_repo.GetOutingByDate(new DateTime(2020, 10, 31))); //try to pull same outing after deleted
            Assert.IsTrue(didItWork); //check bool that method returns
        }
        [TestMethod]
        public void ViewList() {

            //Arrange
            //See initialize
            //Act
            var x = _repo.ListOfOutings();
            //Assert
            Assert.IsTrue(x.Count == 2);
        }
        [TestMethod]
        public void TestMethod6() {

            //Arrange

            //Act

            //Assert
        }
        [TestMethod]
        public void TestMethod7() {

            //Arrange

            //Act

            //Assert
        }

    }
}