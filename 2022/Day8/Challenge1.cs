namespace Day8;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Challenge1
{
    private Utility utility;

    public Challenge1()
    {
        this.utility = new Utility();
    }

    public static void ChallengeOneSolve()
    {
        List<Dictionary<bool, int>> data = Utility.RetrieveData();

        Console.ReadKey();
    }

}