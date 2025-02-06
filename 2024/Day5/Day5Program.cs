using Advent2024Utility;
using Day1;

namespace Day5;

public class Day5Program : IRunProgram
{
    public async Task<List<string>> Run()
    {
        List<string> inputList = Utility.CreateStringList("Day5.txt");
        Dictionary<int, List<int>> pageRules = GetFirstList(inputList);
        List<List<int>> pageUpdates = GetSecondList(inputList);

        //Day5.Challenge1 chal1 = new Challenge1();
        //var task1 = Task.Run(() => chal1.Solve(pageRules, pageUpdates));
        //var results = (await Task.WhenAll(task1)).ToList();

        Day5.Challenge2 chal2 = new Challenge2();
        var task2 = Task.Run(() => chal2.Solve(pageRules, pageUpdates));
        var results2 = (await Task.WhenAll(task2)).ToList();

        return results2;
    }

    static Dictionary<int, List<int>> GetFirstList(List<string> inputList)
    {
        List<string> pageRules = new List<string>();
        foreach (string line in inputList)
        {
            if (line == "")
            {
                break;
            }
            pageRules.Add(line);
        }

        Dictionary<int, List<int>> pageRulesDict = new Dictionary<int, List<int>>();
        foreach (var pageRule in pageRules)
        {
            int leftValue = Int32.Parse(pageRule[0].ToString() + pageRule[1].ToString());
            int rightValue = Int32.Parse(pageRule[3].ToString() + pageRule[4].ToString());
            if (pageRulesDict.TryGetValue(leftValue, out List<int> oldList))
            {
                List<int> newList = oldList.ToList();
                newList.Add(rightValue);
                pageRulesDict.Remove(leftValue);
                pageRulesDict.Add(leftValue, newList);
            }
            else
            {
                pageRulesDict.Add(leftValue, new List<int> { rightValue });
            }
        }
        return pageRulesDict;
    }

    static List<List<int>> GetSecondList(List<string> inputList)
    {
        List<string> pageUpdates = new List<string>();
        foreach (string line in inputList)
        {
            if (line.Contains("|") || string.IsNullOrEmpty(line))
            {
                continue;
            }
            pageUpdates.Add(line);
        }

        List<List<int>> result = pageUpdates
                        .Select(line => line.Split(',')
                                            .Select(int.Parse)
                                            .ToList())
                        .ToList();
        return result;
    }
}
