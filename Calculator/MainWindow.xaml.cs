using System.Windows;

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

        private void SevenButton_OnClick(object sender, RoutedEventArgs e)
        {
            if ((string) ResultLabel.Content == "0")
            {
                ResultLabel.Content = "7";
            }
            else
            {
                ResultLabel.Content += "7";
            }
        }
    }
}