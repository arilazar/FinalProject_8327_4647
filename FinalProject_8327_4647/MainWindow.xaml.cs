using FinalProject_8327_4647.UserControls;
using System.Windows;
using System.Windows.Controls;

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
            DataContext = this;
            ImageDayCMD();
        }
        public RelayCommand Cmd1 => new RelayCommand(ImageDayCMD);
        public RelayCommand Cmd2 => new RelayCommand(PlanetsCMD);
        public RelayCommand Cmd3 => new RelayCommand(ImageSearchCMD);
        public RelayCommand Cmd4 => new RelayCommand(NearEarthObjectsCMD);
        public RelayCommand Cmd5 => new RelayCommand(ExitCMD);

        private void ImageDayCMD()
        {
            DoCMD(new ImageDayUC());
        }

        private void PlanetsCMD()
        {
            DoCMD(new PlanetsProfiles());
        }

        private void ImageSearchCMD()
        {
            DoCMD(new ImageSearchUC());
        }
        private void NearEarthObjectsCMD()
        {
            DoCMD(new NearEarthObjectsUC());
        }
        private void ExitCMD()
        {
            Application.Current.Shutdown();
        }

        private void DoCMD(UIElement uc)
        {
            if (currentUserControl != null)
                myGrid.Children.Remove(currentUserControl);
            currentUserControl = uc;
            Grid.SetColumn(currentUserControl, 0);
            myGrid.Children.Add(currentUserControl);
        }
    }
}
