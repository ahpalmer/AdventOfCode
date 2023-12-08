namespace Advent2023Day3;

class Day3
{
    //My goal for this advent of code is to go fast, but do the code right (within reason).  It might take me a little longer to do it properly.
    //Challenge 1: 3hr, 15 mins
    //Chal 2: 1 hr, 10 mins
    //Total: 4hr, 25 mins
    static void Main(string[] args)
    {
        Challenge1 chal1 = new Challenge1();
        Console.WriteLine(chal1.Solve());
        Challenge2 chal2 = new Challenge2();
        Console.WriteLine(chal2.Solve());
    }
}