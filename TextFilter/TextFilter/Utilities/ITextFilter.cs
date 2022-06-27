using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFilter.Utilities
{
    internal interface ITextFilter
    {
        /// <summary>
        /// Filter out all the words that contains a vowel in the middle of
        /// the word – the centre 1 or 2 letters ("clean" middle is ‘e’,
        /// "what" middle is ‘ha’, "currently" middle is ‘e’ and should be
        /// filtered, "the", "rather" should not be)
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Filtered Text</returns>
        string FilterWordsWithVowelsInMiddleOfWord(string text);

        /// <summary>
        /// Filter out words that have length less than 3
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        string FilterWordsWithLengthLessThanThree(string text);

        /// <summary>
        /// Filter out words that contains the letter ‘t’
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        string FilterWordsContainingTheLetterT(string text);


    }
}
