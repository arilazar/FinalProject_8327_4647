using System.Windows;
using System.Windows.Controls;
using FinalProject_8327_4647.UserControls;

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
            //DoStuff1();
        }
        public RelayCommand Cmd1 => new RelayCommand(DoStuff1);
        public RelayCommand Cmd2 => new RelayCommand(DoStuff2);
        public RelayCommand Cmd3 => new RelayCommand(DoStuff3);
        public RelayCommand Cmd4 => new RelayCommand(DoStuff4);
        public RelayCommand Cmd5 => new RelayCommand(DoStuff5);

        private void DoStuff1()
        {
            DoStuff(new ImageDayUC());
        }

        private void DoStuff2()
        {
            DoStuff(new PlanetsProfiles());
        }

        private void DoStuff3()
        {
            DoStuff(new ImageSearchUC());
        }
        private void DoStuff4()
        {
            DoStuff(new NearEarthObjectsUC());
        }
        private void DoStuff5()
        {
            Close();
        }

        private void DoStuff(UIElement uc)
        {
            if (currentUserControl != null)
                myGrid.Children.Remove(currentUserControl);
            currentUserControl = uc;
            Grid.SetColumn(currentUserControl, 0);
            myGrid.Children.Add(currentUserControl);
        }
    }
}
