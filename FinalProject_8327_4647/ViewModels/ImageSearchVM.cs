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
                searchImageCollection = value;
                OnPropertyChanged();
            }
        }

        public string SearchVal { get; set; }

        private double confidenceVal;

        public double ConfidenceVal
        {
            get { return confidenceVal; }
            set
            {
                if (value != confidenceVal)
                {
                    confidenceVal = value;
                    OnPropertyChanged();
                }
            }
        }

        public async void GetSearchResults()
        {
            SearchImageCollection = new ObservableCollection<SearchImage>(await model.GetSearchImages(SearchVal, ConfidenceVal));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
