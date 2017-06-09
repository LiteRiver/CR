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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace CR.Controls {
    public class NumericTextBox : TextBox {
        private static readonly Regex s_numericPattern = new Regex("[0-9]+");

        public NumericTextBox() : base() {
            DataObject.AddPastingHandler(this, new DataObjectPastingEventHandler(OnPasting));
        }

        protected override void OnPreviewTextInput(TextCompositionEventArgs e) {
            if (!s_numericPattern.IsMatch(e.Text)) {
                e.Handled = true;
            }

            base.OnPreviewTextInput(e);
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e) {
            if (e.Key == Key.Space) {
                e.Handled = true;
            }

            base.OnPreviewKeyDown(e);
        }

        private void OnPasting(object sender, DataObjectPastingEventArgs e) {
            var text = e.DataObject.GetData(typeof(string)) as string;

            if (string.IsNullOrEmpty(text) || !s_numericPattern.IsMatch(text)) {
                e.CancelCommand();
            }
        }
    }
}
