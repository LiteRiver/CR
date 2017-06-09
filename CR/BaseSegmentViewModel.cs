using CR.Metro2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CR {
    public class BaseSegmentViewModel: INotifyPropertyChanged {
        public BaseSegment BaseSegment { get; protected set; }

        public BaseSegmentViewModel(BaseSegment segment) {
            BaseSegment = segment;
        }

        public object this[string name] {
            get { return BaseSegment[name]; }
            set {
                if (BaseSegment[name] != value) {
                    BaseSegment[name] = value;
                    OnPropertyChanged(Binding.IndexerName);
                }                
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
