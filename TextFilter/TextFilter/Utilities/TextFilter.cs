﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextFilter.Utilities
{
    public class TextFilter : ITextFilter
    {
        public string FilterWordsWithVowelsInMiddleOfWord(string text)
        {
            var allWords = RemoveNonLetterCharacters(text).Split(' ');
            var wordsToFilter = GetWordsWithVowelsInTheMiddle(allWords);

            Regex regex = new Regex(string.Join('|', wordsToFilter), RegexOptions.Compiled);

            var result = regex.Replace(text, "");

            return result;
        }

        private List<string> GetWordsWithVowelsInTheMiddle(string[] allWords)
        {
            var vowels = "aeiou";
            var wordsWithVowelsInMiddle = new List<string>();

            foreach (var word in allWords)
            {
                var isOdd = (word.Length % 2) != 0;
                var middleOfWord = isOdd ? word.Substring(word.Length/2, 1) 
                        : word.Substring((word.Length / 2) - 1, 2);
                if (middleOfWord.Any(m => vowels.Contains(m)))
                {
                    wordsWithVowelsInMiddle.Add(word);
                }
            }

            return wordsWithVowelsInMiddle;
        }

        public string FilterWordsWithLengthLessThanThree(string text)
        {
            throw new NotImplementedException();
        }

        public string FilterWordsContainingTheLetterT(string text)
        {
            throw new NotImplementedException();
        }

        private static string RemoveNonLetterCharacters(string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == ' ')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}