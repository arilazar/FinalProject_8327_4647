using BE;
using FinalProject_8327_4647.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

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

        private bool hazardOnly;
        public bool HazardOnly
        {
            get { return hazardOnly; }
            set
            {
                if (value == hazardOnly)
                    return;
                hazardOnly = value;
                OnPropertyChanged("nearEarthObjects");
            }
        }

        private string fromDate;
        public string FromDate
        {
            get
            {
                if (null != fromDate)
                    return fromDate;
                return DateTime.Now.ToString("MM/dd/yyyy");
            }
            set { fromDate = value; }
        }
        private string toDate;
        public string ToDate
        {
            get
            {
                if (null != toDate)
                    return toDate;
                return DateTime.Now.ToString("MM/dd/yyyy");
            }
            set { toDate = value; }
        }

        private ObservableCollection<NEO> nearEarthObjects;

        public ObservableCollection<NEO> NearEarthObjects
        {
            get
            {
                if (HazardOnly && nearEarthObjects != null)
                    return new ObservableCollection<NEO>(from item in nearEarthObjects
                                                         where item.IsPotentiallyHazardousAsteroid == hazardOnly
                                                         select item);
                else
                    return nearEarthObjects;
            }
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
                GetNearEarthObjects(FromDate, ToDate, MinSize);
            }
            else
            {
                var nowDate = DateTime.Now.ToString("yyyy-MM-dd");
                GetNearEarthObjects(nowDate, nowDate, MinSize);
            }
        }

        public void GetNearEarthObjects(string start, string end, int minSize)
        {
            Thread t = new Thread(() =>
              NearEarthObjects = new ObservableCollection<NEO>(model.getNearEarthObject(start, end, minSize)));
            t.Start();
        }
    }
}
