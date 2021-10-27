using BE;
using FinalProject_8327_4647.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_8327_4647.ViewModels
{
    class NearEarthVM
    {
        NearEarthModel model;
        public NearEarthVM()
        {
            model = new NearEarthModel();
        }

        private NearEarth nearEarthObjects;

        public NearEarth NearEarthObjects
        {
            get { return nearEarthObjects; }
            set { nearEarthObjects = value; }
        }

        public void GetNearEarthObjects(string start, string end)
        {
            NearEarthObjects = model.getNearEarthObject(start, end).Result;
        }
    }
}
