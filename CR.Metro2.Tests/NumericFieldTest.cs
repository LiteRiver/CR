using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CR.Metro2.Tests {
    [TestClass]
    public class NumericFieldTest {
        [TestMethod]
        public void TestFormat() {
            var f = new NumericField("NumericField", 5);

            Assert.ThrowsException<ArgumentException>(() => f.Format(-1));
            Assert.AreEqual(f.Format(9), "00009");
            
        }

        [TestMethod]
        public void TestParse() {
            var f = new NumericField("NumericField", 5);

            Assert.AreEqual(f.Parse("00009"), (long)9);
            Assert.ThrowsException<ArgumentException>(() => f.Parse("asdf"));
            Assert.ThrowsException<ArgumentException>(() => f.Parse(""));
        }
    }
}
