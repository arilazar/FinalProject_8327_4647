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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UIElement currentUserControl = null;
        public MainWindow()
        {
            InitializeComponent();
            currentUserControl = new page1();
            myGrid.Children.Add(currentUserControl);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (currentUserControl != null)
                myGrid.Children.Remove(currentUserControl);
            currentUserControl = new MainMenu();
            myGrid.Children.Add(currentUserControl);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (currentUserControl != null)
                myGrid.Children.Remove(currentUserControl);
            currentUserControl = new page1();
            myGrid.Children.Add(currentUserControl);
        }
    }
}
