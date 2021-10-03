using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_8327_4647
{
    class Star : INotifyPropertyChanged
    {
        #region "private fields"

        private String _name;
        private String _size;

        #endregion

        #region "public properties"

        public string Name {
            get { return _name; }
            set { _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Size
        {
            get { return _size; }
            set
            {
                _size = value;
                OnPropertyChanged("Size");
            }
        }
        #endregion

        #region "INotifyPropertyChanged members"

        public event PropertyChangedEventHandler PropertyChanged;

        //This routine is called each time a property value has been set.
        //This will cause an event to notify WPF via data-bindingthat a change has occurred.
        private void OnPropertyChanged(string propertyName) {

            var handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}
