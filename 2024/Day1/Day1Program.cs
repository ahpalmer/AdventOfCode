namespace Day1;

public class Day1Program : IDay1Program
{
    public async Task<string> Run()
    {
        Challenge1 chal1 = new Challenge1();

        var solution = await Task.Run(() => chal1.Solve());
        return solution;
    }
}
