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
    internal class TextUserVM : ViewModel
    {

        private string _contentText;

        public string ContentText
        {
            get { return Get(ref _contentText); }
            set { Set(ref _contentText, value); }
        }

        private ICommand _showText;

        public TextUserVM() { }

        public ICommand ShowText
        {
            get { return _showText ?? (_showText = new CommandHandler(ShowTextCommand)); }
        }

        private void ShowTextCommand(object obj)
        {
            MessageBox.Show(ContentText);
        }

    }
}
