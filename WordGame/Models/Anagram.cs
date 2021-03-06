using System;
using System.Collections.Generic;

namespace WordGame
{
    public class Anagram
    {
        private List<string> _userWords = new List<string>() {};
        private List<string> _wordMatches = new List<string>() {};
        private int _charCounter = 0;
        private bool _sameLetters = false;
        private string _wordToCompare = "";

        public void SetUserWords(string word)
        {
            this.GetUserWords().Add(word);
        }

        public List<string> GetUserWords()
        {
            return _userWords;
        }

        public void SetWordMatches(string word)
        {
            this.GetWordMatches().Add(word);
        }

        public List<string> GetWordMatches()
        {
            return _wordMatches;
        }

        public void IncrementCounter()
        {
            _charCounter++;
        }

        public int GetCounter()
        {
            return _charCounter;
        }

        public void SameLettersTrue()
        {
            _sameLetters = true;
        }

        public bool GetSameLetters()
        {
            return _sameLetters;
        }

        public string GetWordToCompare()
        {
            return _wordToCompare;
        }

        public void SetWordToCompare(string word)
        {
            _wordToCompare = word;
        }

        public void RunGame()
        {
            this.DisplayPrompt();
            this.CaptureUserInput();
            this.CheckForAnagram();
            this.DisplayResults();
        }

        public void DisplayPrompt()
        {
            Console.WriteLine("ANAGRAM GAME");
            Console.WriteLine("1. Enter your main word and hit enter.");
            Console.WriteLine("2. Enter another word that could be an anagram of your main word and hit enter.");
            Console.WriteLine("3. Enter another word that could be an anagram of your main word and hit enter again...");
            Console.WriteLine("4. Are you seeing a pattern? Type 'chicken dinner' to check for anagrams of the first word you entered!");
        }

        public void CaptureUserInput()
        {
            string input = "";
            while(input != "chicken dinner")
            {
                input = Console.ReadLine();
                this.SetUserWords(input);
            }
        }

        public void CheckForAnagram()
        {
            char[] firstWordLetters = this.SortAndReturnChars(this.GetUserWords()[0]);
            for(int j = 1; j < this.GetUserWords().Count; j++)
            {
                this.SetWordToCompare(GetUserWords()[j]);
                char[] secondWordLetters = this.SortAndReturnChars(this.GetUserWords()[j]);
                if (secondWordLetters.Length == firstWordLetters.Length)
                {
                    this.CheckLettersAreEqual(firstWordLetters[this.GetCounter()], secondWordLetters[this.GetCounter()]);
                    IncrementCounter();
                }
            }
        }

        public char[] SortAndReturnChars(string word)
        {
            char[] lettersOfWord = this.CharactersInWord(word);
            Array.Sort(lettersOfWord);
            return lettersOfWord;
        }

        public void CheckLettersAreEqual(char letterOne, char letterTwo)
        {
            if (letterOne == letterTwo)
            {
              SameLettersTrue();
              this.AddAnagram();
            }
        }

        public void AddAnagram()
        {
            if (this.GetSameLetters()) this.SetWordMatches(this.GetWordToCompare());
        }

        public char[] CharactersInWord(string word)
        {
            return word.ToCharArray();
        }

        public void DisplayResults()
        {
            Console.WriteLine("Here are your anagrams of " + this.GetUserWords()[0] + ":");
            for (int i = 0; i < this.GetWordMatches().Count; i++)
            {
                Console.WriteLine(this.GetWordMatches()[i]);
            }
        }
    }

    public class Program
    {
        static void Main()
        {
            Anagram myGame = new Anagram();
            myGame.RunGame();
        }
    }
}
