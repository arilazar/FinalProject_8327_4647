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
        }

        private void SearchHazardsBT_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() => nearEarthVM.GetNearEarthObjects());
        }

        private void fromDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            nearEarthVM.FromDate = DateTime.Parse(fromDate.Text).ToString("yyyy-MM-dd");
        }

        private void toDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            nearEarthVM.ToDate = DateTime.Parse(toDate.Text).ToString("yyyy-MM-dd");
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
