using Advent2024Utility;
using System.Text.RegularExpressions;

namespace Day3;

public class Challenge2
{
    Challenge1 challenge1 = new Challenge1();
    public string Solve()
    {
        var input = Utility.CreateStringList("Day3.txt");
        string pattern = @"mul\(\d+,\d+\)|do\(\)|don\'t\(\)";
        List<int> multipliedNumbers = new List<int>();
        bool countMoreNumbers = true;

        foreach (var item in input)
        {
            MatchCollection matches = Regex.Matches(item, pattern);
            foreach (Match match in matches)
            {
                if (match.Value == "do()" && !countMoreNumbers)
                {
                    countMoreNumbers = true;
                    continue;
                }
                else if (match.Value == "don't()" && countMoreNumbers)
                {
                    countMoreNumbers = false;
                    continue;
                }
                else if (match.Value == "do()" || match.Value == "don't()")
                {
                    continue;
                }

                if (countMoreNumbers)
                {
                    int leftNumber = challenge1.getRegexNumber(match.Value, @"\(\d+");
                    int rightNumber = challenge1.getRegexNumber(match.Value, @",\d+");

                    multipliedNumbers.Add(leftNumber * rightNumber);
                }
            }
        }

        Console.WriteLine(multipliedNumbers.Sum().ToString());
        return multipliedNumbers.Sum().ToString();
    }
}
