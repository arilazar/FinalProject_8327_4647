using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            //var count = jsonValue.ElementCount;
            //List<NearEarthObject> returnList = new List<NearEarthObject>();
            //foreach (KeyValuePair<string, NearEarthObject[]> day in jsonValue.NearEarthObjects)
            //    foreach (var element in day.Value)
            //        returnList.Add(element);
            //return returnList;
        }
    }
}
