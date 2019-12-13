using System;
using System.Windows.Input;

namespace MVVM_Weather_App.ViewModel.Commands
{
    public class SearchCommand : ICommand
    {
        public WeatherVM VM { get; set; }
        
        public event EventHandler CanExecuteChanged;

        public SearchCommand(WeatherVM vm)
        {
            VM = vm;
        }
        
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MakeQuery();
        }
    }
}