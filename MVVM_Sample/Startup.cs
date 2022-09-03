using MVVM;
using MVVM_Sample.UI.ViewModels;
using MVVM_Sample.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM_Sample
{
    internal class Startup
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application application = new();
            MainWindow mainWindow = UIFactory.CreateWindow<MainWindow, MainWindowVM>((win, vm) =>
            {
                win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                win.Title = "Sample MVVM library";
            }, true);
            application.Run(mainWindow);

        }
    }
}
