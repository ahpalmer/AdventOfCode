using Advent2024Utility;

namespace Day2;

public class Challenge2
{
    public string Solve()
    {
        var data = Utility.CreateStringList("Day2.txt");

        var stepOne = data.Select(stringLine => stringLine.Split(' ')).ToList();
        List<List<int>> stepTwo = stepOne.Select(stringArray => stringArray.Select(individualStr => Int32.Parse(individualStr)).ToList()).ToList();

        var stepThree = stepTwo.Select(listInts => listInts.Zip(listInts.Skip(1), (current, next) => 4 > current - next && current - next > 0 ? 1 : 0).ToList()).ToList();
        var stepThreeNegative = stepTwo.Select(listInts => listInts.Zip(listInts.Skip(1), (current, next) => -4 < current - next && current - next < 0 ? -1 : 0).ToList()).ToList();

        var countOne = stepThree.Where(listInts => listInts.All(ints => ints == 1)).Count();
        var countTwo = stepThreeNegative.Where(listInts => listInts.All(ints => ints == -1)).Count();

        Console.WriteLine((countOne + countTwo).ToString());
        return (countOne + countTwo).ToString();
    }
}
