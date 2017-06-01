using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace CR.Metro2.Tests {
    [TestClass]
    public class BaseSegmentTest {
        [TestMethod]
        public void TestLength() {
            var seg = new BaseSegment();
            Assert.AreEqual(seg.Length, 1430);
        }

        [TestMethod]
        public void TestReadFrom() {
            var line = "14301052220171239520WESTBON2636370        22705                         I0003262017000000000000017800045M00000047200000000011 0BBBBBBBBBBBBBBBBBBBBBBB    00001747200000000000000000005222017000000000000000004262017F                1ZHAO                     ZIXI                                     0000000000424199720633070661  US688 110TH AVENUE NORTHEAST      APT S1204                       BELLEVUE            WA98004     RJ1                                                                                                  J2                                                                                                                                                                                                      J2                                                                                                                                                                                                      J2                                                                                                                                                                                                      K2                                K3                                      K4                            L1                                                    N1                                                                                                                                                ";

            var seg = new BaseSegment();

            seg.Parse(line);

            Assert.AreEqual("WESTBON2636370", seg["Identification Number"], "Identification Number");
            Assert.AreEqual("22705", seg["Consumer Account Number"], "Consumer Account Number");
            Assert.AreEqual(new DateTime(2017, 3, 26), seg["Date Opened"], "Date Opened");
            Assert.AreEqual("0BBBBBBBBBBBBBBBBBBBBBBB", seg["Payment History Profile"], "Payment History Profile");
            Assert.AreEqual("WA", seg["State"], "State");
            Assert.AreEqual("N1", seg["N1"], "N1");

            Assert.AreEqual(line, seg.ToString());
        }
    }
}
