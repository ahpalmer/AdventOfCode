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
        List<string> data = Utility.RetrieveData();
        DirectoryBuilds highestParentDirectory = Utility.CreateDirectoryList(data);
        int totalSize = highestParentDirectory.FindTotalDirectorySize();
        Console.WriteLine($"Total size of biggest directory: {totalSize}");
        Console.WriteLine($"Total - 70000000: {70000000 - totalSize}");
        int deleteAtLeastThisMuch = totalSize - 40000000;
        Console.WriteLine($"30000000 - (ans): {deleteAtLeastThisMuch}");
        List<DirectoryBuilds> allDirectories = highestParentDirectory.CreateListOfAllParentAndChildDir();
        List<int> listSmallSizes = new List<int>();

        foreach (DirectoryBuilds directory in allDirectories)
        {
            int directorySize = directory.FindTotalDirectorySize();
            if (directorySize >= deleteAtLeastThisMuch)
            {
                listSmallSizes.Add(directorySize);
            }
        }

        Console.WriteLine(listSmallSizes.Min());
    }
}
