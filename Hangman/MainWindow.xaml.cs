using System.Collections;
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
            _currentGame = new Game.Hangman();
        }

        public void SetWordBoxContent(string text)
        {
            WordBox.Content = text;
        }

        private void LetterButton_OnClick(object sender, RoutedEventArgs e)
        {
            var button = (Button) sender;
            SendLetter(char.Parse(button.Tag.ToString()));
            button.IsEnabled = false;
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
            _currentGame = new Game.Hangman();

            IEnumerable children = LogicalTreeHelper.GetChildren(ControlsGrid);
            foreach (object child in children)
            {
                if (child is Button)
                {
                    ((Button) child).IsEnabled = true;
                }
            }
        }
    }
}