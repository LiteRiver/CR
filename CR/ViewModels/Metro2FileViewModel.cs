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
        public DelegateCommand<BaseSegmentViewModel> RemoveCommand { get; private set; }
        public DelegateCommand FindCommand { get; private set; }
        public DelegateCommand FindPreviousCommand { get; private set; }
        public DelegateCommand FindNextCommand { get; private set; }       
        public DelegateCommand PerformFindCommand { get; private set; }
        public DelegateCommand<Window> CloseWindowCommand { get; private set; }

        private Metro2File m_metro2File;

        private string m_filename;

        private string m_findText;

        private List<BaseSegmentViewModel> m_findedItems;

        private int m_findedItemIndex = -1;

        private BaseSegmentViewModel m_selectedItem;

        public event PropertyChangedEventHandler PropertyChanged;

        public Metro2FileViewModel() {
            m_metro2File = new Metro2File();
            HeaderSegment = new HeaderSegmentViewModel(m_metro2File.Header);
            TrailerSegment = new TrailerSegmentViewModel(m_metro2File.Trailer);

            ImportCommand = new DelegateCommand(Import);
            ExportCommand = new DelegateCommand(Export, CanExport);
            RemoveCommand = new DelegateCommand<BaseSegmentViewModel>(Remove);
            FindCommand = new DelegateCommand(Find, CanFind);           
            PerformFindCommand = new DelegateCommand(PerformFind, CanPerformFind);
            FindPreviousCommand = new DelegateCommand(FindPrevious, CanFindPrevious);
            FindNextCommand = new DelegateCommand(FindNext, CanFindNext);
            CloseWindowCommand = new DelegateCommand<Window>(CloseWindow);
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

        public string FindText {
            get { return m_findText; }
            set {
                if (m_findText != value) {
                    m_findText = value;
                    PerformFindCommand.RaiseCanExecuteChanged();
                    OnPropertyChanged("FindText");
                }
            }
        }

        public List<BaseSegmentViewModel> FindedItems {
            get { return m_findedItems; }
            set {
                if (m_findedItems != value) {
                    m_findedItems = value;
                    OnPropertyChanged("FindedItems");
                }
            }
        }

        public int FindedItemIndex {
            get { return m_findedItemIndex; }
            set {
                if (m_findedItemIndex != value) {
                    m_findedItemIndex = value;
                    OnPropertyChanged("FindedItemIndex");
                }
            }
        }

        public BaseSegmentViewModel SelectedItem {
            get { return m_selectedItem; }
            set {
                if (m_selectedItem != value) {
                    m_selectedItem = value;
                    OnPropertyChanged("SelectedItem");
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
                        FindCommand.RaiseCanExecuteChanged();
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
                FindCommand.RaiseCanExecuteChanged();
            }
        }

        private bool CanFind() {
            return BaseSegments.Count > 0;
        }

        private void Find() {
            FindText = null;
            var win = new FindWindow(this);
            win.ShowDialog();
        }

        private bool CanPerformFind() {
            return FindText != null && FindText.Trim() != string.Empty;
        }

        private void PerformFind() {
            if (!CanPerformFind()) {
                return;
            }

            var text = FindText.Trim();

            FindedItems = BaseSegments
                .Where(b => b["Consumer Account Number"].ToString().Contains(text) ||
                    b["Social Security Number"].ToString().Contains(text) ||
                    b["Surname"].ToString().Contains(text) ||
                    b["First Name"].ToString().Contains(text))
                .ToList();

            if (FindedItems.Count > 0) {
                FindedItemIndex = 0;
                SelectedItem = FindedItems[0];
            } else {
                FindedItemIndex = -1;
                SelectedItem = null;
            }

            FindPreviousCommand.RaiseCanExecuteChanged();
            FindNextCommand.RaiseCanExecuteChanged();
        }

        private bool CanFindNext() {
            return m_findedItems != null && m_findedItemIndex < m_findedItems.Count - 1;
        }

        private void FindNext() {
            if (!CanFindNext()) {
                return;
            }

            SelectedItem = FindedItems[++FindedItemIndex];
            FindPreviousCommand.RaiseCanExecuteChanged();
            FindNextCommand.RaiseCanExecuteChanged();
        }

        private bool CanFindPrevious() {
            return m_findedItems != null && m_findedItemIndex > 0;
        }

        private void FindPrevious() {
            if (!CanFindPrevious()) {
                return;
            }

            SelectedItem = FindedItems[--FindedItemIndex];
            FindPreviousCommand.RaiseCanExecuteChanged();
            FindNextCommand.RaiseCanExecuteChanged();
        }

        private void CloseWindow(Window win) {
            if (win != null) {
                win.Close();
            }
        }
    }
}