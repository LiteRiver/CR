using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Metro2 {
    public class TrailerSegment : Segment {
        public TrailerSegment() : base() {            
        }

        protected override void DefineFields() {
            DefineField(new NumericField("RDW", 4) { DefaultValue = 1430 });
            DefineField(new AlphabeticField("Record Identifier", 7) { DefaultValue = "TRAILER" });
            DefineField(new NumericField("Total Base Records", 9));
            DefineField(new AlphabeticField("Reserved-1", 9));
            DefineField(new NumericField("Total of Status Code DF", 9));
            DefineField(new NumericField("Total Associated Consumer Segments (J1)", 9));
            DefineField(new NumericField("Total Associated Consumer Segments (J2)", 9));
            DefineField(new NumericField("Block Count", 9));
            DefineField(new NumericField("Total of Status Code DA", 9));
            DefineField(new NumericField("Total of Status Code 05", 9));
            DefineField(new NumericField("Total of Status Code 11", 9));
            DefineField(new NumericField("Total of Status Code 13", 9));
            DefineField(new NumericField("Total of Status Code 61", 9));
            DefineField(new NumericField("Total of Status Code 62", 9));
            DefineField(new NumericField("Total of Status Code 63", 9));
            DefineField(new NumericField("Total of Status Code 64", 9));
            DefineField(new NumericField("Total of Status Code 65", 9));
            DefineField(new NumericField("Total of Status Code 71", 9));
            DefineField(new NumericField("Total of Status Code 78", 9));
            DefineField(new NumericField("Total of Status Code 80", 9));
            DefineField(new NumericField("Total of Status Code 82", 9));
            DefineField(new NumericField("Total of Status Code 83", 9));
            DefineField(new NumericField("Total of Status Code 84", 9));
            DefineField(new NumericField("Total of Status Code 88", 9));
            DefineField(new NumericField("Total of Status Code 89", 9));
            DefineField(new NumericField("Total of Status Code 93", 9));
            DefineField(new NumericField("Total of Status Code 94", 9));
            DefineField(new NumericField("Total of Status Code 95", 9));
            DefineField(new NumericField("Total of Status Code 96", 9));
            DefineField(new NumericField("Total of Status Code 97", 9));
            DefineField(new NumericField("Total of ECOA Code Z (All Segments)", 9));
            DefineField(new NumericField("Total Employment Segments", 9));
            DefineField(new NumericField("Total Original Creditor Segments", 9));
            DefineField(new NumericField("Total Purchased From/Sold To Segments", 9));
            DefineField(new NumericField("Total Mortgage Information Segments", 9));
            DefineField(new NumericField("Total Specialized Payment Information Segments", 9));
            DefineField(new NumericField("Total Change Segments", 9));
            DefineField(new NumericField("Total Social Security Numbers (All Segments)", 9));
            DefineField(new NumericField("Total Social Security Numbers (Base Segments)", 9));
            DefineField(new NumericField("Total Social Security Numbers (J1 Segments)", 9));
            DefineField(new NumericField("Total Social Security Numbers (J2 Segments)", 9));
            DefineField(new NumericField("Total Dates of Birth (All Segments)", 9));
            DefineField(new NumericField("Total Dates of Birth (Base Segments)", 9));
            DefineField(new NumericField("Total Dates of Birth (J1 Segments)", 9));
            DefineField(new NumericField("Total Dates of Birth (J2 Segments)", 9));
            DefineField(new NumericField("Total Telephone Numbers (All Segments)", 9));
            DefineField(new AlphabeticField("Reserved-2", 19));
            DefineField(new AlphabeticField("J1", 100));
            DefineField(new AlphabeticField("J2-1", 200));
            DefineField(new AlphabeticField("J2-2", 200));
            DefineField(new AlphabeticField("J2-3", 200));
            DefineField(new AlphabeticField("K2", 34));
            DefineField(new AlphabeticField("K3", 40));
            DefineField(new AlphabeticField("K4", 30));
            DefineField(new AlphabeticField("L1", 54));
            DefineField(new AlphabeticField("N1", 146));
        }
    }
}
