using Advent2023Utility;
using System.Text.RegularExpressions;

namespace Advent2023Day4;

internal class Challenge2
{
    Regex regex = new Regex(@"(\d+)|(\|)", RegexOptions.ECMAScript);
    internal int Solve()
    {
        List<string> inputList = Utility.CreateStringList();
        List<(int, int)> matchesAndCards = new List<(int, int)>();

        foreach (string input in inputList)
        {
            MatchCollection matches = regex.Matches(input);
            List<int> leftNumbers = FindLeftNumbers(matches);
            List<int> rightNumbers = FindRightNumbers(matches);

            List<int> intersectingList = leftNumbers.Intersect(rightNumbers).ToList();

            matchesAndCards.Add((intersectingList.Count(), 1));

        }

        matchesAndCards = CrunchTheNumbers(matchesAndCards);

        int answer = matchesAndCards.Select(x => x.Item2).Sum();
        return answer;
    }

    public List<(int, int)> CrunchTheNumbers(List<(int, int)> matchesAndCards)
    {
        for (int x = 0; x < matchesAndCards.Count; x++)
        {
            for (int i = x + 1; i <= x + matchesAndCards[x].Item1; i++)
            {
                matchesAndCards[i] = (matchesAndCards[i].Item1, matchesAndCards[i].Item2 + matchesAndCards[x].Item2);
            }
        }

        return matchesAndCards;
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
