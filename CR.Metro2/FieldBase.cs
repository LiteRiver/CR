using CR.Framework;
using System.IO;

namespace CR.Metro2 {
    public abstract class FieldBase : IField {
        public virtual string Name { get; }
        public virtual int Length { get; }
        public virtual object DefaultValue { get; set; }

        public FieldBase(string name, int len) {
            Guards.ThrowIfIsNullOrWhiteSpace(name, "name");
            Guards.Validate(len > 0, "len must be greater than 0");
            Name = name;
            Length = len;            
        }

        public abstract string Format(object val);

        public virtual object Parse(string val) {
            Guards.Validate(val != null && val.Length == Length, "val", string.Format("val length must be {0}", Length));
            return ParseCore(val);
        }

        protected abstract object ParseCore(string val);
    }
}
