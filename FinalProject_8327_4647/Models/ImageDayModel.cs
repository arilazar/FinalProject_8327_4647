using BE;
using BL;
using System.Threading.Tasks;

namespace FinalProject_8327_4647
{
    public class ImageDayModel
    {   
        BLClass bLClass;

        public ImageDayModel()
        {
            bLClass = new BLClass();
        }

        public async Task<APOD> getApod()
        {
            return await bLClass.getAPOD();
        }
    }
}
