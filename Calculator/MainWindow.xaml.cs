using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
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
                ResultLabel.Content += addString;
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

        private void NumberButton_OnClick(object sender, RoutedEventArgs e)
        {
            ResultLabelAdd(((Button)sender).Content.ToString());
        }

        private void AcButton_OnClick(object sender, RoutedEventArgs e)
        {
            ResultLabelRemove(1);
        }
    }
}