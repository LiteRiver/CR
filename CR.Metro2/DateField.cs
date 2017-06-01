using System;
using CR.Framework;
using System.Globalization;

namespace CR.Metro2 {
    public class DateField : FieldBase {
        private const string NULL = "00000000";
        private const string FORMAT = "MMddyyyy";

        public DateField(string name) : base(name, NULL.Length) {
        }

        public override string Format(object val) {
            if (val == null) {
                return NULL;
            }

            Guards.Validate(val.GetType() == typeof(DateTime), "val", string.Format("[{0}] val must be a DateTime", Name));

            return ((DateTime)val).ToString(FORMAT);
        }

        protected override object ParseCore(string val) {
            if (val == NULL) {
                return null;
            }

            DateTime d;
            Guards.Validate(DateTime.TryParseExact(val, FORMAT, null, DateTimeStyles.None, out d), "val", "val is not a valid DateTime");

            return d;
        }
    }
}
