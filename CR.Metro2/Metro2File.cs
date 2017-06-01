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

            var line = string.Empty; 
            while((line = sReader.ReadLine()) != null) {
                if (string.IsNullOrEmpty(line)) {
                    continue;
                }

                if (line.Substring(4, HEADER_ID.Length) == HEADER_ID) {
                    Console.WriteLine("parse header");
                    Header.Parse(line);
                } else if(line.Substring(4, TRAILER_ID.Length) == TRAILER_ID) {
                    Console.WriteLine("parse trailer");
                    Trailer.Parse(line);
                } else {
                    Console.WriteLine("parse base[{0}]", Bases.Count + 1);
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
    }
}
