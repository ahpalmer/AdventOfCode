using Day1;
using Advent2024Utility;

namespace Day4;

internal class Day4Program : IRunProgram
{
    public async Task<List<string>> Run()
    {
        List<string> inputList = Utility.CreateStringList("Day4");
        Day4.Challenge1 chal1 = new Challenge1();
        var task1 = Task.Run(() => chal1.Solve(inputList));
        var results = (await Task.WhenAll(task1)).ToList();

        //Day4.Challenge2 chal2 = new Challenge2();
        //var task2 = Task.Run(() => chal2.Solve());
        //var results = (await Task.WhenAll(task2)).ToList();

        return results;
    }
}
