using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using CR.Framework;

namespace CR.Metro2.Tests {
    [TestClass]
    public class Metro2FileTest {
        [TestMethod]
        public void TestParse() {
            var filePath = Path.Combine(Env.GetCurrentDirectory(), "NBOOX.TXT") ;

            var metro2 = new Metro2File();

            using (var fStream = new FileStream(filePath, FileMode.Open)) {
                metro2.Parse(fStream);
            }

            Assert.AreEqual("HUTCHINS SYSTEMS, INC.", metro2.Header["Software Vendor Name"], "header => Software Vendor Name");
            Assert.AreEqual(187, metro2.Bases.Count, "the count of base segments");
            Assert.AreEqual("22705", metro2.Bases[0]["Consumer Account Number"], "bases[0] => Consumer Account Number");
            Assert.AreEqual((long)184, metro2.Trailer["Total Telephone Numbers (All Segments)"], "trailer => Total Telephone Numbers (All Segments)");

            using (var sReader = new StreamReader(new FileStream(filePath, FileMode.Open))) {
                Assert.AreEqual(sReader.ReadToEnd().Trim(), metro2.ToString().Trim(), "whole file comparison");
            }
            
        }

        [TestMethod]
        public void TestUpdateSummary() {
            var filePath = Path.Combine(Env.GetCurrentDirectory(), "NBOOX.TXT");

            var metro2 = new Metro2File();

            using (var fStream = new FileStream(filePath, FileMode.Open)) {
                metro2.Parse(fStream);
            }

            var totalBaseRecords = Convert.ToInt64(metro2.Trailer["Total Base Records"]);

            metro2.Bases.RemoveAt(0);

            metro2.UpdateSummary();


            Assert.IsTrue(Convert.ToInt64(metro2.Trailer["Total Base Records"]) == totalBaseRecords - 1);

            var m = new Metro2File();

            var x = m.Trailer["Total Base Records"];
        }
    }
}
