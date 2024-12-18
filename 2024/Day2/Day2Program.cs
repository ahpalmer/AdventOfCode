using Day1;
using Advent2024Utility;

namespace Day2;

public class Day2Program : IRunProgram
{
    public async Task<List<string>> Run()
    {
        Day2.Challenge1 chal1 = new Challenge1();
        Day2.Challenge2 chal2 = new Challenge2();

        //var task1 = Task.Run(() => chal1.Solve());
        var task2 = Task.Run(() => chal2.Solve());

        var results = (await Task.WhenAll(task2)).ToList();

        return results;
    }
}
