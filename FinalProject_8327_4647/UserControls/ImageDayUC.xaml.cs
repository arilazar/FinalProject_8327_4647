using FinalProject_8327_4647.ViewModels;
using System.Windows.Controls;

namespace FinalProject_8327_4647
{
    /// <summary>
    /// Interaction logic for ImageDayUserControl.xaml
    /// </summary>
    public partial class ImageDayUC : UserControl
    {
        private readonly ImageDayVM viewModel = new ImageDayVM();

        public ImageDayUC()
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
