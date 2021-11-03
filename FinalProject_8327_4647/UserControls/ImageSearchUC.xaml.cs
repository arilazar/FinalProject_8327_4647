using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using FinalProject_8327_4647.Converters;
using FinalProject_8327_4647.ViewModels;
using FinalProject_8327_4647.Converters;

namespace FinalProject_8327_4647.UserControls
{
    /// <summary>
    /// Interaction logic for ImageSearchUC.xaml
    /// </summary>
    public partial class ImageSearchUC : UserControl
    {
        private ImageSearchVM searchVM;

        public ImageSearchUC()
        {
            searchVM = new ImageSearchVM();
            DataContext = searchVM;
            InitializeComponent();
        }

        private void searchBT_Click(object sender, RoutedEventArgs e)
        {
            Binding b = new Binding
            {
                Source = searchVM,
                Path = new PropertyPath("SearchImageCollection.Count"),
                Mode = BindingMode.OneWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                Converter = new ConverterterToVisible()
            };
            BindingOperations.SetBinding(LoadingProgressBar, VisibilityProperty, b);
            Task.Run(() => searchVM.GetSearchResults());
        }

        private void searchTB_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                searchBT_Click(this, new RoutedEventArgs());
            }
        }
    }
}
