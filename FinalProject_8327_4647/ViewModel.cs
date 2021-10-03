using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_8327_4647
{
    class ViewModel : ObservableCollection<Star>
    {
        #region "constructor"
        public
            ViewModel() {
            PrepareContactCollection();
        }
        #endregion

        #region "private routines"
        private void PrepareContactCollection() {
            //Create new contacts and add them tothe ViewModel's
            //ObservableCollection.
            var StarOne = new Star {
                Name = "Sun",
                Size = "Big" };
            Add(StarOne);
            var StarTwo = new Star
            {
                Name = "Earth",
                Size = "Small"
            };
            Add(StarTwo);
        }
        #endregion
    }
}