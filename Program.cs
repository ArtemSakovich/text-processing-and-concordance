using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace problem2_finalVarsion
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"C:\workspace\input.txt";
            Text text = TextParser.parseFile(fileName);

            foreach (var sent in text.getSentences())
            {
                Console.Write(sent);
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("1 - Display all sentences of the given text in ascending order of the number of words in each of them");
            Console.WriteLine("2 - In all interrogative sentences of the text, find and print words of a given length without repetitions");
            Console.WriteLine("3 - Remove all words of a given length starting with a consonant from the text");
            Console.WriteLine("4 - In some sentence of the text, replace words of a given length with the specified substring, the length of which may not match the word length");
            Console.WriteLine("5 - Concordance" + "\r\n");

            Console.Write("Please choose an action: ");
            int numberOfMenuPoint = Convert.ToInt32(Console.ReadLine());

            switch (numberOfMenuPoint)
            {
                case 1:
                    printAllSentencesAsc(text);
                    break;
                case 2:
                    Console.Write("Please enter the length of word: ");
                    int requiredLength = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    printTaskNumber2(text, requiredLength);
                    break;
                case 3:
                    Console.Write("Please enter the length of word: ");
                    int requiredLength1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    printTaskNumber3(text, requiredLength1);
                    break;
                case 4:
                    Console.Write("Please enter the nubmer of sentence: ");
                    int numberOfSentence = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("Please enter the length of word: ");
                    int requiredLength2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("Please enter the string to replace: ");
                    string replaceString = Console.ReadLine();
                    Console.WriteLine();
                    printTaskNumber4(text, numberOfSentence, requiredLength2, replaceString);
                    break;
                case 5:
                    printTaskNumber5(text);
                    break;
                default:
                    Console.WriteLine("Incorrect input!");
                    break;
            }
        }

        public static void printAllSentencesAsc(Text text)
        {
            List<Sentence> clonedList = new List<Sentence>(text.getSentences());

            clonedList.Sort();

            foreach (var sent in clonedList)
            {
                Console.Write(sent.ToString());
            }
            Console.WriteLine();
        }
        public static void printTaskNumber2(Text text, int requiredLength)
        {
            Dictionary<Word, int> map = new Dictionary<Word, int>();

            foreach (var sent in text.getSentences())
            {
                if (sent.isInterrogative())
                {
                    foreach (var word in sent.getWords())
                    {
                        if (word.getLettersCount() == requiredLength)
                        {
                            map.Add(word, 1);
                        }
                    }
                }
            }

            foreach (KeyValuePair<Word, int> pair in map)
            {
                Console.Write(pair.Key.toStringWithoutAfterWordSymbol() + " ");
            }
        }
           
        public static void printTaskNumber3(Text original, int requiredLength)
        {
            Text text = new Text();
            text.setSentences(original.getSentences());


            foreach (var sent in text.getSentences())
            {
                List<Word> wordsToDelete = new List<Word>();
                foreach (var word in sent.getWords())
                {
                    if (word.isStartsWithConsont() && word.getLettersCount() == requiredLength)
                    {
                        wordsToDelete.Add(word);
                    }
                }
                foreach (var word in wordsToDelete)
                {
                    sent.removeWord(word);
                }
            }
            Console.Write(text.ToString());
            Console.WriteLine();
        }
        public static void printTaskNumber4(Text original, int sentanceNumber, int requiredLength, string replaceString)

        {
            Word replaceWord = new Word(replaceString);

            Text text = new Text();
            text.setSentences(original.getSentences());

            Sentence sent = text.getSentences()[sentanceNumber];
            List<Word> wordsToReplace = new List<Word>();
            foreach (var word in sent.getWords())
            {
                if (word.getLettersCount() == requiredLength)
                {
                    wordsToReplace.Add(word);
                }
            }
            foreach (var word in wordsToReplace)
            {
                sent.replaceWord(word, replaceWord);
            }
            
            Console.Write(text.ToString());
            Console.WriteLine();
        }

        public static void printTaskNumber5(Text text)

        {
            Dictionary<string, List<int>> map = new Dictionary<string, List<int>>();

            List<int> list = new List<int>();

            for (int i = 0; i < text.getSentences().Count; i++)
            {
                var sent = text.getSentences()[i];

                for (int j = 0; j < sent.getWordCount(); j++)
                {
                    var word = sent.getWords()[j].toStringWithoutAfterWordSymbol();

                    if (!map.ContainsKey(word))
                    {
                        map.Add(word, new List<int>());
                        map[word].Add(i);
                    }
                    else
                    {
                        map[word].Add(i);
                    }
                }

                list.Clear();

            }

             foreach (KeyValuePair<string, List<int>> pair in map.OrderBy(key => key.Key))
             {
                 Console.Write("Word: " + pair.Key + " appeared in text " + pair.Value.Count + " times. In sentences number: ");

                 List<int> distinct = pair.Value.Distinct().ToList();

                 foreach (var numberOfSentence in distinct)
                 {
                     Console.Write(numberOfSentence + " ");
                 }

                 Console.WriteLine();
             }
        }
    }
}
