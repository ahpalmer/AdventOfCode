namespace Day1;

class Program
{
    private Utility utility;

    public Program()
    {
        this.utility = new Utility();
    }

    public static void Main(string[] args)
    {
        List<string> inputStringList= Utility.CreateStringListCSV(Utility.RetrieveData());

        //Challenge1.ChallengeOneSolve();
        //Challenge2.ChallengeTwoSolve();
    }
}