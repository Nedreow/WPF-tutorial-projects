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

        private void AddToResultLabel(string addString)
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

        private void NumberButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddToResultLabel(((Button)sender).Content.ToString());
        }
    }
}