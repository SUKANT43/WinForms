using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfCrud.Base;

namespace WpfCrud.ViewModel
{
    public class LoginViewModel
    {
        MainViewModel _mainViewModel;
        public ICommand LoginCommand { get; }
        public LoginViewModel(MainViewModel mvm)
        {
            _mainViewModel = mvm;
            LoginCommand = new RelayCommand(o => _mainViewModel.NavigateToCrud());
        }
    }
}
