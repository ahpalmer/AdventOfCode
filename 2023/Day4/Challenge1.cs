using Advent2023Utility;
using System.Text.RegularExpressions;

namespace Advent2023Day4;

internal class Challenge1
{
    Regex regex = new Regex(@"(\d+)|(\|)", RegexOptions.ECMAScript);
    internal int Solve()
    {
        List<string> inputList = Utility.CreateStringList();
        int answer = 0;
        foreach (string input in inputList)
        {
            MatchCollection matches = regex.Matches(input);
            List<int> leftNumbers = FindLeftNumbers(matches);
            List<int> rightNumbers = FindRightNumbers(matches);

            List<int> intersectingList = leftNumbers.Intersect(rightNumbers).ToList();

            answer = (int)Math.Pow(2, intersectingList.Count - 1) + answer;
        }
        return answer;
    }

    public List<int> FindLeftNumbers(MatchCollection matches)
    {
        List<int> leftNumbers = new List<int>();
        int count = 0;
        foreach (Match match in matches)
        {
            if (count == 0)
            {
                count++;
                continue;
            }
            else if (match.Value.ToString() == "|")
            {
                return leftNumbers;
            }

            leftNumbers.Add(Int32.Parse(match.Value.ToString()));
        }

        return leftNumbers;
    }
    
    public List<int> FindRightNumbers(MatchCollection matches)
    {
        List<int> rightNumbers = new List<int>();
        int count = 0;

        foreach (Match match in matches)
        {
            if (match.Value.ToString() == "|")
            {
                count++;
                continue;
            }
            if (count == 0)
            {
                continue;
            }
            else
            {
                rightNumbers.Add(Int32.Parse(match.Value.ToString()));
            }
        }

        return rightNumbers;
    }
}
