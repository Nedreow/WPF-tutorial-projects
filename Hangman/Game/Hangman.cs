using System.Collections.Generic;

namespace Hangman.Game
{
    /// <summary>
    /// This class holds the logic and data for a game of hangman displayed on the MainWindow
    /// </summary>
    
    public class Hangman
    {
        private string _word;
        private char _currentGuess;
        private IDictionary<char, bool> _guessedLetters;

        public Hangman()
        {
            _word = WordProvider.GetRandomWord();
            for (var c = 'a'; c <= 'z'; c++)
            {
                _guessedLetters[c] = false;
            }
        }
        
        public bool EvaluateGuess(char guess)
        {
            _currentGuess = guess;

            return true;
        }
    }
}