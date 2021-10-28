using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BE
{
    public class SearchImage : INotifyPropertyChanged
    {
        public SearchImage(string title, string description, string url)
        {
            Title = title;
            Description = description;
            Url = url;
        }
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        //private DateTime date;
        //public DateTime Date
        //{
        //    get { return date; }
        //    set { date = value; }
        //}

        private string url;
        public string Url
        {
            get { return url; }
            set
            {
                if (value == this.title)
                    return;
                this.url = value;
                this.OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
