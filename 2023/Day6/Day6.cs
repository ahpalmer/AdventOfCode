namespace Advent2023Day6;

//Time: 1.5 hours.  Took me a long time to code but I found a much better solution than brute-forcing the answer
class Program
{
    public static void Main(string[] args)
    {
        Challenge1 chal1 = new Challenge1();
        Console.WriteLine(chal1.Solve());
        Challenge2 chal2 = new Challenge2();
        Console.WriteLine(chal2.Solve());
    }
}