using CR.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Metro2 {
    public class FieldCollection : IEnumerable<IField> {
        private List<IField> m_innerList = new List<IField>();
        private Dictionary<string, IField> m_innerDict = new Dictionary<string, IField>();

        public void Add(IField field) {
            Guards.ThrowIfNull(field, "field");
            Guards.Validate(!HasField(field.Name), "field", string.Format("the name [{0}] of the field already exists", field.Name));
            m_innerList.Add(field);
            m_innerDict[field.Name] = field;
        }

        public IField this[string name] {
            get {
                return m_innerDict[name];
            }
        }

        public IField this[int index] {
            get { return m_innerList[index]; }
        }

        public IEnumerator<IField> GetEnumerator() {
            return m_innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return m_innerList.GetEnumerator();
        }

        public bool HasField(string name) {
            return m_innerDict.ContainsKey(name);
        }
    }
}
