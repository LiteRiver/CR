using CR.Framework;

namespace CR.Metro2 {
    public class AlphabeticField : FieldBase {
        public override object DefaultValue { get => base.DefaultValue ?? string.Empty; set => base.DefaultValue = value; }

        public AlphabeticField(string name, int len): base(name, len) { }

        public override string Format(object val) {

            var v = string.Empty;
            if (val != null) {
                Guards.Validate(val.GetType() == typeof(string), "val", string.Format("[{0}] val must be a string", Name));
                v = (string)val;
            }

            Guards.Validate(v.Length <= Length, "val", string.Format("[{0}] val is too long", Name));
            return StringPadding.PadRight(v.ToUpper(), Length);
        }

        protected override object ParseCore(string val) {
            return val.TrimEnd();
        }
    }
}
