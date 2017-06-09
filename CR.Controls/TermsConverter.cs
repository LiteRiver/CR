using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using CR.Metro2;

namespace CR.Controls {
    public class TermsConverter : IValueConverter {
        private static NumericField s_field = new NumericField("DUMMY", 3);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {

            int i;
            if (value != null && int.TryParse(value.ToString(), out i)) {
                return s_field.Format(value);
            }

            return s_field.Format(0);
        }
    }
}
