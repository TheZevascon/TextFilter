using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFilter.Utilities;

namespace TextFilter
{
    internal class FilterTextFile
    {
        private readonly ITextFilter _textFilter;
        public FilterTextFile(ITextFilter textFilter)
        {
            _textFilter = textFilter;  
        }

        public string FilterTextInFile(string fileName)
        {
            using (StreamReader streamReader = File.OpenText(fileName))
            {
                string text = streamReader.ReadToEnd();
                Console.WriteLine(text);


                return applyFiltersToText(text,
                    _textFilter.FilterWordsContainingTheLetterT,
                    _textFilter.FilterWordsWithLengthLessThanThree,
                    _textFilter.FilterWordsWithVowelsInMiddleOfWord);

            }
        }

        private string applyFiltersToText(string text, Func<string, string> wordsContainingTheLetterT,
            Func<string, string> filterWordsContainingTheLetterT,
            Func<string, string> filterWordsWithLengthLessThanThree)
        {
            var resultText = wordsContainingTheLetterT(text);
            resultText = filterWordsContainingTheLetterT(resultText);
            return filterWordsWithLengthLessThanThree(resultText);

        }
    }
}
