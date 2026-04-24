using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCrud.ViewModel
{
    public class CrudViewModel
    {
        MainViewModel mainViewModel;
        public CrudViewModel(MainViewModel mvm)
        {
            mainViewModel = mvm;
        }
    }
}
