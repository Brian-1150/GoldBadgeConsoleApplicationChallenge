using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Challenge_3_Repository;
using System.Collections.Generic;

namespace Challenge_3_Tests {
    [TestClass]
    public class BadgeRepoTests {
        private Badges _badges;
        private BadgesRepo _badgeRepo = new BadgesRepo();

        [TestInitialize]
        public void Arrange() {

            Badges seedBadge = new Badges(1001, new List<string>() { "A1", "A2", "A5" });
            _badgeRepo.CreateNewBadge(seedBadge.BadgeID, seedBadge);
            Assert.AreEqual(seedBadge.BadgeID, 1001);  
        }

        //View Method
        [TestMethod]
        public void View() {
            //Arrange
            _badgeRepo.DisplayListOfBadges();

            //Act

            //Assert
            

        }
    }
}
