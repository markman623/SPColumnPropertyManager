using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using Microsoft.SharePoint.Client;

namespace SPColumnPropertyManager
{
    public class MainWindowViewModel : ViewModelBase
    {

        private string _url;
        public string url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
            }
        }

        private ObservableCollection<FieldRow> _FieldRows;
        public ObservableCollection<FieldRow> FieldRows
        {
            get
            {
                return _FieldRows;
            }
            set
            {
                _FieldRows = value;
            }
        }

        private ObservableCollection<string> _ListNames;
        public ObservableCollection<string> ListNames
        {
            get
            { return _ListNames; }
            set
            {
                _ListNames = value;
            }
        }

        public string SelectedList { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public string UserName { get; set; }

        public Commands.RelayCommand GetLists { get; set; }
        public Commands.RelayCommand GetFields { get; set; }

        private ColumnProperyEditor _cpe;

        public MainWindowViewModel()
        {
            GetLists = new Commands.RelayCommand(GetLists_Execute, GetLists_CanExecute);
            GetFields = new Commands.RelayCommand(GetFields_Execute, GetFields_CanExecute);

            _FieldRows = new ObservableCollection<FieldRow>();
            _ListNames = new ObservableCollection<string>();
            _url = "";
            SelectedList = "";
            UseDefaultCredentials = true;
            UserName = "";

            // Singleton implementation
            _cpe = ColumnProperyEditor.Instance;


            
        }


        // For the password, using the 2nd solution from here:
        // http://stackoverflow.com/questions/1483892/how-to-bind-to-a-passwordbox-in-mvvm
        // breaks mvvm, but works 
        public void GetLists_Execute(object parameter)
        {
            _cpe.SetUrl(url);
            
            if (!UseDefaultCredentials)
            {
                var pwBox = parameter as PasswordBox;
                _cpe.ChangeCredentials(UserName, pwBox.Password);
            }

            ListCollection lists = _cpe.GetListCollection();
            foreach (List list in lists)
            {
                if (!list.Hidden)
                {
                    ListNames.Add(list.Title);
                }
            }
        }

        public bool GetLists_CanExecute(object parameter)
        {
            return Uri.IsWellFormedUriString(url, UriKind.Absolute);

        }

        public void GetFields_Execute(object parameter)
        {

            FieldRows.Clear();
            FieldCollection fields = _cpe.GetListFieldCollection(SelectedList);

            foreach (var field in fields)
            {
                if (!field.Hidden && !field.Sealed && !field.ReadOnlyField)
                {
                    bool showInNewForm = true;
                    bool showInEditForm = true;
                    bool showInViewForm = true;

                    if (field.SchemaXml.Contains("ShowInNewForm=\"FALSE\""))
                    {
                        showInNewForm = false;
                    }
                    if (field.SchemaXml.Contains("ShowInEditForm=\"FALSE\""))
                    {
                        showInEditForm = false;
                    }
                    if (field.SchemaXml.Contains("ShowInViewForm=\"FALSE\""))
                    {
                        showInViewForm = false;
                    }

                    FieldRow rowToAdd = new FieldRow()
                    {
                        FieldName = field.Title,
                        ShowInNewForm = showInNewForm,
                        ShowInEditForm = showInEditForm,
                        ShowInViewForm = showInViewForm,
                    };

                    rowToAdd.PropertyChanged +=rowToAdd_PropertyChanged;
                    FieldRows.Add(rowToAdd);
 
                }
            }
        }


        // Need to improve this somehow, seems sloppy
        private void rowToAdd_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            FieldRow fr = (FieldRow)sender;
            bool val = false;
            switch(e.PropertyName)
            {
                case "ShowInNewForm":
                    val = fr.ShowInNewForm;
                    break;
                case "ShowInEditForm":
                    val = fr.ShowInEditForm;
                    break;
                case "ShowInViewForm":
                    val = fr.ShowInViewForm;
                    break;

            }
            _cpe.SetPropertyValue(fr.FieldName, e.PropertyName, val);
        }

        public bool GetFields_CanExecute(object parameter)
        {
            if (ListNames.Count > 0)
            {
                return true;
            }

            return false;
        }

        

    }
}
