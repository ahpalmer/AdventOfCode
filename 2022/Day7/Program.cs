namespace Day7;

using Day7;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    Challenge1 Challenge1;
    Challenge2 Challenge2;
    Utility utility;

    public Program()
    {
        this.Challenge1 = new Challenge1();
        this.Challenge2 = new Challenge2();
        this.utility = new Utility();
    }

    public static void Main(string[] args)
    {
        //Challenge1.ChallengeOneSolve();
        Challenge2.ChallengeTwoSolve();
    }
}