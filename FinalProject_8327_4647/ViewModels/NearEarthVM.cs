using BE;
using FinalProject_8327_4647.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_8327_4647.ViewModels
{
    class NearEarthVM : INotifyPropertyChanged
    {
        NearEarthModel model;
        public NearEarthVM()
        {
            model = new NearEarthModel();
        }

        public int MinSize { get; set; } = 0;
        public bool HazardOnly { get; set; }

        private string fromDate;
        public string FromDate
        {
            get { return fromDate; }
            set { fromDate = value; }
        }
        private string toDate;
        public string ToDate
        {
            get { return toDate; }
            set { toDate = value; }
        }

        private ObservableCollection<NEO> nearEarthObjects;

        public ObservableCollection<NEO> NearEarthObjects
        {
            get { return nearEarthObjects; }
            set
            {
                if (null == value)
                    return;
                nearEarthObjects = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void GetNearEarthObjects()
        {
            if (FromDate != null && ToDate != null)
            {
                GetNearEarthObjects(FromDate, ToDate, HazardOnly, MinSize);
            }
            else
            {
                var nowDate = DateTime.Now.ToString("yyyy-MM-dd");
                GetNearEarthObjects(nowDate, nowDate, HazardOnly, MinSize);
            }
        }

        public void GetNearEarthObjects(string start, string end, bool hazard, int minSize)
        {
            NearEarthObjects = new ObservableCollection<NEO>(model.getNearEarthObject(start, end, hazard, minSize));
        }
    }
}
