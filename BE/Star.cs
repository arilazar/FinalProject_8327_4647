using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Star : INotifyPropertyChanged
    {
        #region "private fields"

        private string _name;
        private string _generalInfo;
        private string _category;
        private string _location;
        private string _avgDistanceFromSun;
        private string _orbitalPeriod;
        private string _avgOrbitalSpeed;
        private string _inclination;
        private string _satellites;
        private string _radius;
        private string _surfaceArea;
        private string _mass;
        private string _density;
        private string _rotationPeriod;
        private string _rotationSpeed;
        private string _axialTilt;
        private string _avgSurfaceTemp;
        private string _imageUrl;

        #endregion

        #region "public properties"

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string GeneralInfo
        {
            get { return _generalInfo; }
            set
            {
                _generalInfo = value;
                OnPropertyChanged("GeneralInfo");
            }
        }
        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
                OnPropertyChanged("Category");
            }
        }
        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged("Location");
            }
        }
        public string AvgDistanceFromSun
        {
            get { return _avgDistanceFromSun; }
            set
            {
                _avgDistanceFromSun = value;
                OnPropertyChanged("AvgDistanceFromSun");
            }
        }
        public string OrbitalPeriod
        {
            get { return _orbitalPeriod; }
            set
            {
                _orbitalPeriod = value;
                OnPropertyChanged("OrbitalPeriod");
            }
        }
        public string AvgOrbitalSpeed
        {
            get { return _avgOrbitalSpeed; }
            set
            {
                _avgOrbitalSpeed = value;
                OnPropertyChanged("AvgOrbitalSpeed");
            }
        }
        public string Inclination
        {
            get { return _inclination; }
            set
            {
                _inclination = value;
                OnPropertyChanged("Inclination");
            }
        }
        public string Satellites
        {
            get { return _satellites; }
            set
            {
                _satellites = value;
                OnPropertyChanged("Satellites");
            }
        }
        public string Radius
        {
            get { return _radius; }
            set
            {
                _radius = value;
                OnPropertyChanged("Radius");
            }
        }
        public string SurfaceArea
        {
            get { return _surfaceArea; }
            set
            {
                _surfaceArea = value;
                OnPropertyChanged("SurfaceArea");
            }
        }
        public string Mass
        {
            get { return _mass; }
            set
            {
                _mass = value;
                OnPropertyChanged("Mass");
            }
        }
        public string Density
        {
            get { return _density; }
            set
            {
                _density = value;
                OnPropertyChanged("Density");
            }
        }
        public string RotationPeriod
        {
            get { return _rotationPeriod; }
            set
            {
                _rotationPeriod = value;
                OnPropertyChanged("RotationPeriod");
            }
        }
        public string RotationSpeed
        {
            get { return _rotationSpeed; }
            set
            {
                _rotationSpeed = value;
                OnPropertyChanged("RotationSpeed");
            }
        }
        public string AxialTilt
        {
            get { return _axialTilt; }
            set
            {
                _axialTilt = value;
                OnPropertyChanged("AxialTilt");
            }
        }
        public string AvgSurfaceTemp
        {
            get { return _avgSurfaceTemp; }
            set
            {
                _avgSurfaceTemp = value;
                OnPropertyChanged("AvgSurfaceTemp");
            }
        }

         /*   
            //public string GeneralInfo { get; set; }
            //public string Category { get; set; }
            //public string Location { get; set; }
            //public string AvgDistanceFromSun { get; set; }
            //public string OrbitalPeriod { get; set; }
            //public string AvgOrbitalSpeed { get; set; }
            //public string Inclination { get; set; }
            //public string Satellites { get; set; }
            //public string Radius { get; set; }
            //public string SurfaceArea { get; set; }
            //public string Mass { get; set; }
            //public string Density { get; set; }
            //public string RotationPeriod { get; set; }
            //public string RotationSpeed { get; set; }
            //public string AxialTilt { get; set; }
            //public string AvgSurfaceTemp { get; set; }


            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string propertyName)
            {

                var handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        */
        

        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
                OnPropertyChanged("ImageUrl");
            }
        }
       
        #endregion

        #region "INotifyPropertyChanged members"

        public event PropertyChangedEventHandler PropertyChanged;

        //This routine is called each time a property value has been set.
        //This will cause an event to notify WPF via data-bindingthat a change has occurred.
        private void OnPropertyChanged(string propertyName)
        {

            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }

        }
        #endregion

        
    }

}