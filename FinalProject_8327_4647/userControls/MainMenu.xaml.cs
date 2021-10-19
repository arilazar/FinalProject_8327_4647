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
using Telerik.Windows.Controls;
using Telerik.Windows.Data;


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
            star.Name = "כוכב חמה - מרקורי";
            star.Size = "700";
            star.ImageUrl = @"\Images\Mercury.png";
            stars.Add(star);

            star = new Star();
            star.Name = "נוגה - וונוס";
            star.Size = "100";
            star.ImageUrl = @"\Images\Venus.png";
            stars.Add(star);

            star = new Star();
            star.Name = "כדור הארץ";
            star.Size = "400";
            star.ImageUrl = @"\Images\Earth.png";
            stars.Add(star);

            star = new Star();
            star.Name = "מאדים - מארס";
            star.Size = "600";
            star.ImageUrl = @"\Images\Mars.png";
            stars.Add(star);

            star = new Star();
            star.Name = "צדק - יופיטר";
            star.Size = "8000";
            star.ImageUrl = @"\Images\Jupiter.png";
            stars.Add(star);

            star = new Star();
            star.Name = "שבתאי - סטורנוס";
            star.Size = "900";
            star.ImageUrl = @"\Images\Saturn.png";
            stars.Add(star);

            star = new Star();
            star.Name = "אורון - אורנוס";
            star.Size = "50000";
            star.ImageUrl = @"\Images\Uranus.png";
            stars.Add(star);

            star = new Star();
            star.Name = "רהב - נפטון";
            star.Size = "10000";
            star.ImageUrl = @"\Images\Neptune.png";
            stars.Add(star);


            return stars;
        }

        /*click evant on the carusel item*/
        private void RadCarousel_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            //var carousel = e.OriginalSource as RadCarousel;
            //var selected = carousel.SelectedItem as Star;

            //if (selected != null)
            //{
            //    MessageBox.Show(selected.Name);
            //}
        }

        /*topItem Changed evant of the carusel*/
        private void Panel_TopContainerChanged(object sender, RoutedEventArgs e)
        {
            var carousel = e.OriginalSource as RadCarouselPanel;

            var topContainer = carousel.TopContainer;
            var item = (topContainer as CarouselItem).DataContext as Star;
            if (item != null)
            {
                Dispatcher.BeginInvoke(new Action(() => MessageBox.Show(item.Name)),
                            System.Windows.Threading.DispatcherPriority.Normal);
            }

        }
    }
}