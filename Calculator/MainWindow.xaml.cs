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
        private double lastNumber;
        private double result;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ResultLabelAdd(string addString)
        {
            if ((string) ResultLabel.Content == "0")
            {
                ResultLabel.Content = addString;
            }
            else
            {
                ResultLabel.Content = ResultLabel.Content + addString;
            }
        }

        private void ResultLabelRemove(int removeCount)
        {
            string labelContent = ResultLabel.Content.ToString();

            if (labelContent.Length > removeCount)
            {
                ResultLabel.Content = labelContent.Substring(0, labelContent.Length - removeCount);
            }
            else
            {
                ResultLabel.Content = "0";
            }
        }

        private void ResultLabelSet(string setString)
        {
            ResultLabel.Content = setString;
        }

        private void ResultLabelClear()
        {
            ResultLabel.Content = "0";
        }

        private void AcButton_OnClick(object sender, RoutedEventArgs e)
        {
            ResultLabelRemove(1);
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
            if (double.TryParse(ResultLabel.Content.ToString(), out lastNumber))
            {
                ResultLabel.Content = (lastNumber * -1).ToString(CultureInfo.InvariantCulture);
            }
        }

        private void NumberButton_OnClick(object sender, RoutedEventArgs e)
        {
            ResultLabelAdd(((Button)sender).Content.ToString());
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