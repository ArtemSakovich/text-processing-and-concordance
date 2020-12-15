using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace problem2_finalVarsion
{
    class Word
    {
        private List<Symbol> letters = new List<Symbol>();
        private Symbol symbolAfterWord;

        public Word()
        {
          
        }

        public Word(string sourceString)
        {
            foreach (var ch in sourceString)
            {
                letters.Add(new Symbol(ch));
            }
        }

        public void addLetter(Symbol symbol)
        {
            letters.Add(symbol);
        }

        public bool containsLetters()
        {
            return (letters.Count > 0);
        }

        public void addSymbolAfterWord(Symbol symbol)
        {
            if (!symbol.isSpaceOrTab())
            {
                symbolAfterWord = symbol;
            }
        }
        public override string ToString()
        {
            string result = toStringWithoutAfterWordSymbol();
            if (symbolAfterWord != null)
            {
                result += symbolAfterWord.ToString();
            }
            return result;
        }
        public string toStringWithoutAfterWordSymbol()
        {
            string result = string.Empty;
            foreach (var letter in letters)
            {
                result += letter.ToString();
            }
            return result;
        }

        public int getLettersCount()
        {
            return letters.Count;
        }

        public bool isStartsWithConsont()
        {
            return letters[0].isConstont();
        }
    }
}