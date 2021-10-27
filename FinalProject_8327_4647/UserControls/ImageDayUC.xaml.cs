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
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
