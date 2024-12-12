using Advent2024Utility;

namespace Day1;

public class Challenge1
{
    public string Solve()
    {
        List<string> inputList = Utility.CreateStringList("Day1.txt");

        List<int> leftList = inputList.Select(x => x.Split(' ')[0]).Select(s => Int32.Parse(s)).Order().ToList();
        List<int> rightList = inputList.Select(x => x.Split(' ')[1]).Select(s => Int32.Parse(s)).Order().ToList();

        int difference = leftList.Zip(rightList, (left, right) => Math.Abs(left - right)).Sum();
        Console.WriteLine(difference.ToString());
        return difference.ToString();
    }
}
