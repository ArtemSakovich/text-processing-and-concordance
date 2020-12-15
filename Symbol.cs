using System;
using System.Collections.Generic;
using System.Text;

namespace problem2_finalVarsion
{
    
    class Symbol
    {
        private static List<char> delimeters = new List<char> { ' ', ',', '\t' };
        private static List<char> noConstants = new List<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U', 'y', 'Y' };
        private char ch;

        public Symbol(char ch)
        {
            this.ch = ch;
        }

        public bool isDelimeter()
        {
            return delimeters.Contains(ch);
        }

        public bool isSpaceOrTab()
        {
            return (ch == ' ' || ch == '\t');
        }

        public void getSymbolType(char ch)
        {
            if (ch == '.')
            {

            }
        }

        public bool isLetter()
        {
            return char.IsLetter(ch);
        }
       public bool isInterSymol()
        {
            return ch == '?';
        }

        public bool isEndOfSentence()
        {
            return (ch == '.' || ch == '?' || ch == '!');
        }
        public override string ToString()
        {
            return ch.ToString();
        }

        public bool isConstont()
        {
            return (!noConstants.Contains(ch));
        }
    }
}
