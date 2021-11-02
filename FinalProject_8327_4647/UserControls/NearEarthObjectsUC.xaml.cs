using FinalProject_8327_4647.ViewModels;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FinalProject_8327_4647.UserControls
{
    /// <summary>
    /// Interaction logic for NearEarthObjectsUC.xaml
    /// </summary>
    public partial class NearEarthObjectsUC : UserControl
    {
        private NearEarthVM nearEarthVM;

        public NearEarthObjectsUC()
        {
            nearEarthVM = new NearEarthVM();
            DataContext = nearEarthVM;
            InitializeComponent();
            fromDate.DisplayDate = DateTime.Now;
            toDate.DisplayDate = DateTime.Now;
            Task.Run(() => nearEarthVM.GetNearEarthObjects());
        }

        private void SearchHazardsBT_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() => nearEarthVM.GetNearEarthObjects());
        }

        private void fromDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            nearEarthVM.FromDate = DateTime.Parse(fromDate.Text).ToString("yyyy-MM-dd");
            //if (toDate != null)
            //{
            //    var x = DateTime.Now.Ticks;
            //    var y = (DateTime)fromDate.SelectedDate;
            //    var z = ((DateTime)fromDate.SelectedDate).AddDays(7).Ticks;
            //    var a = Math.Min(x, z);
            //    toDate.DisplayDateEnd = new DateTime(a);

            //    toDate.DisplayDateEnd = new DateTime(Math.Min(((DateTime)fromDate.SelectedDate).AddDays(7).Ticks, DateTime.Now.Ticks));
            //}
        }

        private void toDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            nearEarthVM.ToDate = DateTime.Parse(toDate.Text).ToString("yyyy-MM-dd");
            //if (fromDate != null)
            //    fromDate.DisplayDateEnd = new DateTime(Math.Min(((DateTime)toDate.SelectedDate).AddDays(-7).Ticks, DateTime.Now.Ticks));
        }

        private void hazardCB_Checked(object sender, RoutedEventArgs e)
        {
            nearEarthVM.HazardOnly = hazardCB.IsChecked.Value;
        }

        private void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var displayName = GetPropertyDisplayName(e.PropertyDescriptor);

            if (!string.IsNullOrEmpty(displayName))
            {
                e.Column.Header = displayName;
            }
        }

        private static string GetPropertyDisplayName(object descriptor)
        {
            var pd = descriptor as PropertyDescriptor;

            if (pd != null)
            {
                // Check for DisplayName attribute and set the column header accordingly
                var displayName = pd.Attributes[typeof(DisplayNameAttribute)] as DisplayNameAttribute;

                if (displayName != null && displayName != DisplayNameAttribute.Default)
                {
                    return displayName.DisplayName;
                }
            }
            else
            {
                var pi = descriptor as PropertyInfo;

                if (pi != null)
                {
                    // Check for DisplayName attribute and set the column header accordingly
                    Object[] attributes = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                    for (int i = 0; i < attributes.Length; ++i)
                    {
                        var displayName = attributes[i] as DisplayNameAttribute;
                        if (displayName != null && displayName != DisplayNameAttribute.Default)
                        {
                            return displayName.DisplayName;
                        }
                    }
                }
            }
            return null;
        }
    }
}
