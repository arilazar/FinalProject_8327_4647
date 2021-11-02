using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;

namespace FinalProject_8327_4647.Models
{
    class PlanetsProfilesModel
    {
        BLClass bl;
        public PlanetsProfilesModel()
        {
            bl = new BLClass();
        }

        public async Task<List<Planets>> GetSolarSystem()
        {
            return await bl.GetSolarSystem();
        }
    }
}
