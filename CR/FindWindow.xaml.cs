using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace CR {
    /// <summary>
    /// Interaction logic for FindWindow.xaml
    /// </summary>
    public partial class FindWindow : Window {
        public FindWindow() {
            InitializeComponent();
        }

        public string AccountNumber { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e) {
            var txt = tbNumber.Text.Trim();
            if (!string.Equals(txt, string.Empty)) {
                AccountNumber = txt;
                DialogResult = true;
            }
        }
    }
}
