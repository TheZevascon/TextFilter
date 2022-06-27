using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TextFilter.Utilities;


namespace TextFilterTests
{
    [TestClass]
    public class TextFilterTests
    {
        private TextFilter.Utilities.TextFilter _textFilter;
        [TestInitialize]
        public void setup()
        {
            _textFilter = new TextFilter.Utilities.TextFilter();
        }
        [TestMethod]
        public void FilterWordsWithVowelInTheMiddleOfWord()
        {
            var text = "clean what rather";
            var expectedResult = "  rather";

            var result = _textFilter.FilterWordsWithVowelsInMiddleOfWord(text);

            result.Should().BeEquivalentTo(expectedResult);
        }

        [TestMethod]
        public void FilterWordsWithVowelInTheMiddleOfWord2()
        {
            var text = "clean what";
            var expectedResult = " ";

            var result = _textFilter.FilterWordsWithVowelsInMiddleOfWord(text);

            result.Should().BeEquivalentTo(expectedResult);
        }

        [TestMethod]
        public void FilterWordsWithVowelInTheMiddleOfWordDealingWithSpecialChars()
        {
            var text = "'clean' what rather.";
            var expectedResult = "''  rather.";

            var result = _textFilter.FilterWordsWithVowelsInMiddleOfWord(text);

            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}