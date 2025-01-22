using System.Collections.Generic;

namespace Day5;

public class Challenge1
{
    public string Solve(Dictionary<int, List<int>> pageRules, List<List<int>> pageUpdates)
    {
        int count = 0;
        foreach(var pageUpdate in pageUpdates)
        {
            bool successful = true;
            for (int i = 0; i < pageUpdate.Count; i++)
            {
                List<int> tempList = pageUpdate.GetRange(0, i);
                if (pageRules.TryGetValue(pageUpdate[i], out List<int> tempList2))
                {
                    if (tempList.Any(i => tempList2.Contains(i))) 
                    {
                        successful = false;
                        break;
                    }
                }
            }
            if (successful) 
            {
                count = count + pageUpdate[pageUpdate.Count / 2];
            }
        }
        Console.WriteLine(count.ToString());
        return count.ToString();
    }

    public Dictionary<int, List<int>> CreatePageRulesDictionary(List<string> pageRules)
    {
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

    public List<List<int>> CreatePageUpdatesList(List<string> pageUpdates)
    {
        List<List<int>> result = pageUpdates
                                .Select(line => line.Split(',')
                                                    .Select(int.Parse)
                                                    .ToList())
                                .ToList();
        return result;
    }
}
