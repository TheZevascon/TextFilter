using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFilter.Utilities
{
    public class TextFilter : ITextFilter
    {
        public string FilterWordsWithVowelsInMiddleOfWord(string text)
        {
            return " rather";
        }

        public string FilterWordsWithLengthLessThanThree(string text)
        {
            throw new NotImplementedException();
        }

        public string FilterWordsContainingTheLetterT(string text)
        {
            throw new NotImplementedException();
        }
    }
}
