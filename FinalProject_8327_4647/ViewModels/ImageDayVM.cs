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
using BE;
using BL;

namespace FinalProject_8327_4647.ViewModels
{
    public class ImageDayVM
    {
        ImageDayModel model = new ImageDayModel();
        public string UrlImage => Task.Run(() => model.getApod()).Result.url;
        public string Title => Task.Run(() => model.getApod()).Result.title;
        public string Description => Task.Run(() => model.getApod()).Result.explanation;
    }
}
