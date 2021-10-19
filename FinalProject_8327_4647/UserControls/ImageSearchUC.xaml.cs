using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using BE;
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
            InitializeComponent();
            searchVM = new ImageSearchVM();
            DataContext = searchVM;
        }
    }
}
