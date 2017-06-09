using CR.Framework;
using CR.Metro2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace CR.Controls {
    /// <summary>
    /// Interaction logic for PaymentHistoryEditor.xaml
    /// </summary>
    public partial class PaymentHistoryEditor : UserControl {
        public static DependencyProperty HistoryProperty;

        public static DependencyProperty Month01Property;
        public static DependencyProperty Month02Property;
        public static DependencyProperty Month03Property;
        public static DependencyProperty Month04Property;
        public static DependencyProperty Month05Property;
        public static DependencyProperty Month06Property;
        public static DependencyProperty Month07Property;
        public static DependencyProperty Month08Property;
        public static DependencyProperty Month09Property;
        public static DependencyProperty Month10Property;
        public static DependencyProperty Month11Property;
        public static DependencyProperty Month12Property;
        public static DependencyProperty Month13Property;
        public static DependencyProperty Month14Property;
        public static DependencyProperty Month15Property;
        public static DependencyProperty Month16Property;
        public static DependencyProperty Month17Property;
        public static DependencyProperty Month18Property;
        public static DependencyProperty Month19Property;
        public static DependencyProperty Month20Property;
        public static DependencyProperty Month21Property;
        public static DependencyProperty Month22Property;
        public static DependencyProperty Month23Property;
        public static DependencyProperty Month24Property;

        public static readonly RoutedEvent HistoryChangedEvent;

        static PaymentHistoryEditor() {
            HistoryProperty = DependencyProperty.Register(
                "History",
                typeof(string),
                typeof(PaymentHistoryEditor),
                new PropertyMetadata(StringPadding.PadRight("", 24, 'B', false), new PropertyChangedCallback(OnHistoryChanged)),
                new ValidateValueCallback(IsHistoryValid));

            HistoryChangedEvent = EventManager.RegisterRoutedEvent(
                "HistoryChanged",
                RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventArgs<string>),
                typeof(PaymentHistoryEditor));

            var editorType = typeof(PaymentHistoryEditor);

            for (var i = 0; i < 24; i++) {
                var name = string.Format("Month{0:00}", i + 1);
                var pName = name + "Property";

                var p = editorType.GetField(pName);
                p.SetValue(
                    null,
                    DependencyProperty.Register(
                        name,
                        typeof(string),
                        typeof(PaymentHistoryEditor),
                        new PropertyMetadata("B", new PropertyChangedCallback(OnSingleMonthChanged)),
                        new ValidateValueCallback(IsSingleMonthValid)));
            }
        }

        private static void OnHistoryChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            var editor = (PaymentHistoryEditor)sender;

            var history = (string)e.NewValue;

            var editorType = editor.GetType();
            for (var i = 0; i < 24; i++) {
                var p = editorType.GetProperty(string.Format("Month{0:00}", i + 1));
                p.SetValue(editor, history[i].ToString());

                Console.WriteLine("{0} => {1}", string.Format("Month{0:00}", i + 1), history[i].ToString());
            }
        }

        private static void OnSingleMonthChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            var editor = (PaymentHistoryEditor)sender;

            var pName = e.Property.Name;
            var index = int.Parse(pName.Replace("Month", "")) - 1;

            var history = editor.History.ToCharArray().Select(c => c.ToString()).ToList();
            history[index] = (string)e.NewValue;

            editor.History = string.Join("", history);
        }

        private static bool IsHistoryValid(object value) {
            var h = (string)value;

            if (h.Length != 24) {
                return false;
            }

            foreach (var c in h) {
                if (!ValidChars.Contains(c.ToString())) {
                    return false;
                }
            }

            return true;
        }

        private static bool IsSingleMonthValid(object value) {
            var m = (string)value;

            if (m.Length != 1) {
                return false;
            }

            return ValidChars.Contains(m);
        }

        private static IList<string> m_validChars;
        private static IList<string> ValidChars {
            get {
                if (m_validChars == null) {
                    m_validChars = Metro2Options.PaymentHistoryProfile.Select(o => o.Key).ToList();
                }

                return m_validChars;
            }
        }

        public string History {
            get { return (string)GetValue(HistoryProperty); }
            set { SetValue(HistoryProperty, value); }
        }

        #region Single Month Properties

        public string Month01 {
            get { return (string)GetValue(Month01Property); }
            set { SetValue(Month01Property, value); }
        }

        public string Month02 {
            get { return (string)GetValue(Month02Property); }
            set { SetValue(Month02Property, value); }
        }

        public string Month03 {
            get { return (string)GetValue(Month03Property); }
            set { SetValue(Month03Property, value); }
        }

        public string Month04 {
            get { return (string)GetValue(Month04Property); }
            set { SetValue(Month04Property, value); }
        }

        public string Month05 {
            get { return (string)GetValue(Month05Property); }
            set { SetValue(Month05Property, value); }
        }

        public string Month06 {
            get { return (string)GetValue(Month06Property); }
            set { SetValue(Month06Property, value); }
        }

        public string Month07 {
            get { return (string)GetValue(Month07Property); }
            set { SetValue(Month07Property, value); }
        }

        public string Month08 {
            get { return (string)GetValue(Month08Property); }
            set { SetValue(Month08Property, value); }
        }

        public string Month09 {
            get { return (string)GetValue(Month09Property); }
            set { SetValue(Month09Property, value); }
        }

        public string Month10 {
            get { return (string)GetValue(Month10Property); }
            set { SetValue(Month10Property, value); }
        }

        public string Month11 {
            get { return (string)GetValue(Month11Property); }
            set { SetValue(Month11Property, value); }
        }

        public string Month12 {
            get { return (string)GetValue(Month12Property); }
            set { SetValue(Month12Property, value); }
        }

        public string Month13 {
            get { return (string)GetValue(Month13Property); }
            set { SetValue(Month13Property, value); }
        }

        public string Month14 {
            get { return (string)GetValue(Month14Property); }
            set { SetValue(Month14Property, value); }
        }

        public string Month15 {
            get { return (string)GetValue(Month15Property); }
            set { SetValue(Month15Property, value); }
        }

        public string Month16 {
            get { return (string)GetValue(Month16Property); }
            set { SetValue(Month16Property, value); }
        }

        public string Month17 {
            get { return (string)GetValue(Month17Property); }
            set { SetValue(Month17Property, value); }
        }

        public string Month18 {
            get { return (string)GetValue(Month18Property); }
            set { SetValue(Month18Property, value); }
        }

        public string Month19 {
            get { return (string)GetValue(Month19Property); }
            set { SetValue(Month19Property, value); }
        }

        public string Month20 {
            get { return (string)GetValue(Month20Property); }
            set { SetValue(Month20Property, value); }
        }

        public string Month21 {
            get { return (string)GetValue(Month21Property); }
            set { SetValue(Month21Property, value); }
        }

        public string Month22 {
            get { return (string)GetValue(Month22Property); }
            set { SetValue(Month22Property, value); }
        }

        public string Month23 {
            get { return (string)GetValue(Month23Property); }
            set { SetValue(Month23Property, value); }
        }

        public string Month24 {
            get { return (string)GetValue(Month24Property); }
            set { SetValue(Month24Property, value); }
        }

        #endregion

        public event RoutedPropertyChangedEventHandler<string> HistoryChanged {
            add { AddHandler(HistoryChangedEvent, value); }
            remove { RemoveHandler(HistoryChangedEvent, value); }
        }

        public PaymentHistoryEditor() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show(this.Month01);
        }
    }
}
