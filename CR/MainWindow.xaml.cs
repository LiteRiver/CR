using CR.Metro2;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
        private Metro2File m_metro2File = new Metro2File();

        public MainWindow() {
            InitializeComponent();
        }

        private void Import_Click(object sender, RoutedEventArgs e) {
            var dlg = new OpenFileDialog();
            var ret = dlg.ShowDialog();
            if (ret == true) {
                using (var stream = new FileStream(dlg.FileName, FileMode.Open)) {
                    m_metro2File.Parse(stream);
                }

                dgMetro2.ItemsSource = m_metro2File.Bases;
                
            }
        }
    }
}
