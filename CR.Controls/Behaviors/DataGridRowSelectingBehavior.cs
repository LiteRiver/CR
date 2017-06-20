using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CR.Controls {
    public class DataGridRowSelectingBehavior<T> {
        public static readonly DependencyProperty SelectingItemProperty = DependencyProperty.RegisterAttached(
            "SelectingItem",
            typeof(T),
            typeof(DataGridRowSelectingBehavior<T>),
            new PropertyMetadata(default(T), OnSelectingItemChanged));

        public static T GetSelectingItem(DependencyObject target) {
            return (T)target.GetValue(SelectingItemProperty);
        }

        public static void SetSelectingItem(DependencyObject target, T value) {
            target.SetValue(SelectingItemProperty, value);
        }

        private static void OnSelectingItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            var grid = sender as DataGrid;
            if (grid == null || grid.SelectedItem == null) {
                return;
            }

            grid.Dispatcher.InvokeAsync(() => {
                grid.UpdateLayout();
                grid.ScrollIntoView(grid.SelectedItem, null);
            });
        }
    }
}
