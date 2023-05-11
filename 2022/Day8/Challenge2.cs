namespace Day8;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Challenge2
{
    private Utility utility;

    public Challenge2()
    {
        this.utility = new Utility();
    }

    public static void ChallengeTwoSolve()
    {
        List<Dictionary<bool, int>> data = Utility.RetrieveData();
    }
}
