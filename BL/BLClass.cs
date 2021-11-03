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

        public async Task<APOD> getAPOD()
        {
            return await myDL.getAPOD();
        }
        public async Task<List<SearchImage>> GetSearchResults(string search, double confidence)
        {
            ImageSearchResult searchResult = await myDL.GetSearchImages(search);
            var allImagesList = new List<SearchImage>();

            foreach (Item item in searchResult.collection.items)
            {
                if (item.links != null)
                {
                    allImagesList.Add(new SearchImage(item.data[0].title,
                        item.data[0].description,
                        item.links.FirstOrDefault().href));
                }
            }

            if (confidence <= 30)
                return allImagesList;

            List<SearchImage> filteredImagesList = new List<SearchImage>();

            Parallel.ForEach(allImagesList, image =>
            {
                TagResult tag = myDL.getTag(image.Url);
                if (tag.status.type == "success" && tag.result != null)
                    if (tag.result.tags.Any((x) => x.confidence >= confidence && x.tag.en == "planet"))
                        filteredImagesList.Add(image);
            });
            //if (filteredImagesList.Count == 0)
            //    return allImagesList;
            return filteredImagesList;
        }

        public async Task<List<NEO>> getNearEarthObject(string start, string end)
        {
            NearEarth nearEarthObject = await myDL.getNearEarthObject(start, end);
            var x = (from KeyValuePair<string, NearEarthObject[]> day in nearEarthObject.NearEarthObjects
                     from NearEarthObject nearEarthObj in day.Value
                     select nearEarthObj).ToList();
            var neoList = new List<NEO>();

            foreach (KeyValuePair<string, NearEarthObject[]> day in nearEarthObject.NearEarthObjects)
            {
                foreach (NearEarthObject neo in day.Value)
                {
                    neoList.Add(new NEO(
                        day.Key,
                        neo.Id,
                        neo.Name,
                        neo.AbsoluteMagnitudeH,
                        neo.EstimatedDiameter.Meters.EstimatedDiameterMin,
                        neo.IsPotentiallyHazardousAsteroid));
                }
            }
            return neoList;
        }

        public async Task<List<Planets>> GetSolarSystem()
        {
            return await myDL.GetSolarSysytem();
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
