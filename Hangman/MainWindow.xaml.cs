using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
            SetWordBoxContent(_currentGame.GetWord());
        }

        private void SetWordBoxContent(string text)
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
            _currentGame = new Game.Hangman();

            EnableAlphabetButtons(true);
            WordBox.Foreground = Brushes.Black;
            SetWordBoxContent(_currentGame.GetWord());
        }

        private void ShowFailures(int mistakeCount)
        {
            MistakeCountLabel.Content = mistakeCount.ToString();
            if (mistakeCount >= 10)
                showHanged();
        }

        private void showHanged()
        {
            SetWordBoxContent("You Have Been Hanged!!");
            EnableAlphabetButtons(false);
        }

        private void SendLetter(char guess)
        {
            var mistakeCount = _currentGame.EvaluateGuess(guess);
            
            SetWordBoxContent(_currentGame.GetWord());
            ShowFailures(mistakeCount);

            if (_currentGame.HasGuessedAllLetters())
            {
                WordBox.Foreground = Brushes.LawnGreen;
                EnableAlphabetButtons(false);
            }
        }

        private void EnableAlphabetButtons(bool enable)
        {
            IEnumerable children = LogicalTreeHelper.GetChildren(ControlsGrid);
            foreach (object child in children)
            {
                if (child is Button)
                {
                    ((Button) child).IsEnabled = enable;
                }
            }

            NewGameButton.IsEnabled = true;
        }
    }
}