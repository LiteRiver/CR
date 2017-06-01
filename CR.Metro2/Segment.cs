using CR.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CR.Metro2 {
    public abstract class Segment {
        private List<IField> m_schema = new List<IField>();
        private Dictionary<string, object> m_data = new Dictionary<string, object>();

        private bool m_dirty = false;
        private int m_length = 0;

        public int Length {
            get {
                if (m_dirty) {
                    m_length = m_schema.Sum(f => f.Length);
                    m_dirty = false;
                }
                
                return m_length;
            }
        }

        public Segment() {
        }

        public override string ToString() {
            var str = new StringBuilder();

            foreach (var sch in m_schema) {
                str.Append(sch.Format(this[sch.Name] ?? sch.DefaultValue));
            }

            return str.ToString();
        }

        public virtual void Parse(string line) {
            var i = 0;
            foreach (dynamic sch in m_schema) {
                this[sch.Name] = sch.Parse(line.Substring(i, sch.Length));
                i += sch.Length;
            }
        }

        public object this[string name] {
            get {
                object v = null;
                m_data.TryGetValue(name, out v);
                return v;
            }
            set {
                m_data[name] = value;
            }
        }

        protected void DefineField(IField field) {
            Guards.ThrowIfNull(field, "field");
            Guards.Validate(!HasField(field.Name), "field", string.Format("the name [{0}] of the field already exists", field.Name));
            m_schema.Add(field);
            m_dirty = true;
        }

        public bool HasField(string name) {
            return m_schema.Exists(f => string.Equals(name, f.Name));
        }
    }
}
