using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SPColumnPropertyManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //Initialize main window and view model
            var mainWindow = new MainWindow();
            var viewModel = new MainWindowViewModel();
            mainWindow.DataContext = viewModel;
            mainWindow.Show();
        }
    }

}
