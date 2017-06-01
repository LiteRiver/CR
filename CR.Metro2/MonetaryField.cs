using System;

namespace CR.Metro2 {
    public class MonetaryField : NumericField {
        private const int MAX = 999999999;

        public MonetaryField(string name): base(name, 9) { }

        public override string Format(object val) {
            long v = 0;
            if (val != null) {
                try {
                    v = Convert.ToInt64(val);
                } catch {
                    throw new ArgumentException(string.Format("[{0}] val must be a integer", Name), "val");
                }
            }

            if (v > MAX) {
                v = MAX;
            }

            return base.Format(v);
        }
    }
}
