using TextFilter.Utilities;

namespace TextFilter
{
    internal class TextFileFilter
    {
        private readonly ITextFilter _textFilter;
        public TextFileFilter(ITextFilter textFilter)
        {
            _textFilter = textFilter;  
        }

        public string FilterTextInFile(string fileName)
        {
            try
            {
                using (StreamReader streamReader = File.OpenText(fileName))
                {
                    string text = streamReader.ReadToEnd();
                    var listOfFilters = new List<Func<string, string>>()
                    {
                        _textFilter.FilterWordsContainingTheLetterT,
                        
                        _textFilter.FilterWordsWithVowelsInMiddleOfWord,
                        _textFilter.FilterWordsWithLengthLessThanThree
                    };

                    return applyFiltersToText(text,
                        listOfFilters);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private string applyFiltersToText(string text, List<Func<string, string>> filters)
        {
            var result = text;
            foreach (var filter in filters)
            {
                result = filter(result);
            }

            return result;
        }
    }
}
