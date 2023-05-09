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
        List<DirectoryBuilds> allDirectories = highestParentDirectory.CreateListOfAllParentAndChildDir();
        List<int> listSmallSizes = new List<int>();

        foreach (DirectoryBuilds directory in allDirectories)
        {
            int directorySize = directory.FindTotalDirectorySize();
            Console.WriteLine($"Directory Name: {directory.DirName}");
            Console.WriteLine($"Directory Size: {directorySize}");
            if (directorySize <= 100000)
            {
                Console.WriteLine("Yes\n");
                listSmallSizes.Add(directorySize);
            }
            else
            {
                Console.WriteLine("No\n");
            }
        }

        Console.WriteLine(listSmallSizes.Sum());
    }

}