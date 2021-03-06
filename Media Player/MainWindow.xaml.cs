﻿using System;
using System.Text;
using System.Windows;
using System.Windows.Media;
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
        
        private void Media_MediaOpened(object sender, RoutedEventArgs e)
        {
            Status.Fill = Brushes.Green;
            ShowMediaInformation();
        }
 
        private void Media_MediaEnded(object sender, RoutedEventArgs e)
        {
            Status.Fill = Brushes.Blue;
        }
 
        private void Media_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            Status.Fill = Brushes.Red;
        }
        
        private void ShowMediaInformation()
        {
            var sb = new StringBuilder();
 
            var duration = Media.NaturalDuration.HasTimeSpan
                ? Media.NaturalDuration.TimeSpan.TotalSeconds.ToString("#s")
                : "No duration";
            sb.Append(duration);
 
            if (Media.HasVideo)
            {
                sb.Append(", video");
            }
 
            if (Media.HasAudio)
            {
                sb.Append(", audio");
            }

            if (Media.HasVideo)
            {
                sb.Append(" (")
                    .Append(Media.NaturalVideoWidth)
                    .Append("×")
                    .Append(Media.NaturalVideoHeight)
                    .Append(")");
            }

            MediaInformation.Text = sb.ToString();
        }
        
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (!Media.NaturalDuration.HasTimeSpan) return;
 
            var position = Media.Position;
            if (position.TotalSeconds < 5)
                Media.Position = TimeSpan.FromSeconds(0);
            else
                Media.Position = position.Add(TimeSpan.FromSeconds(-5));
        }
 
        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            if (!Media.NaturalDuration.HasTimeSpan) return;
 
            var targetPosition = Media.Position.Add(TimeSpan.FromSeconds(5));
            if (targetPosition > Media.NaturalDuration.TimeSpan)
                Media.Position = Media.NaturalDuration.TimeSpan;
            else
                Media.Position = targetPosition;
        }
    }
}