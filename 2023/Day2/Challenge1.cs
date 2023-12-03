using System.Text.RegularExpressions;
using Advent2023Utility;

namespace Advent2023Day2;

internal class Challenge1
{
    Regex regex = new Regex(@"\d+|green|blue|red", RegexOptions.ECMAScript);

    public int Solve()
    {
        List<string> inputList = Utility.CreateStringList("Challenge1.txt");
        List<(int, bool)> answerList = new List<(int, bool)>();


        foreach (string input in inputList)
        {
            answerList.Add(FindMatches(input, this.regex));
        }

        var answer = answerList.Where(x => x.Item2).Sum(x => x.Item1);

        return answer;
    }

    public (int, bool) FindMatches(string data, Regex regex)
    {
        MatchCollection matches = regex.Matches(data);
        (int, bool) answer = (Int32.Parse(matches.First().Value.ToString()), true);
        int count = 0;
        int lastInt = 0;
        string lastWord;

        foreach (Match match in matches)
        {
            if (count == 0)
            {
                count++;
                continue;
            }

            if (Int32.TryParse(match.Value.ToString(), out var throwaway))
            {
                lastInt = throwaway;
            }
            else
            {
                lastWord = match.Value.ToString();
                bool test = TestColorNumber(lastInt, lastWord);
                if (!test)
                {
                    answer.Item2 = false;
                    return answer;
                }
            }    
        }

        return answer;
    }

    public bool TestColorNumber(int lastInt, string lastWord)
    {
        switch(lastWord)
        {
            case "green":
                if (lastInt > 13) { return false; }
                else { return true; }
            case "red":
                if (lastInt > 12) { return false; }
                else { return true; }
            case "blue":
                if (lastInt > 14) { return false; }
                else { return true; }
            default: return false;
        }
    }
}
