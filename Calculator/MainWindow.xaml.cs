using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    ///
    /// The user input is treated as a string here, and as a double in the Solver
    ///
    /// todo: show previous value and operator above current value
    /// </summary>
    public partial class MainWindow
    {
        private string _lastNumber;
        private char _operatorChar;
        private bool _operandFlag;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ResultLabelClear()
        {
            ResultLabel.Content = "0";
        }

        private void ResultLabelRemove(int characters)
        {
            var labelContent = ResultLabel.Content.ToString();

            ResultLabel.Content = labelContent.Length > characters
                ? labelContent.Substring(0, labelContent.Length - characters)
                : "0";
        }

        private void AcButton_OnClick(object sender, RoutedEventArgs e)
        {
            var resultString = ResultLabel.Content.ToString();

            if (resultString.Length > 1 && (resultString[resultString.Length - 2] == '.' || resultString[resultString.Length - 2] == '-'))
            {
                ResultLabelRemove(2);
            }
            else
            {
                ResultLabelRemove(1);
            }
        }

        private void ClearButton_OnClick(object sender, RoutedEventArgs e)
        {
            _lastNumber = "";
            _operatorChar = '\0';
            _operandFlag = false;
            ResultLabel.Content = "0";
        }

        private void DotButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_operandFlag || ResultLabel.Content.ToString().Contains("."))
                return;
            
            ResultLabel.Content += ".";
            _operandFlag = true;
        }

        private void NegativeButton_OnClick(object sender, RoutedEventArgs e)
        {
            if ((ResultLabel.Content.ToString() == "0"))
                return;
            
            if (ResultLabel.Content.ToString().Contains("-"))
            {
                ResultLabel.Content = ResultLabel.Content.ToString().Substring(1);
            }
            else
            {
                ResultLabel.Content = "-" + ResultLabel.Content;
            }
        }

        private void NumberButton_OnClick(object sender, RoutedEventArgs e)
        {
            var currentNumber = ResultLabel.Content.ToString();
            var toAdd = ((Button) sender).Content;

            ResultLabel.Content = currentNumber == "0" ? toAdd : currentNumber + toAdd;
            _operandFlag = false;
        }

        private void OperatorButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_operandFlag || _operatorChar != '\0')
                return;
                
            _operatorChar = ((Button)sender).Content.ToString()[0];
            _operandFlag = true;
            _lastNumber = ResultLabel.Content.ToString();
            ResultLabelClear();
        }

        private void SolveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_lastNumber == "" || _operatorChar == '\0')
                return;
                
            var solution = Solver.SolveMath(_lastNumber, ResultLabel.Content.ToString(), _operatorChar);

            _operatorChar = '\0';

            ResultLabel.Content = solution;
        }
    }
}