using FinalProject_8327_4647.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FinalProject_8327_4647.ViewModels
{
    class ImageDayViewModel
    {
        public ImageDayContext Context { get; set; }

        private HttpClient httpClient;
        private readonly Regex imgRegex = new Regex("<br>\\s+<a href=\"(?<link>.*?)\">\\s<img src=\"(?<src>.*?)\"", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private readonly Regex titleRegex = new Regex("<b>(?<title>.*?)</b>\\s?<br>", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private const string BaseUrl = "https://apod.nasa.gov/apod/";

        public async Task GetLatestImageAsync()
        {
            httpClient = new HttpClient();
            this.Context = new ImageDayContext
            {
                Title = "Loading..."
            };

            this.Context.ValidImage = false;
            var html = await this.GetHtmlAsync();
            var matches = this.imgRegex.Match(html);

            var imageUrl = matches.Groups["link"]?.Value ?? matches.Groups["src"]?.Value;
            if (string.IsNullOrWhiteSpace(imageUrl))
            {
                MessageBox.Show("Unable to parse image url from html");
                this.Context.Title = "Error";
                this.Context.Status = "Unable to parse image url from html";

                return;
            }

            var imageData = await this.httpClient.GetAsync(BaseUrl + imageUrl);
            if (!imageData.IsSuccessStatusCode)
            {
                MessageBox.Show("Unable to download latest image. status code: " + imageData.StatusCode);
                this.Context.Title = "Error";
                this.Context.Status = "Unable to download latest image. status code: " + imageData.StatusCode;

                return;
            }

            var stream = await imageData.Content.ReadAsStreamAsync();
            try
            {
                this.Context.ImageSource = BitmapFrame.Create(stream, BitmapCreateOptions.IgnoreImageCache, BitmapCacheOption.OnLoad);
                this.Context.Filename = imageUrl.Split('/').Last();

                var titleMatch = this.titleRegex.Match(html).Groups["title"]?.Value;

                this.Context.Title = titleMatch ?? this.Context.Filename;

                this.Context.ValidImage = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error creating image context - this might be a video.\n" + e.Message);
                this.Context.Status = "Error creating image context";
            }
        }

        private async Task<string> GetHtmlAsync()
        {
            var response = await this.httpClient.GetAsync(BaseUrl + "astropix.html");
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Unable to open apod homepage. status code: " + response.StatusCode);
                this.Context.Title = "Error";

                return string.Empty;
            }

            var html = await response.Content.ReadAsStringAsync();
            return html;
        }





        //string apiKey = "?api_key=dKGbkafEfGBA8WM7V5LwguoCAIoP9DfhITdKbb59";


        //private Uri imageUri = @"https://api.nasa.gov/planetary/apod?api_key=dKGbkafEfGBA8WM7V5LwguoCAIoP9DfhITdKbb59";

    }
}
