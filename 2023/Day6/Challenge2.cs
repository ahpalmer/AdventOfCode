using Advent2023Utility;
using System.Text.RegularExpressions;

namespace Advent2023Day6;

internal class Challenge2
{
    Regex regex = new Regex(@"(\d+)");

    internal long Solve()
    {
        List<string> stringInput = Utility.CreateStringList();
        var timeDistanceList = CreateTimeDistanceList(stringInput);
        List<long> answerList = new List<long>();

        foreach (var timeDistance in timeDistanceList)
        {
            (long, long) upperLowerBounds = QuadraticFormula(timeDistance.Item1, timeDistance.Item2);
            answerList.Add(FindSpan(upperLowerBounds));
        }

        long answer = answerList.Aggregate((workingTotal, next) => (workingTotal != 0) ? workingTotal * next : next);
        return answer;
    }

    internal List<(long, long)> CreateTimeDistanceList(List<string> stringInput)
    {
        string time = "";
        string distance = "";
        List<(long, long)> timeDistanceList = new List<(long, long)>();

        bool check = false;
        foreach (var input in stringInput)
        {
            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                if (!check)
                {
                    time = time + match.Value.ToString();
                }
                else
                {
                    distance = distance + match.Value.ToString();
                }

            }
            check = true;
        }

        timeDistanceList.Add((Int64.Parse(time), Int64.Parse(distance)));
        return timeDistanceList;
    }

    internal long FindSpan((long, long) xBound)
    {
        return xBound.Item1 - xBound.Item2 + 1;
    }

    internal (long, long) QuadraticFormula(long timeAvailableB, long distanceC)
    {
        double a = 1;
        double bSquared = timeAvailableB * timeAvailableB;
        double fourAC = 4 * a * distanceC;
        double squareRoot = Math.Sqrt(bSquared - fourAC);
        long xUpper = (long)Math.Floor((timeAvailableB + squareRoot) / 2);
        long xLower = (long)Math.Ceiling((timeAvailableB - squareRoot) / 2);

        return (xUpper, xLower);
    }
}
