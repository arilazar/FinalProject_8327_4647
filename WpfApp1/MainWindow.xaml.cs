using BE;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            GetSearchImages("moon");
        }

        private HttpClient httpClient;

        private const string BaseUrl = "https://images-api.nasa.gov/search?q=";
        private const string EndUrl = "&media_type=image";

        public async Task<ImageSearchResult> GetSearchImages(string search)
        {
            var response = await httpClient.GetAsync(BaseUrl + search + EndUrl);
            var html = await response.Content.ReadAsStringAsync();
            ImageSearchResult myDeserializedClass = JsonConvert.DeserializeObject<ImageSearchResult>(html);
            return myDeserializedClass;
        }
    }
}
