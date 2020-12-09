using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Challenge_2_Repository;

namespace Challenge_2_Tests {
    [TestClass]
    public class UnitTest1 {

        



        


        [TestInitialize]
        public void Arrange() {
            //Arrange
            ClaimsRepo _repo = new ClaimsRepo();
            Claims _claimsObject = new Claims();
            Claims seedClaim1 = new Claims(1, "Auto", "Crash", 500, new DateTime(2020, 12, 12), new DateTime(2020, 12, 25), true);
            Claims seedClaim2 = new Claims(2, "Home", "A silly roofer was jumping up and down and crashed into my living room", 8000, new DateTime(2020, 10, 8), new DateTime(2020, 12, 7), true);

        }

        [TestMethod]
        public void DisplayQueue() {

        }





            //Act

            //Assert



    }
}
