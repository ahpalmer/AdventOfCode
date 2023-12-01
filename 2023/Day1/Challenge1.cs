using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Advent2023Utility;

namespace Advent2023Day1;

//Time: 1hr, 23mins
internal class Challenge1
{
    Regex regex = new Regex(@"\d", RegexOptions.ECMAScript);

    public int Solve()
    {
        List<string> dataList = Utility.CreateStringList("Challenge1.txt");
        List<int> totals = new List<int>();

        foreach (string data in dataList)
        {
            int answer = FindMatches(data, this.regex);
            totals.Add(answer);
        }

        return totals.Sum();
    }

    public int FindMatches(string data, Regex regex)
    {
        MatchCollection matches = regex.Matches(data);
        Match firstMatch = matches.First();
        Match lastMatch = matches[matches.Count - 1];

        int match = Int32.Parse(firstMatch.ToString() + lastMatch.ToString());

        return match;
    }
}
