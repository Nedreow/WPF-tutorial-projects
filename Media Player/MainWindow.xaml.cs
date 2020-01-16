using System;
using System.Windows;
using Microsoft.Win32;

namespace Media_Player
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
        
        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "Choose Media";
            if (dialog.ShowDialog() == true)
            {
                Media.Source = new Uri(dialog.FileName);
                MediaName.Text = dialog.FileName;
            }
        }
        
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (Media.Source != null)
                Media.Play();
        }
 
        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (Media.CanPause)
                Media.Pause();
        }
 
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            if (Media.Source != null)
                Media.Stop();
        }
    }
}