using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace CR.Metro2.Tests {
    [TestClass]
    public class HeaderSegmentTest {
        [TestMethod]
        public void TestLength() {
            var seg = new HeaderSegment();
            Assert.AreEqual(seg.Length, 1430);
        }

        [TestMethod]
        public void TestParse() {
            var header = "1430HEADER                      DBOOX          05222017052220170317201103172011WESTBON, INC.                           320 W OHIO STREET,#300,CHICAGO,IL,606540000                                                     8008406604HUTCHINS SYSTEMS, INC.                  9.12                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         ";
            var activeDate = new DateTime(2017, 5, 22);
            var dateCreated = activeDate;
            var programDate = new DateTime(2011, 3, 17);
            var programRevisionDate = programDate;

            var seg = new HeaderSegment();
            seg["Activity Date"] = activeDate;
            seg["Date Created"] = dateCreated;
            seg["Program Date"]= programDate;
            seg["Program Revision Date"]= programRevisionDate;
            seg["Reporter Name"]= "WESTBON, INC.";
            seg["Reporter Address"]= "320 W OHIO STREET,#300,CHICAGO,IL,606540000";
            seg["Reporter Telephone Number"]= "8008406604";
            seg["Software Vendor Name"]= "HUTCHINS SYSTEMS, INC.";
            seg["Software Version Number"]= "9.12";

            var line = seg.ToString();

            Assert.AreEqual(line.Length, header.Length);
            Assert.AreEqual(header, line); 
        }
    }
}
