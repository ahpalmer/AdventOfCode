using Advent2024Utility;
using System.Text.RegularExpressions;

namespace Day3;

internal class Challenge1
{
    public string Solve()
    {
        var input = Utility.CreateStringList("Day3.txt");
        string pattern = @"mul\(\d+,\d+\)";
        List<int> multipliedNumbers = new List<int>();

        foreach (var item in input)
        {
            MatchCollection matches = Regex.Matches(item, pattern);
            foreach (Match match in matches)
            {
                int leftNumber = getRegexNumber(match.Value, @"\(\d+");
                int rightNumber = getRegexNumber(match.Value, @",\d+");

                multipliedNumbers.Add(leftNumber * rightNumber);
            }
        }

        Console.WriteLine(multipliedNumbers.Sum().ToString());
        return multipliedNumbers.Sum().ToString();
    }

    public int getRegexNumber(string input, string pattern)
    {
        Match match = Regex.Match(input, pattern);
        return Int32.Parse(match.Value.Substring(1));
    }
}
