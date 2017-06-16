using CR.Metro2;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CR {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private Metro2FileViewModel m_metro2File = new Metro2FileViewModel();

        public MainWindow() {
            InitializeComponent();
        }

        private void Import_Click(object sender, RoutedEventArgs e) {
            var dlg = new OpenFileDialog();
            var ret = dlg.ShowDialog();
            if (ret == true) {
                try {
                    using (var stream = new FileStream(dlg.FileName, FileMode.Open)) {
                        m_metro2File.Parse(stream);
                    }

                    DataContext = m_metro2File;
                } catch {
                    MessageBox.Show("File format is invalid");
                }                
            }
        }

        private void Export_Click(object sender, RoutedEventArgs e) {
            var dlg = new SaveFileDialog();
            dlg.DefaultExt = "*.TXT";
            dlg.Filter = "Text documents (.TXT)|*.TXT";
            var ret = dlg.ShowDialog();
            if (ret == true) {
                using (var stream = new FileStream(dlg.FileName, FileMode.Create)) {
                    m_metro2File.Export(stream);
                }

                MessageBox.Show("Export successfully");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e) {
            var menuItem = (MenuItem)sender;
            var toRemove = (BaseSegmentViewModel)menuItem.DataContext;

            if (MessageBox.Show("Are you sure?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                m_metro2File.Remove(toRemove);
            }
        }
    }
}
