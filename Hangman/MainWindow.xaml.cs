using System.Windows;
using System.Windows.Controls;

namespace Hangman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private Game.Hangman _currentGame;
        
        public MainWindow()
        {
            InitializeComponent();
            StartGame();
        }

        public void SetWordBoxContent(string text)
        {
            WordBox.Content = text;
        }

        private void LetterButton_OnClick(object sender, RoutedEventArgs e)
        {
            SendLetter(char.Parse(((Button)sender).Tag.ToString()));
        }

        private void NewGameButton_OnClick(object sender, RoutedEventArgs e)
        {
            StartGame();
            ((Button) sender).IsEnabled = false;
        }

        private void SendLetter(char guess)
        {
            var correct = _currentGame.EvaluateGuess(guess);
        }
        
        private void StartGame()
        {
            _currentGame = new Game.Hangman();
            // https://stackoverflow.com/questions/874380/wpf-how-do-i-loop-through-the-all-controls-in-a-window
        }
    }
}