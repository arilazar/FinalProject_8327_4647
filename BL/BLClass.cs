using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DL;

namespace BL
{
    public class BLClass
    {
        DLClass myDL = new DLClass();
        StarService StarServ = new StarService();

        public async Task<APOD> getAPOD()
        {
            return await myDL.getAPOD();
        }
        public async Task<List<SearchImage>> GetSearchResults(string search, double confidence)
        {
            List<SearchImage> allImagesList = await myDL.GetSearchImages(search);
            List<SearchImage> filteredImagesList = new List<SearchImage>();
            if (confidence <= 30)
                return allImagesList;
            Parallel.ForEach(allImagesList, image =>
            {
                TagResult tag = myDL.getTag(image.Url);
                if (tag.status.type == "success" && tag.result != null)
                    if (tag.result.tags.Any((x) => x.confidence >= confidence && x.tag.en == "planet"))
                        filteredImagesList.Add(image);
            });
            if (filteredImagesList.Count == 0)
                return allImagesList;
            Console.WriteLine("filter success!");
            Console.WriteLine("תמונות שנשארו לאחר סינון " + filteredImagesList.Count);
            return filteredImagesList;
        }

        public async Task<List<NEO>> getNearEarthObject(string start, string end)
        {
            return await myDL.getNearEarthObject(start, end);
        }

        //first virsion
        //public ObservableCollection<Star> GetPlanets()
        //{
        //    return new ObservableCollection<Star>(StarServ.GetPlanets());
        //}

        public List<Planets> GetSolarSystem()
        {
            return myDL.GetSolarSysytem();
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
