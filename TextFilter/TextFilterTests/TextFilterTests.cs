using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using TextFilter.Utilities;

namespace TextFilterTests
{
    [TestClass]
    public class TextFilterTests
    {


        [TestMethod]
        public void FilterWordsWithVowelInTheMiddleOfWord()
        {
            var textFilter = new TextFilter.Utilities.TextFilter();
            var text = "clean what rather";
            var expectedResult = " rather";

            var result = textFilter.FilterWordsWithVowelsInMiddleOfWord(text);

            result.Should().BeEquivalentTo(expectedResult);
        }

        [TestMethod]
        public void FilterWordsWithVowelInTheMiddleOfWord2()
        {
            var textFilter = new TextFilter.Utilities.TextFilter();
            var text = "clean what";
            var expectedResult = " ";

            var result = textFilter.FilterWordsWithVowelsInMiddleOfWord(text);

            result.Should().BeEquivalentTo(expectedResult);
        }

        [TestMethod]
        public void FilterWordsWithVowelInTheMiddleOfWordDealingWithSpecialChars()
        {
            var textFilter = new TextFilter.Utilities.TextFilter();
            var text = "'clean' what rather.";
            var expectedResult = "'' rather.";

            var result = textFilter.FilterWordsWithVowelsInMiddleOfWord(text);

            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}