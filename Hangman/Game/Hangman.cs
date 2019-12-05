using System.Collections.Generic;

namespace Hangman.Game
{
    /// <summary>
    /// This class holds the logic and data for a game of hangman displayed on the MainWindow
    /// </summary>
    
    public class Hangman
    {
        private readonly string _word;
        private char _currentGuess;
        private IDictionary<char, bool> _guessedLetters;
        public int mistakes = 0;

        public Hangman()
        {
            _word = WordProvider.GetRandomWord();
            _guessedLetters = new Dictionary<char, bool>();
            for (var c = 'a'; c <= 'z'; c++)
            {
                _guessedLetters[c] = false;
            }
        }
        
        public bool EvaluateGuess(char guess)
        {
            _currentGuess = guess;
            _guessedLetters[_currentGuess] = true;

            if (!_word.Contains(guess.ToString()))
            {
                mistakes++;
                return false;
            }

            return true;
        }

        public string GetWord()
        {
            string wordShown = "";
            
            foreach (var wordChar in _word.ToCharArray())
            {
                if (_guessedLetters[wordChar])
                {
                    wordShown += wordChar;
                }
                else
                {
                    wordShown += '.';
                }
            }
            
            return wordShown.ToUpper();
        }

        public bool HasGuessedAllLetters()
        {
            foreach (char letter in _word)
            {
                if (!_guessedLetters[letter])
                {
                    return false;
                }
            }

            return true;
        }
    }
}