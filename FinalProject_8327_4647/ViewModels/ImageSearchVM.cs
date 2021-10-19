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
using BL;
using BE;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FinalProject_8327_4647.ViewModels
{
    public class ImageSearchVM : INotifyPropertyChanged
    {
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

        public string SearchVal { get; set; }

        private readonly BLClass myBL = new BLClass();

        public event PropertyChangedEventHandler PropertyChanged;

        public void GetSearchImages()
        {
            SearchImageCollection = new ObservableCollection<SearchImage>(myBL.GetSearchResults(SearchVal));
        }
        public RelayCommand SearchCMD => new RelayCommand(GetSearchImages);
    }
}
