namespace Hangman
{
    /// <summary>
    /// This class holds the logic and data for a game of hangman displayed on the ManinWindow
    /// </summary>
    
    public class Hangman
    {
        private char currentGuess;
        
        public bool EvaluateGuess(char guess)
        {
            currentGuess = guess;

            return true;
        }
    }
}