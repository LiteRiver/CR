using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace CR.Metro2.Tests {
    [TestClass]
    public class TrailerSegmentTest {
        [TestMethod]
        public void TestLength() {
            var seg = new TrailerSegment();
            Assert.AreEqual(1430, seg.Length);
        }

        [TestMethod]
        public void TestReadFrom() {
            var line = "1430TRAILER000000187         000000000000000000000000000000000000000000000000000000000000183000000004000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000053000000053000000000000000000000000186000000186000000000000000000000000184                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               ";

            var seg = new TrailerSegment();

            seg.Parse(line);

            Assert.AreEqual("TRAILER", seg["Record Identifier"], "Record Identifier");
            Assert.AreEqual((long)187, seg["Total Base Records"], "Total Base Records");
            Assert.AreEqual((long)184, seg["Total Telephone Numbers (All Segments)"], "Total Telephone Numbers (All Segments)");
            Assert.AreEqual("", seg["N1"], "N1");

            Assert.AreEqual(line, seg.ToString());
        }
    }
}
