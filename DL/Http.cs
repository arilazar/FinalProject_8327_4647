using BE;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace DL
{
    public class Http
    {
        //public ImageContext Context { get; set; }
        private HttpClient httpClient;

        private const string BaseUrl = "https://images-api.nasa.gov/search?q=";
        private const string EndUrl = "&media_type=image";
        public Http()
        {
            httpClient = new HttpClient();
        }

        public async Task<ImageSearchResult> GetSearchImages(string search)
        {
            var response = httpClient.GetStringAsync(BaseUrl + search + EndUrl);
            //var html = await response.Content.ReadAsStringAsync();
            //var html = GetHtml(BaseUrl + search + EndUrl);
            ImageSearchResult myDeserializedClass = JsonConvert.DeserializeObject<ImageSearchResult>(response.Result);
            return myDeserializedClass;
        }

        private async Task<string> GetHtml(string url)
        {
            //var response = await httpClient.GetStringAsync(url /*BaseUrl + search + EndUrl*/);
            var response = await httpClient.GetAsync(url /*BaseUrl + search + EndUrl*/);
            var html = await response.Content.ReadAsStringAsync();
            return html;
            //return response;
        }

        public APOD getAPOD()
        {
            string url = "https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY";
            var html = GetHtml(url);
            APOD myDeserializedClass = JsonConvert.DeserializeObject<APOD>(html.Result);
            return myDeserializedClass;
        }
    }
}