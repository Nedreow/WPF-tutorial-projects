using System;

namespace Hangman
{
    public class WordProvider
    {
        private static string[] _words = {"hangman", "awkward", "bagpipes", "banjo", "bungler", "croquet", "crypt", "dwarves", "fervid", "fishhook", "fjord", "gazebo", "gypsy", "haiku", "haphazard", "hyphen", "ivory", "jazzy", "jiffy", "jinx", "jukebox", "kayak", "kiosk", "klutz", "memento", "mystify", "numbskull", "ostracize", "oxygen", "pajama", "phlegm", "pixel", "polka", "quad", "quip", "rhythmic", "rogue", "sphinx", "squawk", "swivel", "toady", "twelfth", "unzip", "waxy", "wildebeest", "yacht", "zealous", "zigzag", "zippy", "zombie", "gandalf", "apartment"};
        private static Random _rand = new Random();
        
        public static string GetRandomWord()
        {
            int index = _rand.Next(_words.Length);
            return _words[index].ToLower();
        }
    }
}