using System.ComponentModel;
using System.Runtime.CompilerServices;
using MVVM_Weather_App.Model;

namespace MVVM_Weather_App.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {
        private string _query;

        public string Query
        {
            get => _query;
            set
            {
                _query = value;
                OnPropertyChanged("Query");
            }
        }

        private CurrentConditions _currentConditions;

        public CurrentConditions CurrentConditions
        {
            get => _currentConditions;
            set
            {
                _currentConditions = value;
                OnPropertyChanged("CurrentConditions");
            }
        }

        private City _selectedCity;

        public City SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
                OnPropertyChanged("SelectedCity");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}