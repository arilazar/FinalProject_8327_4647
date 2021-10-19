using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BE;
using DL;

namespace BL
{
    public class BLClass
    {
        IEnumerable<SearchImage> collection;

        Http http = new Http();
        public APOD getAPOD()
        {
            return http.getAPOD();
        }

        public IEnumerable<SearchImage> GetSearchResults(string search)
        {
            IEnumerable<SearchImage> collection = from item in http.GetSearchImages(search).Result.collection.items
                                                  select new SearchImage(item.data[0].title,
                                                                         item.data[0].description,
                                                                         item.links[0].href);

            //collection = new List<Item>(http.GetSearchImages(search).Result.collection.items);
            return collection;
        }
    }
}
