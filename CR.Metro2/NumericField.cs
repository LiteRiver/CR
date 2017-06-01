using CR.Framework;
using System;

namespace CR.Metro2 {
    public class NumericField : FieldBase {

        public NumericField(string name, int len) : base(name, len) {
        }

        public override string Format(object val) {
            long v = 0;
            if (val != null) {
                try {
                    v = Convert.ToInt64(val);
                } catch {
                    throw new ArgumentException(string.Format("[{0}] val must be a integer", Name), "val");
                }
            }

            Guards.Validate(v >= 0, "val");
            var str = v.ToString();
            Guards.Validate(str.Length <= Length, "val", string.Format("[{0}] val is too large", Name));

            return StringPadding.PadLeft(str, Length, '0', false);
        }

        protected override object ParseCore(string val) {
            long n;
            Guards.Validate(long.TryParse(val, out n), "val", string.Format("[{0}] val is not a integer", Name));
            
            return n;
        }
    }
}
