using System.Threading;
using System.Windows;
using System.Windows.Controls;
using FinalProject_8327_4647.ViewModels;

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
            var thread = new Thread(() =>
            {
                searchVM.GetSearchResults(searchVM.SearchVal);
            });
            thread.Start();
        }
    }
}
