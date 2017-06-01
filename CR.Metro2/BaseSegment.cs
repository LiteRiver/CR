using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Metro2 {
    public class BaseSegment : Segment {
        public BaseSegment() : base() {
            DefineField(new NumericField("RDW", 4) { DefaultValue = 1430 });
            DefineField(new NumericField("Processing Indicator", 1));
            DefineField(new TimestampField("Time Stamp"));
            DefineField(new NumericField("Reserved-1", 1));
            DefineField(new AlphabeticField("Identification Number", 20));
            DefineField(new AlphabeticField("Cycle Identifier", 2));
            DefineField(new AlphabeticField("Consumer Account Number", 30));
            DefineField(new AlphabeticField("Portfolio Type", 1));
            DefineField(new AlphabeticField("Account Type", 2) { DefaultValue = "00" });
            DefineField(new DateField("Date Opened"));
            DefineField(new MonetaryField("Credit Limit"));
            DefineField(new MonetaryField("Highest Credit or Original Loan Amount"));
            DefineField(new AlphabeticField("Terms Duration", 3));
            DefineField(new AlphabeticField("Terms Frequency", 1));
            DefineField(new MonetaryField("Scheduled Monthly Payment Amount"));
            DefineField(new MonetaryField("Actual Payment Amount"));
            DefineField(new AlphabeticField("Account Status", 2));
            DefineField(new AlphabeticField("Payment Rating", 1));
            DefineField(new AlphabeticField("Payment History Profile", 24));
            DefineField(new AlphabeticField("Special Comment", 2));
            DefineField(new AlphabeticField("Compliance Condition Code", 2));
            DefineField(new MonetaryField("Current Balance"));
            DefineField(new MonetaryField("Amount Past Due"));
            DefineField(new MonetaryField("Original Charge-off Amount"));
            DefineField(new DateField("Date of Account Information"));
            DefineField(new DateField("FCRA Compliance/Date of First Delinquency"));
            DefineField(new DateField("Date Closed"));
            DefineField(new DateField("Date of Last Payment"));
            DefineField(new AlphabeticField("Interest Type Indicator", 1));
            DefineField(new AlphabeticField("Reserved-2", 17));
            DefineField(new AlphabeticField("Surname", 25));
            DefineField(new AlphabeticField("First Name", 20));
            DefineField(new AlphabeticField("Middle Name", 20));
            DefineField(new AlphabeticField("Generation Code", 1));
            DefineField(new NumericField("Social Security Number", 9));
            DefineField(new DateField("Date of Birth"));
            DefineField(new NumericField("Telephone Number", 10));
            DefineField(new AlphabeticField("ECOA Code", 1));
            DefineField(new AlphabeticField("Consumer Information Indicator", 2));
            DefineField(new AlphabeticField("Country Code", 2));
            DefineField(new AlphabeticField("First Line of Address", 32));
            DefineField(new AlphabeticField("Second Line of Address", 32));
            DefineField(new AlphabeticField("City", 20));
            DefineField(new AlphabeticField("State", 2));
            DefineField(new AlphabeticField("Postal/Zip Code", 9));
            DefineField(new AlphabeticField("Address Indicator", 1));
            DefineField(new AlphabeticField("Residence Code", 1));
            DefineField(new AlphabeticField("J1", 100) { DefaultValue = "J1" });
            DefineField(new AlphabeticField("J2-1", 200) { DefaultValue = "J2" });
            DefineField(new AlphabeticField("J2-2", 200) { DefaultValue = "J2" });
            DefineField(new AlphabeticField("J2-3", 200) { DefaultValue = "J2" });
            DefineField(new AlphabeticField("K2", 34) { DefaultValue = "K2" });
            DefineField(new AlphabeticField("K3", 40) { DefaultValue = "K3" });
            DefineField(new AlphabeticField("K4", 30) { DefaultValue = "K4" });
            DefineField(new AlphabeticField("L1", 54) { DefaultValue = "L1" });
            DefineField(new AlphabeticField("N1", 146) { DefaultValue = "N1" });
        }
    }
}
