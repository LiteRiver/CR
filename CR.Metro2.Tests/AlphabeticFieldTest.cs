using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CR.Metro2.Tests {
    [TestClass]
    public class AlphabeticFieldTest {
        [TestMethod]
        public void TestFormat() {

            var f = new AlphabeticField("AlphabeticField", 6);

            Assert.AreEqual("      ", f.Format(""));
        }
    }
}
