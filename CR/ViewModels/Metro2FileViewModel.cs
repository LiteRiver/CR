using CR.Metro2;
using Microsoft.Win32;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CR {
    public class Metro2FileViewModel : INotifyPropertyChanged {
        public HeaderSegmentViewModel HeaderSegment { get; protected set; }
        public ObservableCollection<BaseSegmentViewModel> BaseSegments { get; protected set; } = new ObservableCollection<BaseSegmentViewModel>();
        public TrailerSegmentViewModel TrailerSegment { get; protected set; }

        public DelegateCommand ImportCommand { get; private set; }
        public DelegateCommand ExportCommand { get; private set; }
        public DelegateCommand FindCommand { get; private set; }
        public DelegateCommand<BaseSegmentViewModel> RemoveCommand { get; private set; }

        public BaseSegmentViewModel SelectedItem { get; set; }

        private Metro2File m_metro2File;

        private string m_filename;

        public event PropertyChangedEventHandler PropertyChanged;

        public Metro2FileViewModel() {
            m_metro2File = new Metro2File();
            HeaderSegment = new HeaderSegmentViewModel(m_metro2File.Header);
            TrailerSegment = new TrailerSegmentViewModel(m_metro2File.Trailer);

            ImportCommand = new DelegateCommand(Import);
            ExportCommand = new DelegateCommand(Export, CanExport);
            FindCommand = new DelegateCommand(Find, CanFind);
            RemoveCommand = new DelegateCommand<BaseSegmentViewModel>(Remove);
        }

        public void Parse(Stream stream) {
            m_metro2File.Parse(stream);
            BaseSegments.Clear();
            m_metro2File.Bases.ForEach(x => BaseSegments.Add(new BaseSegmentViewModel(x)));
        }

        public void Export(Stream stream) {
            m_metro2File.WriteTo(stream);
        }

        public string Filename {
            get { return m_filename; }
            set {
                if (m_filename != value) {
                    m_filename = value;
                    OnPropertyChanged("Filename");
                }
            }
        }

        public int TotalCount {
            get { return BaseSegments.Count; }
        }

        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Import() {
            var dlg = new OpenFileDialog();
            var ret = dlg.ShowDialog();
            if (ret == true) {
                try {
                    using (var stream = new FileStream(dlg.FileName, FileMode.Open)) {
                        Parse(stream);
                        Filename = Path.GetFileName(dlg.FileName);
                        OnPropertyChanged(null);
                        ExportCommand.RaiseCanExecuteChanged();
                    }
                } catch {
                    MessageBox.Show("File format is invalid");
                }
            }
        }

        private bool CanExport() {
            return BaseSegments.Count > 0;
        }

        private void Export() {
            var dlg = new SaveFileDialog();
            dlg.DefaultExt = "*.TXT";
            dlg.Filter = "Text documents (.TXT)|*.TXT";
            var ret = dlg.ShowDialog();
            if (ret == true) {
                using (var stream = new FileStream(dlg.FileName, FileMode.Create)) {
                    Export(stream);
                }

                MessageBox.Show("Export successfully");
            }
        }

        public void Remove(BaseSegmentViewModel baseSegment) {
            if (baseSegment != null && MessageBox.Show("Are you sure?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                BaseSegments.Remove(baseSegment);
                m_metro2File.Remove(baseSegment.BaseSegment);
                OnPropertyChanged("HeaderSegment");
                OnPropertyChanged("TrailerSegment");
                OnPropertyChanged("TotalCount");
                ExportCommand.RaiseCanExecuteChanged();
            }
        }

        private bool CanFind() {
            return BaseSegments.Count > 0;
        }

        private void Find() {
            var win = new FindWindow();
            if (win.ShowDialog() == true) {
                SelectedItem = BaseSegments.FirstOrDefault(b => b["Consumer Account Number"].ToString().Trim() == win.AccountNumber.Trim());
                OnPropertyChanged("SelectedItem");
            }
        }
    }
}