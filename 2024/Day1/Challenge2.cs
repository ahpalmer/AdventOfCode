using Advent2024Utility;

namespace Day1;

public class Challenge2
{
    public string Solve()
    {
        List<string> inputList = Utility.CreateStringList("Day1.txt");

        List<int> leftList = inputList.Select(x => x.Split(' ')[0]).Select(s => Int32.Parse(s)).Order().ToList();
        List<int> rightList = inputList.Select(x => x.Split(' ')[1]).Select(s => Int32.Parse(s)).Order().ToList();

        int total = 0;
        foreach (var left in leftList)
        {
            var right = rightList.Where(x => x == left).Count();
            total = total + left * right;
        }

        Console.WriteLine(total.ToString());
        return total.ToString();
    }
}
