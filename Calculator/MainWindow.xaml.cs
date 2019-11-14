using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private double _lastNumber;
        private double _result;

        public MainWindow()
        {
            InitializeComponent();

            _lastNumber = 0;
        }

        private void ResultLabelSet(string setString)
        {
            ResultLabel.Content = setString;
        }

        private void ResultLabelSet(double setDouble)
        {
            ResultLabel.Content = setDouble.ToString(CultureInfo.InvariantCulture);
        }

        private void ResultLabelClear()
        {
            ResultLabel.Content = "0";
        }

        private void AcButton_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void DivideButton_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void DotButton_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void MinusButton_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void MultiplyButton_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void NegativeButton_OnClick(object sender, RoutedEventArgs e)
        {
            _lastNumber = _lastNumber * -1;
            ResultLabelSet(_lastNumber);
        }

        private void NumberButton_OnClick(object sender, RoutedEventArgs e)
        {
            var toAdd = double.Parse(((Button) sender).Content.ToString());

            var newNumber = _lastNumber * 10 + toAdd;
            
            ResultLabelSet(newNumber);
            _lastNumber = newNumber;
        }

        private void PercentageButton_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void PlusButton_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void ZeroButton_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}