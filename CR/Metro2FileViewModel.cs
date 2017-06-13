using CR.Metro2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR {
    public class Metro2FileViewModel: INotifyPropertyChanged {
        public HeaderSegmentViewModel HeaderSegment { get; protected set; }
        public ObservableCollection<BaseSegmentViewModel> BaseSegments { get; protected set; } = new ObservableCollection<BaseSegmentViewModel>();
        public TrailerSegmentViewModel TrailerSegment { get; protected set; }

        private Metro2File m_metro2File;

        public event PropertyChangedEventHandler PropertyChanged;

        public Metro2FileViewModel() {
            m_metro2File = new Metro2File();
            HeaderSegment = new HeaderSegmentViewModel(m_metro2File.Header);
            TrailerSegment = new TrailerSegmentViewModel(m_metro2File.Trailer);
        }

        public void Parse(Stream stream) {
            m_metro2File.Parse(stream);
            BaseSegments.Clear();
            m_metro2File.Bases.ForEach(x => BaseSegments.Add(new BaseSegmentViewModel(x)));
            OnPropertyChanged("HeaderSegment");
            OnPropertyChanged("TrailerSegment");
        }

        public void Export(Stream stream) {
            m_metro2File.WriteTo(stream);
        }

        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}