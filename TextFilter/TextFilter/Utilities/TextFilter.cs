using System.Text;
using System.Text.RegularExpressions;

namespace TextFilter.Utilities
{
    public class TextFilter : ITextFilter
    {
        public string FilterWordsWithVowelsInMiddleOfWord(string text)
        {
            var allWords = RemoveNonLetterCharacters(text).Split(' ');
            var wordsToFilter = GetWordsWithVowelsInTheMiddle(allWords.ToList());
            wordsToFilter = AddWordBoundary(wordsToFilter);

            Regex regex = new Regex(string.Join('|', wordsToFilter), RegexOptions.Compiled);

            var result = regex.Replace(text, "");

            result = result.Replace("  ", " ");

            return result;
        }

        private List<string> GetWordsWithVowelsInTheMiddle(List<string> allWords)
        {
            var vowels = "aeiouAEIOU";
            var wordsWithVowelsInMiddle = new List<string>();

            allWords = allWords.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();

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
            var allWords = RemoveNonLetterCharacters(text).Split(' ');
            var wordsToFilter = GetWordsWithLengthLessThanThree(allWords.ToList());

            wordsToFilter = AddWordBoundary(wordsToFilter);

            Regex regex = new Regex(string.Join('|', wordsToFilter), RegexOptions.Compiled);

            var result = regex.Replace(text, "");

            result = result.Replace("  ", " ");

            return result;
        }

        private List<string> AddWordBoundary(List<string> wordsToFilter)
        {
            for (int i = 0; i < wordsToFilter.Count; i++)
            {
                wordsToFilter[i] = "\\b" + wordsToFilter[i] + "\\b";
            }
            return wordsToFilter;
        }

        private List<string> GetWordsWithLengthLessThanThree(List<string> allWords)
        {
            var wordsWithLenghtLessThanThree = new List<string>();
            allWords = allWords.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            foreach (var word in allWords)
            {
                if (word.Length < 3)
                {
                    wordsWithLenghtLessThanThree.Add(word);
                }
            }

            return wordsWithLenghtLessThanThree;
        }

        public string FilterWordsContainingTheLetterT(string text)
        {
            var allWords = RemoveNonLetterCharacters(text).Split(' ');
            var wordsToFilter = GetWordsWithLetterT(allWords.ToList());
            wordsToFilter = AddWordBoundary(wordsToFilter);
            Regex regex = new Regex(string.Join('|', wordsToFilter), RegexOptions.Compiled);

            var result = regex.Replace(text, "");

            result = result.Replace("  ", " ");

            return result;
        }

        private List<string> GetWordsWithLetterT(List<string> allWords)
        {
            var wordsWithLetterT = new List<string>();
            allWords = allWords.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            foreach (var word in allWords)
            {
                
                if (word.Any(w => w.Equals('t') || w.Equals('T')))
                {
                    wordsWithLetterT.Add(word);
                }
            }

            return wordsWithLetterT;
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
