using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace problem2_finalVarsion
{
    class TextParser
    {
        public static Text parseFile(string fileName)
        {
            Text text = new Text();

            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    Word word = new Word();
                    Sentence sent = new Sentence();

                    while (!sr.EndOfStream)
                    {
                        char ch = (char)sr.Read();
                        Symbol symbol = new Symbol(ch);

                        if (symbol.isLetter())
                        {
                            word.addLetter(symbol);
                        }
                        else 
                        {
                            word.addSymbolAfterWord(symbol);
                            sent.addWord(word);
                            word = new Word();
                            if (symbol.isEndOfSentence())
                            {
                                sent.addSymbolAfterSentence(symbol);
                                text.addSentence(sent);
                                sent = new Sentence();
                            }
                        }
                    }
                }

            }

            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found!");
            }
            return text;

        }
    }
}
