using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Verisk
{
    class Program
    {
        static void Main(string[] args)
        {
            //Return a distinct list of all the characters in the file along with their counts. The results should be sorted by character.
            string fileName = @"..\..\..\File\A Tale of Two Cities - Charles Dickens.txt";
            string fileText = new StreamReader(fileName).ReadToEnd().Replace("\r\n", "");
            var orderByCharacter = fileText.Distinct().OrderBy(x => x).ToList();
            var characterCount = orderByCharacter.Count();

            //Return a distinct list of all punctuation in the file along with their counts. The results should be sorted based on punctuation occurrence from most frequent to least frequent.
            var punctuations = fileText.Where(c => char.IsPunctuation(c)).ToList();
            var punctuationsGrouby = punctuations.GroupBy(x=>x).OrderByDescending(g=>g.Key);

            //regular expression was gotten from internet
            //Return a list of distinct words and their respective counts ordered alphabetically.
            var words = Regex.Matches(fileText, @"\b(?:[a-z]{2,}|[ai])\b",
                            RegexOptions.IgnoreCase).ToList();
            var wordGrouby = words.GroupBy(x => x.Value).Select(g=>new WordCount { Word = g.Key, Count = g.Count() }).OrderBy(g => g.Word).ToList();

            //Return a list of matches with the matching line number based on a given “search request”. The “search request” could be a single word, multiple words, or a phrase.
            var searchWord = "EBook";
            List<int> lineNumber = new List<int>();
            string line;
            int count=1;
            StreamReader file = new StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains(searchWord))
                    lineNumber.Add(count);
                count++;
            }

            //Return top "X" used words (with an option to include or exclude conjunctions) and their counts where "X" is a passed in parameter.
            int X = 200;
            var result1 = topUsedWord(wordGrouby, X, true);
            var result2 = topUsedWord(wordGrouby, X, false);
            Console.ReadLine();
        }


        private static List<WordCount> topUsedWord(List<WordCount> wordGrouby, int topX, bool includeConjunctions)
        {
            List<string> conjunctionWordsList = new List<string>() { "but", "and" }; // find one on internet
            if (includeConjunctions)
                return wordGrouby.Where(x => x.Count >= topX).ToList();
            else
            {
                var conjunctionWords = new HashSet<string>(conjunctionWordsList);
                var result = wordGrouby.Where(x => !conjunctionWords.Contains(x.Word) && x.Count >= topX).ToList();
                return result;
            }
        }

        private class WordCount
        {
            public string Word { get; set; }
            public int Count { get; set; }
        }
    }
}
