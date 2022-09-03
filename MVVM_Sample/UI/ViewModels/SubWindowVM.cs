using MVVM;
using MVVM_Sample.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM_Sample.UI.ViewModels
{
    internal class SubWindowVM : ViewModel
    {
        private string _contentText;

        public string ContentText
        {
            get { return Get(ref _contentText); }
            set { Set(ref _contentText, value); }
        }

        private ICommand _closeWindow;

        public SubWindowVM() { }

        public ICommand CloseWindow
        {
            get { return _closeWindow ?? (_closeWindow = new CommandHandler(CloseWindowCommand)); }
        }

        private void CloseWindowCommand(object obj)
        {
            ((SubWindow)Parent).Close();
        }
    }
}
