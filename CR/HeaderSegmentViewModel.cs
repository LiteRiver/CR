using CR.Metro2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CR {
    public class HeaderSegmentViewModel : INotifyPropertyChanged {
        public HeaderSegment HeaderSegment { get; protected set; }

        public HeaderSegmentViewModel(HeaderSegment segment) {
            HeaderSegment = segment;
        }

        public object this[string name] {
            get { return HeaderSegment[name]; }
            set {
                if (HeaderSegment[name] != value) {
                    HeaderSegment[name] = value;
                    OnPropertyChanged(Binding.IndexerName);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
