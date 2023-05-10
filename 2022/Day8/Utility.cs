namespace Day8;

using System;
using System.Collections.Generic;
using System.Linq;

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
}
