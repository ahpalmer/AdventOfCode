using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5;

public class Challenge2
{
    public string Solve(Dictionary<int, List<int>> pageRules, List<List<int>> pageUpdates)
    {
        List<List<int>> failedPageUpdates = new List<List<int>>();
        int count = 0;
        foreach (var pageUpdate in pageUpdates)
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
                        failedPageUpdates.Add(pageUpdate);
                        break;
                    }
                }
            }
        }

        List<List<int>> correctedPageUpdates = PutFailedPagesInOrder(pageRules, failedPageUpdates);
        foreach (var correctedPage in correctedPageUpdates)
        {
            count = count + correctedPage[correctedPage.Count / 2];
        }
        Console.WriteLine(count.ToString());
        return count.ToString();
    }

    public List<List<int>> PutFailedPagesInOrder(Dictionary<int, List<int>> pageRules, List<List<int>> failedPageUpdates)
    {
        List<List<int>> sortedPageUpdates = new List<List<int>>();
        foreach (var failedPage in failedPageUpdates)
        {
            sortedPageUpdates.Add(MergeSort(pageRules, failedPage));
        }

        return sortedPageUpdates;
    }

    public List<int> MergeSort(Dictionary<int, List<int>> pageRules, List<int> arrayToSort)
    {
        if (arrayToSort.Count <=1)
        { return arrayToSort; }

        int middle = arrayToSort.Count / 2;

        var leftArray = MergeSort(pageRules, arrayToSort.GetRange(0, middle));
        var rightArray = MergeSort(pageRules, arrayToSort.GetRange(middle, arrayToSort.Count - middle));

        return Merge(pageRules, leftArray, rightArray);
    }

    public List<int> Merge(Dictionary<int, List<int>> pageRules, List<int> leftArray, List<int> rightArray)
    {
        int i = 0; int j = 0;
        List<int> finalArray = new List<int>();
        while (i < leftArray.Count && j < rightArray.Count)
        {
            if (pageRules.TryGetValue(leftArray[i], out List<int> rulesForLeftNumber))
            {
                if (rulesForLeftNumber.Contains(rightArray[j]))
                {
                    finalArray.Add(leftArray[i]);
                    i++;
                }
                else
                {
                    finalArray.Add(rightArray[j]);
                    j++;
                }
            }
        }

        while (i < leftArray.Count)
        {
            finalArray.Add(leftArray[i++]);
        }
        while (j < rightArray.Count)
        {
            finalArray.Add(rightArray[j++]);
        }

        return finalArray;
    }
}
