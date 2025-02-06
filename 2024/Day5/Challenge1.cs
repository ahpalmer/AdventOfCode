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
}
