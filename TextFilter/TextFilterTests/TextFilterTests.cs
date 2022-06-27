using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace TextFilterTests
{
    [TestClass]
    public class TextFilterTests
    {


        [TestMethod]
        public void FilterVowelInTheMiddleOfWords()
        {
            var textFilter = new TextFilter();
            var text = "clean what rather";
            var expectedResult = " rather";

            var result = textFilter.FilterVowelsInMiddleOfWord(text);

            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}