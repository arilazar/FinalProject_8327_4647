using FinalProject_8327_4647.ViewModels;
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
            nearEarthVM.GetNearEarthObjects(hazardCB.IsChecked.Value);
            dataGrid.ItemsSource = nearEarthVM.NearEarthObjects;
        }

        private void fromDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            nearEarthVM.FromDate = DateTime.Parse(fromDate.Text).ToString("yyyy-MM-dd");
        }

        private void toDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            nearEarthVM.ToDate = DateTime.Parse(toDate.Text).ToString("yyyy-MM-dd");
        }
    }
}
