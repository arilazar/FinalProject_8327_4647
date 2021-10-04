using FinalProject_8327_4647.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace FinalProject_8327_4647.ViewModels
{
    class ImageDayViewModel
    {
        string apiKey = "?api_key=dKGbkafEfGBA8WM7V5LwguoCAIoP9DfhITdKbb59";
        //private Uri imageUri = @"https://api.nasa.gov/planetary/apod?api_key=dKGbkafEfGBA8WM7V5LwguoCAIoP9DfhITdKbb59";
        public string imageDayUri
        {
            get { return @"https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY" + apiKey; }
        }
    }
}
