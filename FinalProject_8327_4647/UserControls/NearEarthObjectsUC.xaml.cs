using FinalProject_8327_4647.ViewModels;
using System;
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
            nearEarthVM.GetNearEarthObjects();
            //dataGrid.ItemsSource = nearEarthVM.NearEarthObjects;
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
    }
}
