namespace Day1;

public class Day1Program : IDay1Program
{
    public async Task<List<string>> Run()
    {
        Challenge1 chal1 = new Challenge1();
        Challenge2 chal2 = new Challenge2();

        //var task1 = Task.Run(() => chal1.Solve());
        var task2 = Task.Run(() => chal2.Solve());
        
        var results = (await Task.WhenAll(task2)).ToList();

        return results;
    }
}
