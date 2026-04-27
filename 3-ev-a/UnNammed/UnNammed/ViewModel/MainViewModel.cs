using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnNammed.Base;

namespace UnNammed.ViewModel
{
    public class MainViewModel : Observable
    {
        private object _currentPage;
        public object CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        public void Navigate(object page)
        {
            CurrentPage = page;
        }

        public MainViewModel()
        {
            Navigate(new SignUpViewModel(this));
        }
    }
}
