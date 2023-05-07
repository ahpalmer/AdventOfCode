namespace Day7;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DataStructure;
using static System.Net.Mime.MediaTypeNames;

public class Utility
{
    public static List<string> RetrieveData()
    {
        string dir = Directory.GetCurrentDirectory();
        string path = dir + "\\..\\..\\..\\data\\input.txt";

        return CreateStringList(path);
    }

    public static List<string> CreateStringList(string path)
    {
        List<string> returnList = new List<string>();
        using (StreamReader sr = File.OpenText(path))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                returnList.Add(line);
            }
        }
        return returnList;
    }

    public DirectoryBuilds CreateDirectoryList(List<string> rawData)
    {
        string currentParentDir = "/";
        DirectoryBuilds currentParentDirectory = new DirectoryBuilds("/");
        List<string> data = rawData.Skip(1).ToList();

        foreach (string dataLine in rawData)
        {
            if (dataLine.Substring(2, 2) == "cd")
            {
                currentParentDir = dataLine.Substring(5);

                try
                {
                    currentParentDirectory = currentParentDirectory.Directories.Single(s => s.DirName == currentParentDir);
                    Console.WriteLine(currentParentDirectory.DirName);
                }
                catch
                {
                    Console.WriteLine("First directory error");
                }
            }

            else if (dataLine.Substring(0, 3) == "dir")
            {
                string currentDir = dataLine.Substring(4);
                DirectoryBuilds currentDirectory = new DirectoryBuilds(currentDir);
                currentParentDirectory.AddDirectory(currentDirectory);
            }
            
            else if (Int32.TryParse(dataLine[0].ToString(), out var throwAway))
            {
                string fileSize = Regex.Split(dataLine, @"\D+").First();
                //TODO: Fix this regex bug:
                string fileName = Regex.Replace(dataLine, "", @"\D+");
            }
        }
    }
}
