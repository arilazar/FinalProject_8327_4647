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
using FinalProject_8327_4647.ViewModels;
using BE;


namespace FinalProject_8327_4647
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class PlanetsProfiles : UserControl
    {
        private PlanetsProfilesVM planetsProfilesVM;

        public PlanetsProfiles()
        {
            planetsProfilesVM = new PlanetsProfilesVM();
            Task.Run(() => planetsProfilesVM.GetSolarSystem());
            DataContext = planetsProfilesVM;
            InitializeComponent();
        }

        /*topItem Changed evant of the carusel*/
        private void Panel_TopContainerChanged(object sender, RoutedEventArgs e)
        {
            var carousel = e.OriginalSource as RadCarouselPanel;

            var topContainer = carousel.TopContainer;
            var item = (topContainer as CarouselItem).DataContext as Planets;
            if (item != null)
            {
                GridDiscription.DataContext = item;
                var strList = item.SurfaceArea.Split('^');
                SurfaceTxtBlock.Text = strList[0];
                if (strList.Length > 1)
                    txtBlock1.Text = strList[1];
                strList = item.Mass.Split('^');
                MassTxtBlock.Text = strList[0];
                txtBlock2.Text = strList[1];
            }
        }


    }
}