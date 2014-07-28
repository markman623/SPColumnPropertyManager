using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace SPColumnPropertyManager
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        // Basic ViewModelBase
        public event PropertyChangedEventHandler PropertyChanged;

        internal void RaisePropertyChange(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        // Can add other stuff here but I still dont see how this useful
    }
}
