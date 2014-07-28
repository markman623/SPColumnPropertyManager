using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.SharePoint.Client;
using List = Microsoft.SharePoint.Client.List;

//  Should be using Model-View-ViewModel pattern
// http://www.codeproject.com/Articles/42548/MVVM-and-the-WPF-DataGrid
// However, due to project small size, not doing so.
namespace SPColumnPropertyManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        
        // Here to make a checkbox toggle in a single click
        // Default behaviour is two clicks, one for cell focus and the second to toggle the check box
        // From blog - http://blogs.msdn.com/b/vinsibal/archive/2008/08/27/more-datagrid-samples-custom-sorting-drag-and-drop-of-rows-column-selection-and-single-click-editing.aspx
        private void DataGridListFields_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            //DataGridCell cell = (DataGridCell)e.Source;
            //if (!cell.IsEditing)
            //{
            //    // enables editing on a single click
            //    if (!cell.IsFocused)
            //    {
            //        cell.Focus();
            //    }
            //    if (!cell.IsSelected)
            //    {
            //        cell.IsSelected = true;
            //    }
            //}
        }

        //private void DefaultCredCheckBoxChanged(object sender, RoutedEventArgs e)
        //{
        //    if ((bool)CheckBoxUseDefaultCred.IsChecked)
        //    {
        //        TextBoxUserName.IsEnabled = false;
        //        PasswordBoxUserPassword.IsEnabled = false;
        //    }
        //    else
        //    {
        //        TextBoxUserName.IsEnabled = true;
        //        PasswordBoxUserPassword.IsEnabled = true;
        //    }
        //}

        //
        // SINGLE CLICK EDITING
        //
        private void DataGridCell_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridCell cell = sender as DataGridCell;
            if (cell != null && !cell.IsEditing && !cell.IsReadOnly)
            {
                if (!cell.IsFocused)
                {
                    cell.Focus();
                }
                DataGrid dataGrid = FindVisualParent<DataGrid>(cell);
                if (dataGrid != null)
                {
                    if (dataGrid.SelectionUnit != DataGridSelectionUnit.FullRow)
                    {
                        if (!cell.IsSelected)
                            cell.IsSelected = true;
                    }
                    else
                    {
                        DataGridRow row = FindVisualParent<DataGridRow>(cell);
                        if (row != null && !row.IsSelected)
                        {
                            row.IsSelected = true;
                        }
                    }
                }
            }
        }

        static T FindVisualParent<T>(UIElement element) where T : UIElement
        {
            UIElement parent = element;
            while (parent != null)
            {
                T correctlyTyped = parent as T;
                if (correctlyTyped != null)
                {
                    return correctlyTyped;
                }

                parent = VisualTreeHelper.GetParent(parent) as UIElement;
            }
            return null;
        } 

    }
}
