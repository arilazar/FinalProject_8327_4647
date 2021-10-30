using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;

namespace FinalProject_8327_4647.ViewModels
{
    class PlanetsProfilesVM
    {
        BLClass bLClass;

        public PlanetsProfilesVM(){
            bLClass = new BLClass();
        }

        private ObservableCollection<Star> _starsList;
        public ObservableCollection<Star> StarsList
        {
            get { return _starsList; }
            set
            {
                _starsList = value;
                OnPropertyChanged("StarsList");
            }
        }


        //public void GetPlanets()
        //{
        //    StarsList = new ObservableCollection<Star>(bLClass.GetPlanets());
        //}

        public ObservableCollection<Star> GetPlanets()
        {
            return new ObservableCollection<Star>(bLClass.GetPlanets());
        }

        #region "INotifyPropertyChanged members"

        public event PropertyChangedEventHandler PropertyChanged;

        //This routine is called each time a property value has been set.
        //This will cause an event to notify WPF via data-bindingthat a change has occurred.
        private void OnPropertyChanged(string propertyName)
        {

            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }

        }
        #endregion

    }
}
