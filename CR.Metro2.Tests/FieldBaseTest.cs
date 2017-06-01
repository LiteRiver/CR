using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CR.Metro2.Tests {
    class MockFieldBase : FieldBase {
        public MockFieldBase(string name, int len) : base(name, len) {
        }

        public override string Format(object val) {
            throw new NotImplementedException();
        }

        protected override object ParseCore(string val) {
            return val;
        }
    }

    [TestClass]
    public class FieldBaseTest {
        [TestMethod]
        public void TestCtor() {
            Assert.ThrowsException<ArgumentException>(() => new MockFieldBase(null, 1));
            Assert.ThrowsException<ArgumentException>(() => new MockFieldBase(null, -1));
            Assert.ThrowsException<ArgumentException>(() => new MockFieldBase("", 1));
            Assert.ThrowsException<ArgumentException>(() => new MockFieldBase("", -1));
            Assert.ThrowsException<ArgumentException>(() => new MockFieldBase("MockFieldBase", 0));
            Assert.ThrowsException<ArgumentException>(() => new MockFieldBase("MockFieldBase", -1));
            Assert.IsNotNull(new MockFieldBase("MockFieldBase", 1));
        }

        [TestMethod]
        public void TestParse() {
            var f = new MockFieldBase("MockFieldBase", 5);

            Assert.ThrowsException<ArgumentException>(() => f.Parse("ss"));
            Assert.ThrowsException<ArgumentException>(() => f.Parse("ssssss"));
            Assert.AreEqual(f.Parse("sssss"), "sssss");
        }
    }
}
