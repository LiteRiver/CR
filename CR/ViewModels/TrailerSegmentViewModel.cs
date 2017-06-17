using CR.Metro2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CR {
    public class TrailerSegmentViewModel : INotifyPropertyChanged {
        public TrailerSegment TrailerSegment { get; protected set; }

        public TrailerSegmentViewModel(TrailerSegment segment) {
            TrailerSegment = segment;
        }

        public object this[string name] {
            get { return TrailerSegment[name]; }
            set {
                if (TrailerSegment[name] != value) {
                    TrailerSegment[name] = value;
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
