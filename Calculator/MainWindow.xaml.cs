using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private string _lastNumber;
        private string _result;
        private char _operatorChar;
        private bool _operandFlag;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ResultLabelClear()
        {
            InputLabel.Content = "0";
        }

        private void ResultLabelRemove(int characters)
        {
            var labelContent = InputLabel.Content.ToString();

            InputLabel.Content = labelContent.Length > characters
                ? labelContent.Substring(0, labelContent.Length - characters)
                : "0";
        }

        private void AcButton_OnClick(object sender, RoutedEventArgs e)
        {
            var resultString = InputLabel.Content.ToString();

            if (resultString.Length > 1 && (resultString[resultString.Length - 2] == '.' || resultString[resultString.Length - 2] == '-'))
            {
                ResultLabelRemove(2);
            }
            else
            {
                ResultLabelRemove(1);
            }
        }

        private void AnsButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_result == "")
                return;

            InputLabel.Content = _result;
        }

        private void DotButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_operandFlag || InputLabel.Content.ToString().Contains("."))
                return;
            
            InputLabel.Content += ".";
            _operandFlag = true;
        }

        private void NegativeButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (InputLabel.Content.ToString() == "0" && _result != null)
            {
                InputLabel.Content = _result;
            }
            
            if (InputLabel.Content.ToString() == "0")
                return;
            
            if (InputLabel.Content.ToString().Contains("-"))
            {
                InputLabel.Content = InputLabel.Content.ToString().Substring(1);
            }
            else
            {
                InputLabel.Content = "-" + InputLabel.Content;
            }
        }

        private void NumberButton_OnClick(object sender, RoutedEventArgs e)
        {
            var currentNumber = InputLabel.Content.ToString();
            var toAdd = ((Button) sender).Content;

            InputLabel.Content = currentNumber == "0" ? toAdd : currentNumber + toAdd;
            _operandFlag = false;
        }

        private void OperatorButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_operatorChar != '\0')
            {
                InputLabel.Content = _lastNumber;
            }

            if (_result != null && _lastNumber != null && InputLabel.Content.ToString() == "0")
            {
                _lastNumber = _result;
            }
            else
            {
                _lastNumber = InputLabel.Content.ToString();
            }
                
            _operatorChar = ((Button)sender).Content.ToString()[0];
            _operandFlag = true;
            PreviousLabel.Content = $"{_lastNumber} {_operatorChar}";
            ResultLabelClear();
        }

        private void SolveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_lastNumber == "" || _operatorChar == '\0')
                return;
                
            _result = Solver.SolveMath(_lastNumber, InputLabel.Content.ToString(), _operatorChar);
            
            PreviousLabel.Content = $"{_lastNumber} {_operatorChar} {InputLabel.Content} = {_result}";
            _operatorChar = '\0';
            InputLabel.Content = "0";
        }
    }
}