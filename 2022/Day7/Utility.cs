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

    public static DirectoryBuilds CreateDirectoryList(List<string> rawData)
    {
        DirectoryBuilds currentParentDirectory = new DirectoryBuilds("/");
        DirectoryBuilds highestParentDirectory = currentParentDirectory;
        List<string> data = rawData.Skip(1).ToList();

        foreach (string dataLine in data)
        {
            if (dataLine.Substring(2, 2) == "cd")
            {
                if (dataLine.Substring(2, 4) == "cd .")
                {
                    currentParentDirectory = currentParentDirectory.ParentDir;
                }
                else
                {
                    string newDirectoryName = dataLine.Substring(5);

                    try
                    {
                        currentParentDirectory = currentParentDirectory.Directories.Single(s => s.DirName == newDirectoryName);
                        Console.WriteLine(currentParentDirectory.DirName);
                    }
                    catch
                    {
                        Console.WriteLine("First directory error");
                    }
                }
            }

            else if (dataLine.Substring(0, 3) == "dir")
            {
                string currentDir = dataLine.Substring(4);
                DirectoryBuilds currentDirectory = new DirectoryBuilds(currentDir);
                currentDirectory.ParentDir = currentParentDirectory;
                currentParentDirectory.AddDirectory(currentDirectory);
            }
            
            else if (Int32.TryParse(dataLine[0].ToString(), out var throwAway))
            {
                string fileSizeIntermediate = Regex.Split(dataLine, @"\D+").First();
                Int32.TryParse(fileSizeIntermediate, out var fileSize);

                string fileIntermediate = Regex.Replace(dataLine, @"\d+", "");
                string fileName = Regex.Replace(fileIntermediate, @"\s", "");

                FileBuilds inputFile = new FileBuilds(fileName, fileSize);

                currentParentDirectory.AddFiles(inputFile);
            }
        }

        return highestParentDirectory;
    }
}
