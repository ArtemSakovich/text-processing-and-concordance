using System;
using System.Collections.Generic;
using System.Text;

namespace problem2_finalVarsion
{
    class Sentence : IComparable
    {
        private List<Word> words = new List<Word>();
        private Symbol symbolAfterSentence;

        public void addWord(Word word)
        {
            if (word.containsLetters())
            words.Add(word);
        }

        public void addSymbolAfterSentence(Symbol symbol)
        {
            symbolAfterSentence = symbol;
        }
        public int getWordCount()
        {
            return words.Count;
        }

        public int CompareTo(object otherSent)
        {
            return getWordCount().CompareTo(((Sentence) otherSent).getWordCount());
        }
        public bool isInterrogative()
        {
            return symbolAfterSentence.isInterSymol();
        }
        public override string ToString()
        {
            string result = string.Empty;
            foreach (var word in words)
            {
                result += word.ToString() + " ";
            }
            return result;
        }

        public List<Word> getWords()
        {
            return words;
        }

        public void removeWord(Word word)
        {
            words.Remove(word);
        }

        public void replaceWord(Word word, Word replaceWord)
        {
            int index = words.IndexOf(word);

            words.RemoveAt(index);
            words.Insert(index, replaceWord);
        }
    }
}
