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
        public async Task<List<NEO>> getNearEarthObject(string start, string end, int minSize)
        {
            return await bLClass.getNearEarthObject(start, end);
        }
    }
}
