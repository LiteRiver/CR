using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CR.Metro2.Tests {
    [TestClass]
    public class DateFieldTest {
        [TestMethod]
        public void TestFormat() {
            var dt = new DateTime(2017, 05, 28);
            var f = new DateField("DateField");

            Assert.AreEqual("00000000", f.Format(null));
            Assert.AreEqual("05282017", f.Format(dt));
        }

        [TestMethod]
        public void TestParse() {
            var dt = new DateTime(2017, 05, 28);
            var f = new DateField("DateField");

            Assert.AreEqual(null, f.Parse("00000000"));
            Assert.AreEqual(dt, f.Parse("05282017"));
        }
    }
}
