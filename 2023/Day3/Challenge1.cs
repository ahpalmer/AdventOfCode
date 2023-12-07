using Advent2023Utility;
using System.Text.RegularExpressions;

namespace Advent2023Day3;

//3hr 15 mins.
internal class Challenge1
{
    Regex regexSymbols = new Regex(@"([^\w.\s])");
    Regex regexDigits = new Regex(@"\d+", RegexOptions.ECMAScript);

    internal int Solve()
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

        List<Point> possibleCoordinates = ExpandPointList(symbolsChart);

        foreach (var number in numbersChart)
        {

            number.nearTwoNumbers = doTheListsMatch(number.PointList, possibleCoordinates);
        }

        int answer = numbersChart.Where(x => x.nearTwoNumbers == true).Select(y => y.Number).Sum();

        return answer;
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

    internal List<Point> ExpandPointList(List<Point> originalList)
    {
        List<Point> answerList = new List<Point>();
        answerList = answerList.Concat(originalList).ToList();

        foreach (Point point in originalList)
        {
            //&& point.X < inputX might need this later
            if (point.X == 0 && point.Y == 0)
            {
                answerList.Add(new Point(point.X + 1, point.Y));
                answerList.Add(new Point(point.X + 1, point.Y + 1));
                answerList.Add(new Point(point.X, point.Y + 1));

            }
            else if (point.X == 0)
            {
                answerList.Add(new Point(point.X, point.Y + 1));
                answerList.Add(new Point(point.X, point.Y - 1));
                answerList.Add(new Point(point.X + 1, point.Y));
                answerList.Add(new Point(point.X + 1, point.Y + 1));
                answerList.Add(new Point(point.X + 1, point.Y - 1));

            }
            else if (point.Y == 0)
            {
                answerList.Add(new Point(point.X - 1, point.Y));
                answerList.Add(new Point(point.X + 1, point.Y));
                answerList.Add(new Point(point.X - 1, point.Y + 1));
                answerList.Add(new Point(point.X + 1, point.Y + 1));
                answerList.Add(new Point(point.X, point.Y + 1));
            }
            else
            {
                answerList.Add(new Point(point.X - 1, point.Y));
                answerList.Add(new Point(point.X + 1, point.Y));
                answerList.Add(new Point(point.X, point.Y - 1));
                answerList.Add(new Point(point.X, point.Y + 1));
                answerList.Add(new Point(point.X - 1, point.Y - 1));
                answerList.Add(new Point(point.X + 1, point.Y - 1));
                answerList.Add(new Point(point.X - 1, point.Y + 1));
                answerList.Add(new Point(point.X + 1, point.Y + 1));
            }
        }

        return answerList;
    }

    internal bool doTheListsMatch(List<Point> listToTest, List<Point> possibleCoordinates)
    {
        foreach(Point point in listToTest)
        {
            var possibleCoordsStrings = possibleCoordinates.Select(x => x.ToString());
            if (possibleCoordsStrings.Contains(point.ToString()))
            {
                return true;
            }
        }

        return false;
    }
}
