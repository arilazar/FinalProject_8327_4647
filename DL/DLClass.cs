using BE;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DL
{
    public class DLClass
    {
        private HttpClient httpClient;

        /*Old
        private const string IMAGGA_API_KEY = "acc_c282840c1b7255d";
        private const string IMAGGA_API_SECRET = "d8fb6f7ef0ff13f918f61f9fa7cc8053";*/
        //New
        private const string IMAGGA_API_KEY = "acc_607ee6802fc767d";
        private const string IMAGGA_API_SECRET = "5bdc3f449e0034b600707d31d7f8669d";
        private const string NASA_APIKEY = "dKGbkafEfGBA8WM7V5LwguoCAIoP9DfhITdKbb59";

        public DLClass()
        {
            httpClient = new HttpClient();
            initializeDB();
        }

        public async Task<List<Planets>> GetSolarSysytem()
        {
            using (var ctx = new PlanetsDB())
            {
                return await ctx.PlanetsDataSet.ToListAsync();
            }
        }

        public async Task<APOD> getAPOD()
        {
            string url = "https://api.nasa.gov/planetary/apod?api_key=" + NASA_APIKEY;
            string responseBody;
            responseBody = await httpClient.GetStringAsync(url);
            APOD myDeserializedClass = JsonConvert.DeserializeObject<APOD>(responseBody);
            return myDeserializedClass;
        }

        public async Task<ImageSearchResult> GetSearchImages(string search)
        {
            const string BaseUrl = "https://images-api.nasa.gov/search?q=";
            const string EndUrl = "&media_type=image";
            string response = await httpClient.GetStringAsync(BaseUrl + search + EndUrl);
            return JsonConvert.DeserializeObject<ImageSearchResult>(response);
        }

        public async Task<NearEarth> getNearEarthObject(string start, string end)
        {
            string uri = $"https://api.nasa.gov/neo/rest/v1/feed?start_date={start}&end_date={end}&api_key={NASA_APIKEY}";
            string responseBody = await httpClient.GetStringAsync(uri);
            return NearEarth.FromJson(responseBody);
        }

        public TagResult getTag(string imageUrl)
        {
            RestClient client = new RestClient("https://api.imagga.com/v2/tags");
            string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", IMAGGA_API_KEY, IMAGGA_API_SECRET)));
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddParameter("image_url", imageUrl);
            request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<TagResult>(response.Content);
        }

        private void initializeDB()
        {
            Task.Run(() =>
            {
                using (var dbcontext = new PlanetsDB())
                {
                    //dbcontext.PlanetsDataSet.RemoveRange(dbcontext.PlanetsDataSet.ToList());
                    //dbcontext.SaveChanges();
                    if (dbcontext.PlanetsDataSet.ToList().Count == 0)
                    {
                        var link = "https://firebasestorage.googleapis.com/v0/b/stars-tracking-63e30.appspot.com/o/";

                        //Venus
                        dbcontext.PlanetsDataSet.Add(new Planets()
                        {
                            Name = "Venus",
                            GeneralInfo = "Venus is the second planet far from the Sun. Venus' orbit is the closest to Earth's orbit, and its size is close to Earth's size. The most striking feature of Venus is the immense heat that prevails on its surface, more than any other planet in the solar system.",
                            Category = "Terrestrial planet",
                            Location = "Inner Solar System",
                            AvgDistanceFromSun = "108,208,926",
                            OrbitalPeriod = "224.7",
                            AvgOrbitalSpeed = "35.02",
                            Inclination = "3.39471",
                            Satellites = "0",
                            Radius = "6,052",
                            SurfaceArea = "4.6×10^8",
                            Mass = "4.8685×10^24",
                            Density = "5.204",
                            RotationPeriod = "117",
                            RotationSpeed = "0.0018",
                            AxialTilt = "2.64",
                            AvgSurfaceTemp = "436.8",
                            ImageUrl = $"{link}Venus.png?alt=media&token=208b3b65-9eb5-47b1-b07e-3ce9d05bea88"
                        });
                        //Mercury
                        dbcontext.PlanetsDataSet.Add(new Planets()
                        {
                            Name = "Mercury",
                            GeneralInfo = "Mercury is the closest planet to the Sun. In terms of mass, it is the eighth and smallest planet in the solar system. It is much smaller than Earth, and similar in size to the Moon. Gravity on its surface is 2.5 times smaller than on Earth. The sunrise is visible on its surface once every two years - a unique phenomenon in the solar system.",
                            Category = "Terrestrial planet",
                            Location = "Inner Solar System",
                            AvgDistanceFromSun = "57,909,176",
                            OrbitalPeriod = "87.96",
                            AvgOrbitalSpeed = "47.36",
                            Inclination = "7.00487",
                            Satellites = "0",
                            Radius = "2,439",
                            SurfaceArea = "7.5×10^7",
                            Mass = "3.302×10^23",
                            Density = "5.427",
                            RotationPeriod = "58.64",
                            RotationSpeed = "0.0030",
                            AxialTilt = "0.01",
                            AvgSurfaceTemp = "166.85",
                            ImageUrl = $"{link}Mercury.png?alt=media&token=f6b440c0-43e4-47fa-bc2e-64bd58579cdd"
                        });
                        //Earth
                        dbcontext.PlanetsDataSet.Add(new Planets()
                        {
                            Name = "Earth",
                            GeneralInfo = "Earth is the third planet in the solar system and the fifth largest in the system, and the largest of the four terrestrial planets. Earth is the only known celestial body that contains life forms.",
                            Category = "Terrestrial planet",
                            Location = "Inner Solar System",
                            AvgDistanceFromSun = "149,598,0236",
                            OrbitalPeriod = "365.25",
                            AvgOrbitalSpeed = "29.783",
                            Inclination = "0",
                            Satellites = "1",
                            Radius = "6,378",
                            SurfaceArea = "510,065,600",
                            Mass = "5.9742×10^24",
                            Density = "5.5153",
                            RotationPeriod = "23.93",
                            RotationSpeed = "0.4651",
                            AxialTilt = "23.436",
                            AvgSurfaceTemp = "14",
                            ImageUrl = $"{link}Earth.png?alt=media&token=73e28541-3ef8-4821-ae85-940d7ea40ba6"
                        });
                        //Mars
                        dbcontext.PlanetsDataSet.Add(new Planets()
                        {
                            Name = "Mars",
                            GeneralInfo = "Mars is the fourth planet in the solar system. Its orbit is the second closest to Earth's orbit (after Venus) and is the second smallest planet, larger only than a hot star. The color of Mars' face is reddish due to the abundance of iron oxides in its soil. On Mars is the highest mountain in the solar system, the volcano Olympus Mons - 27 km high.",
                            Category = "Terrestrial planet",
                            Location = "Inner Solar System",
                            AvgDistanceFromSun = "227,936,637",
                            OrbitalPeriod = "686.971",
                            AvgOrbitalSpeed = "24.077",
                            Inclination = "1.85061",
                            Satellites = "2",
                            Radius = "3,396.2",
                            SurfaceArea = "1.448×10^8",
                            Mass = "6.4191×10^23",
                            Density = "3.94",
                            RotationPeriod = "24.622",
                            RotationSpeed = "0.241",
                            AxialTilt = "25.19",
                            AvgSurfaceTemp = "-63.15",
                            ImageUrl = $"{link}Mars.png?alt=media&token=501be908-c8e2-4e5e-b3e7-387c4a5c79f1"
                        });
                        //Neptune
                        dbcontext.PlanetsDataSet.Add(new Planets()
                        {
                            Name = "Neptune",
                            GeneralInfo = "Neptune is the eighth planet in the solar system. It is the smallest of the four gas giants and is classified in the Ice Giant subcategory because it is covered with a layer of water and ice. Neptune, is in orbital resonance with the dwarf planet Pluto.",
                            Category = "Gas giant",
                            Location = "Outer Solar System",
                            AvgDistanceFromSun = "4,498,252,900",
                            OrbitalPeriod = "60,190",
                            AvgOrbitalSpeed = "5.432",
                            Inclination = "1.76917",
                            Satellites = "14",
                            Radius = "24,786",
                            SurfaceArea = "‎7.65×10^9",
                            Mass = "1.024×10^26‎",
                            Density = "1.64",
                            RotationPeriod = "0.67",
                            RotationSpeed = "2.68",
                            AxialTilt = "29.58",
                            AvgSurfaceTemp = "-212",
                            ImageUrl = $"{link}Neptune.png?alt=media&token=5805b0ca-04be-4cd7-bed7-759229b2b2ee"
                        });
                        //Jupiter
                        dbcontext.PlanetsDataSet.Add(new Planets()
                        {
                            Name = "Jupiter",
                            GeneralInfo = "Jupiter is a gas giant and planet with the largest mass in the solar system, the fifth farthest from the sun and the first in the gaseous planet category. Jupiter is made mainly of gas: about 90% of its mass is hydrogen and about 10% is helium.",
                            Category = "Gas giant",
                            Location = "Outer Solar System",
                            AvgDistanceFromSun = "778,340,821",
                            OrbitalPeriod = "4,332.58",
                            AvgOrbitalSpeed = "13.0697",
                            Inclination = "1.30530",
                            Satellites = "79",
                            Radius = "71,492",
                            SurfaceArea = "6.41×10^10",
                            Mass = "1.899×10^27",
                            Density = "1.326",
                            RotationPeriod = "0.41",
                            RotationSpeed = "12.6",
                            AxialTilt = "3.12",
                            AvgSurfaceTemp = "-121",
                            ImageUrl = $"{link}Jupiter.png?alt=media&token=6d0fdeac-0e1e-426b-98cc-347115b23b2a"
                        });
                        //Saturn
                        dbcontext.PlanetsDataSet.Add(new Planets()
                        {
                            Name = "Saturn",
                            GeneralInfo = "Saturn is the sixth planet farthest from the Sun and the second in a series of gaseous planets. Saturn is surrounded by planetary rings called Saturn's rings, which contain mostly ice and dust. Because Saturn was the seventh planet in ancient times, the seventh day of the week was named Saturday.",
                            Category = "Gas giant",
                            Location = "Outer Solar System",
                            AvgDistanceFromSun = "1,426,725,413",
                            OrbitalPeriod = "10,832.327",
                            AvgOrbitalSpeed = "9.639",
                            Inclination = "2.488",
                            Satellites = "82",
                            Radius = "60,268",
                            SurfaceArea = "4.27×10^10",
                            Mass = "5.8646×10^26",
                            Density = "0.687",
                            RotationPeriod = "0.44",
                            RotationSpeed = "9.87",
                            AxialTilt = "26.73",
                            AvgSurfaceTemp = "-130",
                            ImageUrl = $"{link}Saturn.png?alt=media&token=c0a041f9-5ced-46b2-b297-a35c06a985df"
                        });
                        //Uranus
                        dbcontext.PlanetsDataSet.Add(new Planets()
                        {
                            Name = "Uranus",
                            GeneralInfo = "Uranus is the seventh planet far from the Sun. Uranus is one of the four gas giants and is classified in the ice giant sub-category. It is composed mainly of hydrogen and helium and in its center is a molten core of iron and silicates surrounded by a thick layer of ice, methane and ammonia. Beyond the solid layers lies the thick atmosphere composed of hydrogen and helium.",
                            Category = "Gas giant",
                            Location = "Outer Solar System",
                            AvgDistanceFromSun = "2,870,972,220",
                            OrbitalPeriod = "30,799.095",
                            AvgOrbitalSpeed = "6.795",
                            Inclination = "0.76986",
                            Satellites = "27",
                            Radius = "25,559",
                            SurfaceArea = "8.13×10^9",
                            Mass = "8.686×10^25",
                            Density = "1.29",
                            RotationPeriod = "0.72",
                            RotationSpeed = "2.59",
                            AxialTilt = "97.86",
                            AvgSurfaceTemp = "-220",
                            ImageUrl = $"{link}Uranus.png?alt=media&token=947876d8-618d-441b-9a5a-e238c1ce0462"
                        });
                        dbcontext.SaveChanges();
                    }
                }
            });
        }
    }
}