using CR.Framework;
using System;
using System.Globalization;

namespace CR.Metro2 {
    public class TimestampField : FieldBase {
        private const string NULL = "00000000000000";
        private const string FORMAT = "MMddyyyyHHmmss";

        public TimestampField(string name) : base(name, NULL.Length) {
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
            Guards.Validate(DateTime.TryParseExact(val, FORMAT, null, DateTimeStyles.None, out d), "val", string.Format("[{0}] val is not a valid DateTime", Name));

            return d;
        }
    }
}
