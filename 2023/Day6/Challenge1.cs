using Advent2023Utility;
using System.Text.RegularExpressions;

namespace Advent2023Day6;

internal class Challenge1
{
    Regex regex = new Regex(@"(\d+)");

    internal int Solve()
    {
        List<string> stringInput = Utility.CreateStringList();
        var timeDistanceList = CreateTimeDistanceList(stringInput);
        List<int> answerList = new List<int>();

        foreach (var timeDistance in timeDistanceList)
        {
            (int, int) upperLowerBounds = QuadraticFormula(timeDistance.Item1, timeDistance.Item2);
            answerList.Add(FindSpan(upperLowerBounds));
        }

        int answer = answerList.Aggregate((workingTotal, next) => (workingTotal != 0) ? workingTotal * next : next);
        return answer;
    }

    internal List<(int, int)> CreateTimeDistanceList(List<string> stringInput)
    {
        List<int> time = new List<int>();
        List<int> distance = new List<int>();
        List<(int, int)> timeDistanceList = new List<(int, int)>();

        bool check = false;
        foreach (var input in stringInput)
        {
            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                if (!check)
                {
                    time.Add(Int32.Parse(match.Value));
                }
                else
                {
                    distance.Add(Int32.Parse(match.Value));
                }

            }
            check = true;
        }

        for(int i = 0; i < time.Count; i++)
        {
            timeDistanceList.Add((time[i], distance[i]));
        }
        return timeDistanceList;
    }

    internal int FindSpan((int, int) xBound)
    {
        return xBound.Item1 - xBound.Item2 + 1;
    }

    internal (int, int) QuadraticFormula(int timeAvailableB, int distanceC)
    {
        double a = 1;
        double bSquared = timeAvailableB * timeAvailableB;
        double fourAC = 4 * a * distanceC;
        double squareRoot = Math.Sqrt(bSquared - fourAC);
        int xUpper = (int)Math.Floor((timeAvailableB + squareRoot) / 2);
        int xLower = (int)Math.Ceiling((timeAvailableB - squareRoot) / 2);

        return (xUpper, xLower);
    }
}
