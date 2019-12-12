using System.ComponentModel;
using System.Runtime.CompilerServices;

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

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}