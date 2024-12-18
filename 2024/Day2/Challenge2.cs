using Advent2024Utility;

namespace Day2;

public class Challenge2
{
    public async Task<string> Solve()
    {
        var data = Utility.CreateStringList("Day2.txt");

        var stepOne = data.Select(stringLine => stringLine.Split(' ')).ToList();
        List<List<int>> stepTwo = stepOne.Select(stringArray => stringArray.Select(individualStr => Int32.Parse(individualStr)).ToList()).ToList();

        var tasks = new List<Task<bool>>();

        foreach (var line in stepTwo)
        {
            var task = Task.Run(() => TestIndividualLine(line));
            tasks.Add(task);
        }
        
        List<bool> safeArray= (await Task.WhenAll(tasks)).ToList();

        Console.WriteLine(safeArray.Where(safe => safe).Count().ToString());
        return safeArray.Where(safe => safe).Count().ToString();
    }

    public bool TestIndividualLine(List<int> ints)
    {
        //List<int> ints = inputOneLine.Select(str => Int32.Parse(str)).ToList();
        if (ZipAndCheckSafety(ints)) { return true; }
        
        for (int i = 0; i < ints.Count(); i ++)
        {
            List<int> tempInts = ints.Where((item, index) => index != i).ToList();
            if (ZipAndCheckSafety(tempInts)) { return true; }
        }

        return false;
    }

    public bool ZipAndCheckSafety(List<int> inputOneLine)
    {
        var safe = inputOneLine.Zip(inputOneLine.Skip(1), (current, next) => next - current).ToList();
        if (safe.All(difference => difference > 0 && difference < 4) || safe.All(difference => difference < 0 && difference > -4))
        {
            return true;
        }
        return false;
    }
}
