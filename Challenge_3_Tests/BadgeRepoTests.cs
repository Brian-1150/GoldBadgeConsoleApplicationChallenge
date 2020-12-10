using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Challenge_3_Repository;
using System.Collections.Generic;

namespace Challenge_3_Tests {
    [TestClass]
    public class BadgeRepoTests {
        private Badges _seedBadge = new Badges(1001, new List<string>() { "A1", "A2", "A5" });
        Badges _seedBadge2 = new Badges(1002, new List<string>() { "A1", "A2", "A9" });
        private BadgesRepo _badgeRepo = new BadgesRepo();
        
        
        [TestInitialize]
        public void Arrange() {

            
            _badgeRepo.CreateNewBadge(_seedBadge.BadgeID, _seedBadge);
            _badgeRepo.CreateNewBadge(1002, _seedBadge2);  
        }

        //View Method
        [TestMethod]
        public void ViewBadges() {
            //Arrange
              //see test initialize for arrangement
            //Act
           var x = _badgeRepo.DisplayListOfBadges();

            //Assert
            Assert.IsNotNull(x);

        }
        [TestMethod]
        public void ViewDoors() {
            //Arrange

            //Act
            var x = _badgeRepo.ListOfDoors();
            int count = x.Count;
            //Assert
            Assert.AreEqual(count, 9); //Private list in repo has 9 doors
        }

        [TestMethod]
        public void CreateNewBadge() {
            //Arrange
            int count = _badgeRepo.DisplayListOfBadges().Count;
            var testNewBadge = new Badges();
            testNewBadge.BadgeID = 45;
            testNewBadge.EmployeeName = "Joe";
            testNewBadge.HasAccessTo = new List<string>(){ "B2"};
            //Act
            _badgeRepo.CreateNewBadge(testNewBadge.BadgeID, testNewBadge);
            //Assert
            Assert.AreNotEqual(count, _badgeRepo.DisplayListOfBadges().Count); //because count should be 1 higher after successful add
        }

        [TestMethod]
        public void AddDoors() {

            //Arrange
            Badges josh = new Badges(1003, "Josh", new List<string>() { "A1", "A2", "A3", "A4", "A5" });
            _badgeRepo.CreateNewBadge(1003, josh);  //Create new badge and add to repo 
            //Act
            _badgeRepo.AddDoorsToBadge(1003, new List<string>() { "A9" }); //add door A9
            
            //Assert
            Assert.IsTrue(josh.HasAccessTo.Contains("A9")); //confirm A9 was indeed added
        }
        [TestMethod]
        public void RemoveDoors() {
            //Arrange
            var removedDoors = new List<string>() { "A1" };
            //Act
            _badgeRepo.RemoveDoorsFromBadge(1001, removedDoors);
            //Assert
            Assert.IsFalse(_seedBadge.HasAccessTo.Contains("A1"));
        }
        [TestMethod]
        public void DectivateBadge() {

            //Arrange

            //Act
            _badgeRepo.DeactivateBadge(_seedBadge.BadgeID);
            _badgeRepo.DeactivateBadge(1002);
            //Assert
            Assert.AreEqual(_seedBadge.EmployeeName, "DEACTIVATED"); // name should change to DEACTIVATED
            Assert.IsTrue(_seedBadge2.HasAccessTo.Count == 0);  //door access list should be empty
        }
        [TestMethod]
        public void HelperMethods() {

            //Arrange
            _seedBadge2.EmployeeName = "Joe";
            //Act
            var x =_badgeRepo.GetBadgeByKey(1002);
            var y = _badgeRepo.GetBadgeByKey(102);
            //Assert
            Assert.AreEqual(x.EmployeeName, "Joe");
            Assert.IsNull(y);
        }
    }
}
