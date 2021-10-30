using BE;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DL
{
    public class DLClass
    {
        private HttpClient httpClient;

        private const string BaseUrl = "https://images-api.nasa.gov/search?q=";
        private const string EndUrl = "&media_type=image";
        public DLClass()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<SearchImage>> GetSearchImages(string search)
        {
            string response = await httpClient.GetStringAsync(BaseUrl + search + EndUrl);
            ImageSearchResult searchResult = JsonConvert.DeserializeObject<ImageSearchResult>(response);
            var imagesList = new List<SearchImage>();

            foreach (Item item in searchResult.collection.items)
            {
                if (item.links != null)
                {
                    imagesList.Add(new SearchImage(item.data[0].title,
                        item.data[0].description,
                        item.links.FirstOrDefault().href));
                }
            }
            return imagesList;
        }

        public async Task<APOD> getAPOD()
        {
            string url = "https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY";
            string responseBody = await httpClient.GetStringAsync(url);
            APOD myDeserializedClass = JsonConvert.DeserializeObject<APOD>(responseBody);
            return myDeserializedClass;
        }

        public TagResult getTag(string imageUrl)
        {
            string apiKey = "acc_c282840c1b7255d";
            string apiSecret = "d8fb6f7ef0ff13f918f61f9fa7cc8053";
            //string authorization = "Basic YWNjX2MyODI4NDBjMWI3MjU1ZDpkOGZiNmY3ZWYwZmYxM2Y5MThmNjFmOWZhN2NjODA1Mw==";

            RestClient client = new RestClient("https://api.imagga.com/v2/tags");
            //string imageUrl = "https://docs.imagga.com/static/images/docs/sample/japan-605234_1280.jpg";
            string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));

            client.Timeout = -1;

            var request = new RestRequest(Method.GET);
            request.AddParameter("image_url", imageUrl);
            request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));

            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<TagResult>(response.Content);
        }

        public void getFromFirebaseStorage(string fileName)
        {

            string path = "https://console.firebase.google.com/u/0/project/stars-tracking/storage/stars-tracking.appspot.com/files/";
            string uri = $"{path}{fileName}.png?alt=media";
        }

        public async Task<List<NEO>> getNearEarthObject(string start, string end)
        {
            string APIKEY = "dKGbkafEfGBA8WM7V5LwguoCAIoP9DfhITdKbb59";
            string uri = $"https://api.nasa.gov/neo/rest/v1/feed?start_date={start}&end_date={end}&api_key={APIKEY}";
            string responseBody = await httpClient.GetStringAsync(uri);

            NearEarth nearEarth = NearEarth.FromJson(responseBody);
            var x = (from KeyValuePair<string, NearEarthObject[]> day in nearEarth.NearEarthObjects
                     from NearEarthObject nearEarthObj in day.Value
                     select nearEarthObj).ToList();
            var neoList = new List<NEO>();

            foreach (KeyValuePair<string, NearEarthObject[]> day in nearEarth.NearEarthObjects)
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

    }
}