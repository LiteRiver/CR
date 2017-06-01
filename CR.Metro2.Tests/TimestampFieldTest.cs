using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CR.Metro2.Tests {
    [TestClass]
    public class TimestampFieldTest {
        [TestMethod]
        public void TestFormat() {
            var dt = new DateTime(2017, 05, 28, 11, 22, 55);
            var f = new TimestampField("TimestampField");

            Assert.AreEqual("00000000000000", f.Format(null));
            Assert.AreEqual("05282017112255", f.Format(dt));
        }

        [TestMethod]
        public void TestParse() {
            var dt = new DateTime(2017, 05, 28, 11, 22, 55);
            var f = new TimestampField("TimestampField");

            Assert.AreEqual(null, f.Parse("00000000000000"));
            Assert.AreEqual(dt, f.Parse("05282017112255"));
        }
    }
}
