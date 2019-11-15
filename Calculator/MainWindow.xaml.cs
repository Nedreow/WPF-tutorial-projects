using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    ///
    /// The user input is treated as a string here, and as a double in the Solver
    /// </summary>
    public partial class MainWindow
    {
        private string _lastNumber;
        private bool operandFlag = false;

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

        private void DivideButton_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void DotButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (operandFlag || ResultLabel.Content.ToString().Contains("."))
                return;
            
            ResultLabel.Content += ".";
            operandFlag = true;
        }

        private void MinusButton_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void MultiplyButton_OnClick(object sender, RoutedEventArgs e)
        {
            
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
            operandFlag = false;
        }

        private void PercentageButton_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void PlusButton_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void SolveButton_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}