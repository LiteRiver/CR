using System.IO;

namespace CR.Metro2 {
    public interface IField {
        string Name { get; }
        object DefaultValue { get;}
        int Length { get; }
        object Parse(string val);
        string Format(object val);
    }
}