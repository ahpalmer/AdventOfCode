namespace Day8;

using System;
using System.Collections.Generic;
using System.Linq;

public class Utility
{
    public static List<Dictionary<bool, int>> RetrieveData()
    {
        string dir = Directory.GetCurrentDirectory();
        string path = dir + "\\..\\..\\..\\data\\input.txt";

        return CreateStringList(path);
    }

    public static List<Dictionary<bool, int>> CreateStringList(string path)
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
        return CreateDictionaryList(returnList);
    }

    public static List<Dictionary<bool, int>> CreateDictionaryList(List<string> stringList)
    {
        int indexCount = 0;
        int listCount = 0;

        //TODO: This is where you left off
        //Dictionary won't work by itself because it is not ordered.  Maybe a List<List<Tuple>>?
        List<Dictionary<bool, int>> dictList = new List<Dictionary<bool, int>>();
        foreach(string str in stringList)
        {
            Dictionary<bool, int> tempDictValue = new Dictionary<bool, int>();
            foreach(char character in str)
            {
                Int32.TryParse(character.ToString(), out int intValue);

                if (listCount == 0 || listCount == stringList.Count - 1)
                {
                    tempDictValue.Add(true, intValue);
                }
                else
                {
                    tempDictValue.Add(false, intValue);
                }
                indexCount++;
            }


            dictList.Add(tempDictValue);
            listCount++;
        }

        

        return dictList;
    }
}
