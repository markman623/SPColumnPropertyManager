using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace SPColumnPropertyManager
{
    // Model in Model-View-ViewModel
    public class FieldRow : INotifyPropertyChanged
    {
        private bool? _showInNewForm = null;
        private bool? _showInEditForm = null;
        private bool? _showInViewForm = null;

        public string FieldName { get; set; }

        public bool ShowInNewForm
        {
            get { return (bool)_showInNewForm; }
            set
            {
                // Check to make sure this has changed before adding
                // unnecesarry commits.
                if (_showInNewForm != null)
                {
                    //SPColumnPropertyManager.ColumnProperyEditor cpe = SPColumnPropertyManager.ColumnProperyEditor.Instance;
                    //cpe.SetPropertyValue(FieldName, "ShowInNewForm", value);
                    _showInNewForm = value;
                    RaisePropertyChanged("ShowInNewForm");
                }
                _showInNewForm = value;
            }
        }
        public bool ShowInEditForm
        {
            get { return (bool)_showInEditForm; }
            set
            {
                if (_showInEditForm != null)
                {
                    //SPColumnPropertyManager.ColumnProperyEditor cpe = SPColumnPropertyManager.ColumnProperyEditor.Instance;
                    //cpe.SetPropertyValue(FieldName, "ShowInEditForm", value);
                    _showInEditForm = value;
                    RaisePropertyChanged("ShowInEditForm");
                }
                _showInEditForm = value;
            }
        }
        public bool ShowInViewForm
        {
            get { return (bool)_showInViewForm; }
            set
            {
                if (_showInViewForm != null)
                {
                    //SPColumnPropertyManager.ColumnProperyEditor cpe = SPColumnPropertyManager.ColumnProperyEditor.Instance;
                    //cpe.SetPropertyValue(FieldName, "ShowInViewForm", value);
                    _showInViewForm = value;
                    RaisePropertyChanged("ShowInViewForm");
                }
                _showInViewForm = value;
                
            }
        }

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
