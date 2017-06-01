using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Metro2 {
    public class HeaderSegment : Segment {
        public HeaderSegment() : base() {
            DefineField(new NumericField("RDW", 4) { DefaultValue = 1430 });
            DefineField(new AlphabeticField("Record Identifier", 6) { DefaultValue = "HEADER" });
            DefineField(new AlphabeticField("Cycle Identifier", 2));
            DefineField(new AlphabeticField("Innovis Program Identifier", 10));
            DefineField(new AlphabeticField("Equifax Program Identifier", 10));
            DefineField(new AlphabeticField("Experian Program Identifier", 5) { DefaultValue = "DBOOX" });
            DefineField(new AlphabeticField("TransUnion Program Identifier", 10));
            DefineField(new DateField("Activity Date"));
            DefineField(new DateField("Date Created"));
            DefineField(new DateField("Program Date"));
            DefineField(new DateField("Program Revision Date"));
            DefineField(new AlphabeticField("Reporter Name", 40));
            DefineField(new AlphabeticField("Reporter Address", 96));
            DefineField(new AlphabeticField("Reporter Telephone Number", 10));
            DefineField(new AlphabeticField("Software Vendor Name", 40));
            DefineField(new AlphabeticField("Software Version Number", 5));
            DefineField(new AlphabeticField("MicroBilt/PRBC Program Identifier", 10));
            DefineField(new AlphabeticField("Reserved", 146));
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
