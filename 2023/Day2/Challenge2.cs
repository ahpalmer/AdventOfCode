using Advent2023Utility;
using System.Text.RegularExpressions;

namespace Advent2023Day2;

internal class Challenge2
{
    Regex regex = new Regex(@"\d+|green|blue|red", RegexOptions.ECMAScript);

    public int Solve()
    {
        List<string> inputList = Utility.CreateStringList("Challenge1.txt");
        List<(int, int, int)> answerList = new List<(int, int, int)>();

        foreach (string input in inputList)
        {
            answerList.Add(FindMatchesChallenge2(input, this.regex));
        }

        var answer = answerList.Select(x => x.Item1 * x.Item2 * x.Item3).Sum();
        return answer;
    }

    public (int, int, int) FindMatchesChallenge2(string data, Regex regex)
    {
        MatchCollection matches = regex.Matches(data);
        //order: green, red, blue
        (int, int, int) answer = (1, 1, 1);
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
                answer = TestColorNumberChallenge2(answer, lastWord, lastInt);
            }
        }

        return answer;
    }

    public (int, int, int) TestColorNumberChallenge2((int, int, int) answer, string lastWord, int lastInt)
    {
        switch (lastWord)
        {
            case "green":
                return ((lastInt > answer.Item1 ? lastInt : answer.Item1), answer.Item2, answer.Item3);
            case "red":
                return (answer.Item1, (lastInt > answer.Item2 ? lastInt : answer.Item2), answer.Item3);
            case "blue":
                return (answer.Item1, answer.Item2, (lastInt > answer.Item3 ? lastInt : answer.Item3));
            default: return answer;
        }
    }
}
