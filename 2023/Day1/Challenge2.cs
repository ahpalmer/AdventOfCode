using System.Text.RegularExpressions;
using Advent2023Utility;

namespace Advent2023Day1;

internal class Challenge2
{
    Regex regex = new Regex(@"\d|one|two|three|four|five|six|seven|eight|nine", RegexOptions.ECMAScript);
    Regex regexBackwards = new Regex(@"\d|eno|owt|eerht|ruof|evif|xis|neves|thgie|enin", RegexOptions.ECMAScript);


    public int Solve()
    {
        Challenge2 challenge2 = new Challenge2();
        List<string> dataList = Utility.CreateStringList("Challenge1.txt");
        List<int> totals = new List<int>();

        foreach (string data in dataList)
        {
            string first = challenge2.FindMatch(data, this.regex, 0);
            string backwards = ReverseText(data);
            string last = challenge2.FindMatch(backwards, this.regexBackwards, 1);

            int answer = Int32.Parse(first + last);
            totals.Add(answer);
        }

        return totals.Sum();
    }

    public string FindMatch(string data, Regex regex, int count)
    {
        MatchCollection matches = regex.Matches(data);
        Match match = matches.First();
        string digit = string.Empty;

        if (count == 0)
        {
            digit = ConvertToStringDigit(match);
        }
        else if (count == 1)
        {
            digit = ConvertToStringDigitBackwards(match);
        }

        return digit;
    }

    public string ReverseText(string text)
    {
        char[] charArray = text.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public string ConvertToStringDigit(Match match)
    {
        if (Int32.TryParse(match.ToString(), out int answer) == true)
        {
            return match.ToString();
        }
        switch(match.ToString())
        {
            case "one":
                return "1";
            case "two":
                return "2";
            case "three":
                return "3";
            case "four":
                return "4";
            case "five":
                return "5";
            case "six":
                return "6";
            case "seven":
                return "7";
            case "eight":
                return "8";
            case "nine":
                return "9";
            default:
                Console.WriteLine("error");
                return "100000000";
        }
    }

    public string ConvertToStringDigitBackwards(Match match)
    {
        if (Int32.TryParse(match.ToString(), out int answer) == true)
        {
            return match.ToString();
        }
        switch (match.ToString())
        {
            case "eno":
                return "1";
            case "owt":
                return "2";
            case "eerht":
                return "3";
            case "ruof":
                return "4";
            case "evif":
                return "5";
            case "xis":
                return "6";
            case "neves":
                return "7";
            case "thgie":
                return "8";
            case "enin":
                return "9";
            default:
                Console.WriteLine("error");
                return "100000000";
        }
    }
}
