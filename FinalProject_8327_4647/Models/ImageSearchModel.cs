using BE;
using BL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject_8327_4647.ViewModels
{
    public class ImageSearchModel
    {
        BLClass myBL;

        public ImageSearchModel()
        {
            this.myBL = new BLClass();
        }

        public Task<List<SearchImage>> GetSearchImages(string SearchVal, double confidence)
        {
            return myBL.GetSearchResults(SearchVal, confidence);
        }
    }
}