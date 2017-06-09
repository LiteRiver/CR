using CR.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Metro2 {
    public class Metro2File {
        public HeaderSegment Header { get; } = new HeaderSegment();

        public List<BaseSegment> Bases { get; } = new List<BaseSegment>();

        public TrailerSegment Trailer { get; } = new TrailerSegment();

        private const string HEADER_ID = "HEADER";
        private const string TRAILER_ID = "TRAILER";

        public void Parse(Stream stream) {
            Guards.ThrowIfNull(stream, "stream");
            var sReader = new StreamReader(stream);

            Header.ClearData();
            Trailer.ClearData();
            Bases.Clear();            

            var line = string.Empty; 
            while((line = sReader.ReadLine()) != null) {
                if (string.IsNullOrEmpty(line)) {
                    continue;
                }

                if (line.Substring(4, HEADER_ID.Length) == HEADER_ID) {
                    Header.Parse(line);
                } else if(line.Substring(4, TRAILER_ID.Length) == TRAILER_ID) {
                    Trailer.Parse(line);
                } else {
                    var b = new BaseSegment();
                    b.Parse(line);
                    Bases.Add(b);
                }
            }
        }

        public void WriteTo(Stream stream) {
            Guards.ThrowIfNull(stream, "stream");

            var sWriter = new StreamWriter(stream);

            sWriter.WriteLine(Header.ToString());
            Bases.ForEach(b => sWriter.WriteLine(b.ToString()));
            sWriter.Write(Trailer.ToString());

            sWriter.Flush();
        }

        public override string ToString() {
            var str = new StringBuilder();

            str.AppendLine(Header.ToString());
            Bases.ForEach(b => str.AppendLine(b.ToString()));
            str.Append(Trailer.ToString());

            return str.ToString();
        }

        public void UpdateSummary() {
            Trailer["Total Base Records"] = Bases.Count();
            Trailer["Total of Status Code DF"] = Bases.Count(b => string.Equals(b["Account Status"], "DF"));
            Trailer["Total Associated Consumer Segments (J1)"] = 0;
            Trailer["Total Associated Consumer Segments (J2)"] = 0;
            Trailer["Total of Status Code DA"] = Bases.Count(b => string.Equals(b["Account Status"], "DA"));
            Trailer["Total of Status Code 05"] = Bases.Count(b => string.Equals(b["Account Status"], "05"));
            Trailer["Total of Status Code 11"] = Bases.Count(b => string.Equals(b["Account Status"], "11"));
            Trailer["Total of Status Code 13"] = Bases.Count(b => string.Equals(b["Account Status"], "13"));
            Trailer["Total of Status Code 61"] = Bases.Count(b => string.Equals(b["Account Status"], "61"));
            Trailer["Total of Status Code 62"] = Bases.Count(b => string.Equals(b["Account Status"], "62"));
            Trailer["Total of Status Code 63"] = Bases.Count(b => string.Equals(b["Account Status"], "63"));
            Trailer["Total of Status Code 64"] = Bases.Count(b => string.Equals(b["Account Status"], "64"));
            Trailer["Total of Status Code 65"] = Bases.Count(b => string.Equals(b["Account Status"], "65"));
            Trailer["Total of Status Code 71"] = Bases.Count(b => string.Equals(b["Account Status"], "71"));
            Trailer["Total of Status Code 78"] = Bases.Count(b => string.Equals(b["Account Status"], "78"));
            Trailer["Total of Status Code 80"] = Bases.Count(b => string.Equals(b["Account Status"], "80"));
            Trailer["Total of Status Code 82"] = Bases.Count(b => string.Equals(b["Account Status"], "82"));
            Trailer["Total of Status Code 83"] = Bases.Count(b => string.Equals(b["Account Status"], "83"));
            Trailer["Total of Status Code 84"] = Bases.Count(b => string.Equals(b["Account Status"], "84"));
            Trailer["Total of Status Code 88"] = Bases.Count(b => string.Equals(b["Account Status"], "88"));
            Trailer["Total of Status Code 89"] = Bases.Count(b => string.Equals(b["Account Status"], "89"));
            Trailer["Total of Status Code 93"] = Bases.Count(b => string.Equals(b["Account Status"], "93"));
            Trailer["Total of Status Code 94"] = Bases.Count(b => string.Equals(b["Account Status"], "94"));
            Trailer["Total of Status Code 95"] = Bases.Count(b => string.Equals(b["Account Status"], "95"));
            Trailer["Total of Status Code 96"] = Bases.Count(b => string.Equals(b["Account Status"], "96"));
            Trailer["Total of Status Code 97"] = Bases.Count(b => string.Equals(b["Account Status"], "97"));
            Trailer["Total of Status Code 65"] = Bases.Count(b => string.Equals(b["Account Status"], "65"));
            Trailer["Total of ECOA Code Z (All Segments)"] = Bases.Count(b => string.Equals(b["ECOA Code"], "Z"));
            Trailer["Total Employment Segments"] = 0;
            Trailer["Total Original Creditor Segments"] = 0;
            Trailer["Total Purchased From/Sold To Segments"] = 0;
            Trailer["Total Mortgage Information Segments"] = 0;
            Trailer["Total Specialized Payment Information Segments"] = 0;
            Trailer["Total Change Segments"] = 0;
            Trailer["Total Social Security Numbers (All Segments)"] = Bases.Count(b => Convert.ToInt64(b["Social Security Number"]) != 0);
            Trailer["Total Social Security Numbers (Base Segments)"] = Bases.Count(b => Convert.ToInt64(b["Social Security Number"]) != 0);
            Trailer["Total Social Security Numbers (J1 Segments)"] = 0;
            Trailer["Total Social Security Numbers (J2 Segments)"] = 0;
            Trailer["Total Dates of Birth (All Segments)"] = Bases.Count(b => b["Date of Birth"] != null);
            Trailer["Total Dates of Birth (Base Segments)"] = Bases.Count(b => b["Date of Birth"] != null);
            Trailer["Total Dates of Birth (J1 Segments)"] = 0;
            Trailer["Total Dates of Birth (J2 Segments)"] = 0;
            Trailer["Total Telephone Numbers (All Segments)"] = Bases.Count(b => Convert.ToInt64(b["Telephone Number"]) != 0);
        }
    }
}
