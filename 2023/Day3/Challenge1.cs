using Advent2023Utility;
using System.Text.RegularExpressions;

namespace Advent2023Day3;

internal class Challenge1
{
    Regex regexSymbols = new Regex(@"([^\w.\s])");
    Regex regexDigits = new Regex(@"\d+", RegexOptions.ECMAScript);

    internal void Solve()
    {
        List<string> inputList = Utility.CreateStringList();
        List<Point> symbolsChart = new List<Point>();
        List<NumberPoint> numbersChart = new List<NumberPoint>();
        
        int Y = 0;
        foreach (string input in inputList)
        {
            List<Point> tempSymbols = FindAllSymbols(input, Y);
            symbolsChart = symbolsChart.Concat(tempSymbols).ToList();

            List<NumberPoint> tempNumbers = FindAllNumbers(input, Y);
            numbersChart = numbersChart.Concat(tempNumbers).ToList();

            Y++;
        }

        foreach (var number in numbersChart)
        {
            List<Point> possibleCoordinates = ExpandPointList(number.PointList, inputList.Count(), inputList.First().Length());
        }
    }

    internal List<Point> FindAllSymbols(string input, int Y)
    {
        List<Point> tempSymbols = new List<Point>();

        MatchCollection matches = regexSymbols.Matches(input);
        foreach (Match match in matches)
        {
            Point tempPoint = new Point(match.Index, Y, true);
            tempSymbols.Add(tempPoint);
        }

        return tempSymbols;
    }

    internal List<NumberPoint> FindAllNumbers(string input, int Y)
    {
        List<NumberPoint> tempNumbers = new List<NumberPoint>();

        MatchCollection matches = regexDigits.Matches(input);
        foreach (Match match in matches)
        {
            NumberPoint tempNumber = new NumberPoint(Int32.Parse(match.Value));
            List<Point> coordinates = new List<Point>();
            for (int i = 0; i < match.Length; i++)
            {
                Point tempPoint = new Point(match.Index + i, Y, false);
                coordinates.Add(tempPoint);
            }
            tempNumber.PointList = coordinates;

            tempNumbers.Add(tempNumber);
        }

        return tempNumbers;
    }

    internal List<Point> ExpandPointList(List<Point> originalList, int inputY, int inputX)
    {
        foreach(Point point in originalList)
        {
            if (point.X > 0 && point.X < inputX)
            {
                Point tempPoint = new Point()
            }
        }
    }
}
