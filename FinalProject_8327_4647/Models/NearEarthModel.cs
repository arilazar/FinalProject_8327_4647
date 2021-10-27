using BE;
using BL;
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
        public async Task<NearEarth> getNearEarthObject(string start, string end)
        {
            return await bLClass.getNearEarthObject(start, end); 
        }
    }
}
