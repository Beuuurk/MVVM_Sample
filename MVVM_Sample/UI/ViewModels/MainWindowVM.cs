using MVVM;
using MVVM_Sample.UI.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM_Sample.UI.ViewModels
{
    internal class MainWindowVM : ViewModel
    {
        private ICommand _addWindow;
        private ICommand _addControl;

        public MainWindowVM() { }

        public ICommand AddWindow
        {
            get { return _addWindow ?? (_addWindow = new CommandHandler(AddWindowCommand)); }
        }

        private void AddWindowCommand(object obj)
        {
            SubWindow subWindow = UIFactory.CreateWindow<SubWindow, SubWindowVM>((win, vm) =>
            {
                win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                win.Title = "Other window";
                vm.PropertyChanged += OnPropertyChanged;
            }, true);
            subWindow.ShowDialog();
        }

        private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            MessageBox.Show(e.PropertyName.ToString());
        }

        public ICommand AddControl
        {
            get { return _addControl ?? (_addControl = new CommandHandler(AddControlCommand)); }
        }

        private void AddControlCommand(object obj)
        {
            TextUser textUser = UIFactory.CreateControl<TextUser, TextUserVM>((usr, vm) => {                
                vm.ContentText = "Default text...";
            }, true);
            ((MainWindow)Parent).MainDock.Children.Add(textUser);
        }
    }
}
