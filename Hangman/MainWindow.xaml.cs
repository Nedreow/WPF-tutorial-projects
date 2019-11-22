using System;
using System.Windows;
using System.Windows.Controls;

namespace Hangman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private Hangman _currentGame;
        
        public MainWindow()
        {
            InitializeComponent();
            StartGame();
        }

        private void LetterButton_OnClick(object sender, RoutedEventArgs e)
        {
            SendLetter(char.Parse(((Button)sender).Tag.ToString()));
        }

        private void NewGameButton_OnClick(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void SendLetter(char guess)
        {
            var correct = _currentGame.EvaluateGuess(guess);
        }
        
        private void StartGame()
        {
            _currentGame = new Hangman();
        }
    }
}