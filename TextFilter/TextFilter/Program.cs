// See https://aka.ms/new-console-template for more information

using TextFilter;
using TextFilter.Utilities;

Console.WriteLine("Hello, World!");

ITextFilter textFilter = new TextFilter.Utilities.TextFilter();

TextFileFilter textFileFilter = new TextFileFilter(textFilter);

var filteredText = textFileFilter.FilterTextInFile("../../../../../testToFilter.txt");

Console.WriteLine(filteredText);
