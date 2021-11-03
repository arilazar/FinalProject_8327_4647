using FinalProject_8327_4647.ViewModels;
using System.Windows.Controls;
using System.Windows;

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

        private void Image_MouseDown(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (descriptionBorder.Visibility == Visibility.Visible)
                descriptionBorder.Visibility = Visibility.Hidden;
            else
                descriptionBorder.Visibility = Visibility.Visible;
        }
    }
}
