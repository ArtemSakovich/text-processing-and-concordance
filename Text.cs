using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;

namespace problem2_finalVarsion
{
    class Text
    {
        private List<Sentence> sentences = new List<Sentence>();
        public void addSentence(Sentence sent)
        {
            sentences.Add(sent);
        }

        public List<Sentence> getSentences()
        {
            return sentences;
        }

        public override string ToString()
        {
            string result = string.Empty;
            foreach (var sent in sentences)
            {
                result += sent.ToString() + " ";
            }
            return result;
        }

        public void setSentences(List<Sentence> list)
        {
            sentences = new List<Sentence>(list);
        }

    }
}
