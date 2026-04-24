using System;
using System.Windows;
using System.Windows.Input;
using WpfCrud.Base;

namespace WpfCrud.ViewModel
{
    public class MainViewModel : Observable
    {
        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        private bool _isTopBarVisible;
        public bool IsTopBarVisible
        {
            get => _isTopBarVisible;
            set
            {
                _isTopBarVisible = value;
                OnPropertyChanged();
            }
        }

        // Theme
        private bool _isDarkMode;
        public string ThemeIcon => _isDarkMode ? "☀" : "🌙";

        // Commands
        public ICommand NavigateCrudCommand { get; }
        public ICommand NavigateAnalyticsCommand { get; }
        public ICommand ToggleThemeCommand { get; }

        public MainViewModel()
        {
            NavigateCrudCommand = new RelayCommand(o => NavigateToCrud());
            NavigateAnalyticsCommand = new RelayCommand(o => NavigateToAnalytics());
            ToggleThemeCommand = new RelayCommand(o => ToggleTheme());

            NavigateToLogin();
        }

        public void NavigateToLogin()
        {
            CurrentView = new LoginViewModel(this);
            IsTopBarVisible = false;
        }

        public void NavigateToCrud()
        {
            CurrentView = new CrudViewModel(this);
            IsTopBarVisible = true;
        }

        public void NavigateToAnalytics()
        {
            IsTopBarVisible = true;
        }

        private void ToggleTheme()
        {
            var dictionaries = Application.Current.Resources.MergedDictionaries;
            var themeDictionary = dictionaries[0];

            if (_isDarkMode)
            {
                themeDictionary.Source = new Uri("Theme/LightTheme.xaml", UriKind.Relative);
            }
            else
            {
                themeDictionary.Source = new Uri("Theme/DarkTheme.xaml", UriKind.Relative);
            }

            _isDarkMode = !_isDarkMode;
            OnPropertyChanged(nameof(ThemeIcon));
        }
    }
}