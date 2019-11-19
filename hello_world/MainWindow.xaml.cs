using System.Windows;

namespace hello_world
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

        private void Button_Canvas_1_Click(object sender, RoutedEventArgs e)
        {
            string msg = string.Format("Hello {0} {1}", FirstName.Text, LastName.Text);
            MessageBox.Show(msg);
        }

        private void ErrorButton_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Something terrible happened", "PANIC!!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}