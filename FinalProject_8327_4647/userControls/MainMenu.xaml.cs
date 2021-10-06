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

namespace FinalProject_8327_4647
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
            this.MyCarousel.ItemsSource = GetStars();

        }

         static ObservableCollection<Star> GetStars()
        {
            ObservableCollection<Star> stars = new ObservableCollection<Star>();
            Star star = new Star();
            star.Name = "וונוס";
            star.Size = "100";
            stars.Add(star);

            star = new Star();
            star.Name = "שבתאי";
            star.Size = "400";
            stars.Add(star);

            star = new Star();
            star.Name = "צדק";
            star.Size = "600";
            stars.Add(star);

            star = new Star();
            star.Name = "כוכב 4";
            star.Size = "700";
            stars.Add(star);

            star = new Star();
            star.Name = "כוכב 6";
            star.Size = "8000";
            stars.Add(star);

            star = new Star();
            star.Name = "כובכ 456";
            star.Size = "900";
            stars.Add(star);


            return stars;
        }
    }
}
