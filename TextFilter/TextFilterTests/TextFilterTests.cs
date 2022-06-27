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

        [TestMethod]
        public void FilterWordsWithLengthLessThanThree()
        {
            var text = "'clean' what rather do.";
            var expectedResult = "'clean' what rather .";

            var result = _textFilter.FilterWordsWithLengthLessThanThree(text);

            result.Should().BeEquivalentTo(expectedResult);
        }

        [TestMethod]
        public void FilterWordsWithLengthLessThanThree2()
        {
            var text = "'clean' what rather do paper.";
            var expectedResult = "'clean' what rather  paper.";

            var result = _textFilter.FilterWordsWithLengthLessThanThree(text);

            result.Should().BeEquivalentTo(expectedResult);
        }

        [TestMethod]
        public void FilterWordsWithLengthLessThanThree3()
        {
            var text = "'it' dad rather do paper.";
            var expectedResult = "'' dad rather  paper.";

            var result = _textFilter.FilterWordsWithLengthLessThanThree(text);

            result.Should().BeEquivalentTo(expectedResult);
        }

        [TestMethod]
        public void FilterWordsWithLetterT()
        {
            var text = "'it' dad rather do paper.";
            var expectedResult = "'' dad  do paper.";

            var result = _textFilter.FilterWordsContainingTheLetterT(text);

            result.Should().BeEquivalentTo(expectedResult);
        }

        [TestMethod]
        public void FilterWordsWithLetterT2()
        {
            var text = "'it' dad rather do paper. Jose";
            var expectedResult = "'' dad  do paper. Jose";

            var result = _textFilter.FilterWordsContainingTheLetterT(text);

            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}