using BE;
using BL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject_8327_4647.Models
{
    class NearEarthModel
    {
        BLClass bLClass;

        public NearEarthModel()
        {
            bLClass = new BLClass();
        }
        public List<NEO> getNearEarthObject(string start, string end, bool hazard, int minSize)
        {
            return (from element in Task.Run(() => bLClass.getNearEarthObject(start, end)).Result
                    where element.IsPotentiallyHazardousAsteroid == hazard
                    && element.EstimatedDiameter > minSize
                    select element).ToList();
        }
    }
}
