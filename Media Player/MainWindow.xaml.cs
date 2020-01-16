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
        
        private void MuteButton_Click(object sender, RoutedEventArgs e)
        {
            Media.IsMuted = !Media.IsMuted;
        }

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Media.Volume = VolumeSlider.Value;
        }

        private void Balance_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Media.Balance = BalanceSlider.Value;
        }
        
        private void Speed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Media.SpeedRatio = SpeedSlider.Value;
        }
    }
}