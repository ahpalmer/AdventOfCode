namespace Day7;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructure;

public class Challenge1
{
    private Utility utility;

    public Challenge1()
    {
        this.utility = new Utility();
    }

    public static void ChallengeOneSolve()
    {
        List<string> data = Utility.RetrieveData();
        DirectoryBuilds highestParentDirectory = Utility.CreateDirectoryList(data);
        int totalSize = highestParentDirectory.FindTotalDirectorySize();
        Console.WriteLine(totalSize);
    }

}