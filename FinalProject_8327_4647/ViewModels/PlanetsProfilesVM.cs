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
        public PlanetsProfilesVM()
        {
            model = new Models.PlanetsProfilesModel();
        }
        
        private Models.PlanetsProfilesModel model;

        private List<Planets> _solarSystemPlanets;
        public List<Planets> SolarSystemPlanets
        {
            get { return _solarSystemPlanets; }
            set { _solarSystemPlanets = value; }
        }

        internal async void GetSolarSystem()
        {
            SolarSystemPlanets = await model.GetSolarSystem();
        }
    }
}
