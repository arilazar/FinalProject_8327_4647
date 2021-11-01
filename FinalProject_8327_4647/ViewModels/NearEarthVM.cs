using BE;
using FinalProject_8327_4647.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
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

        private int minSize = 0;

        public int MinSize
        {
            get { return minSize; }
            set {
                if (value == minSize)
                    return;
                minSize = value;
                OnPropertyChanged("nearEarthObjects");
            }
        }



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

        private ObservableCollection<NEO> nearEarthObjects = new ObservableCollection<NEO>();

        public ObservableCollection<NEO> NearEarthObjects
        {
            get
            {


                if (HazardOnly)
                    return new ObservableCollection<NEO>(from item in nearEarthObjects
                                                         where item.IsPotentiallyHazardous == hazardOnly
                                                         && item.EstimatedDiameter >= MinSize
                                                         select item);
                else
                    return new ObservableCollection<NEO>(from item in nearEarthObjects
                                                         where item.EstimatedDiameter >= MinSize
                                                         select item);
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
            if (FromDate == null || ToDate == null)
            {
                var nowDate = DateTime.Now.ToString("yyyy-MM-dd");
                fromDate = nowDate;
                toDate = nowDate;
            }
            NearEarthObjects = new ObservableCollection<NEO>(model.getNearEarthObject(FromDate, ToDate, MinSize).Result);
        }
    }
}
