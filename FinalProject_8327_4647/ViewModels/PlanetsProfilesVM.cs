﻿using System;
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
        private Models.PlanetsProfilesModel model;

        private List<Planets> _solarSystemPlanets;
        public List<Planets> SolarSystemPlanets
        {
            get { return _solarSystemPlanets; }
            set { _solarSystemPlanets = value; }
        }

        public PlanetsProfilesVM()
        {
            model = new Models.PlanetsProfilesModel();
            SolarSystemPlanets = model.GetSolarSystem();
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
