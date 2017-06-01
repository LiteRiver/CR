using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CR.Metro2.Tests {
    [TestClass]
    public class MonetaryFieldTest {
        [TestMethod]
        public void TestFormat() {
            var f = new MonetaryField("Monetary Field");

            Assert.ThrowsException<ArgumentException>(() => f.Format(-1));
            Assert.AreEqual(f.Format(9), "000000009");
            Assert.AreEqual(f.Format(1000000000), "999999999");
            Assert.AreEqual(f.Format(99999999999999), "999999999");
        }

        [TestMethod]
        public void TestParse() {
            var f = new MonetaryField("Monetary Field");

            Assert.AreEqual(f.Parse("000000009"), (long)9);
            Assert.ThrowsException<ArgumentException>(() => f.Parse("asdf"));
            Assert.ThrowsException<ArgumentException>(() => f.Parse(""));
        }
    }
}
