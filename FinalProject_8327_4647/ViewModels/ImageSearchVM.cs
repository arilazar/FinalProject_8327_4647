using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BE;

namespace FinalProject_8327_4647.ViewModels
{
    public class ImageSearchVM : INotifyPropertyChanged
    {
        ImageSearchModel model;

        public ImageSearchVM()
        {
            model = new ImageSearchModel();
        }

        private ObservableCollection<SearchImage> searchImageCollection = new ObservableCollection<SearchImage>();
        public ObservableCollection<SearchImage> SearchImageCollection
        {
            get
            {
                return searchImageCollection;
            }
            set
            {
                if (null == value)
                    return;
                searchImageCollection = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string SearchVal { get; set; }
        public double ConfidenceVal { get; set; }


        public void GetSearchResults(string search)
        {
            SearchImageCollection = new ObservableCollection<SearchImage>(model.GetSearchImages(search, ConfidenceVal).Result);
        }
    }
}
