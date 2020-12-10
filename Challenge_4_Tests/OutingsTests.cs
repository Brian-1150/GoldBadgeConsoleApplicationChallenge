using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Challenge_4_Repository;

namespace Challenge_4_Tests {
    [TestClass]
    public class OutingsTests {
        private Outings _seedOuting = new Outings(25, new DateTime(2020, 10, 31), 25, OutingType.Bowling);
        private Outings _seedOuting2 = new Outings(150, new DateTime(2020, 12, 31), 150, (OutingType)3);









        [TestMethod]
        public void TestMethod1() {
        }
    }
}
