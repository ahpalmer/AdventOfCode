namespace Day8;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Utility
{
    public static List<List<(bool, int)>> RetrieveData()
    {
        string dir = Directory.GetCurrentDirectory();
        string path = dir + "\\..\\..\\..\\data\\input.txt";

        return CreateStringList(path);
    }

    public static List<List<(bool, int)>> CreateStringList(string path)
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

    public static List<List<(bool, int)>> CreateDictionaryList(List<string> stringList)
    {
        int listCount = 0;
        //Dictionary won't work by itself because it is not ordered.  Maybe a List<List<Tuple>>?
        List<List<(bool, int)>> tupleList = new List<List<(bool, int)>>();
        foreach(string str in stringList)
        {
            int indexCount = 0;
            List<(bool, int)> tempTupleList = new List<(bool, int)>();
            foreach(char character in str)
            {
                Int32.TryParse(character.ToString(), out int intValue);

                if (listCount == 0 || listCount == stringList.Count - 1)
                {
                    tempTupleList.Add((true, intValue));
                }
                else if (indexCount == 0 || indexCount == str.Length - 1)
                {
                    tempTupleList.Add((true, intValue));
                }
                else
                {
                    tempTupleList.Add((false, intValue));
                }
                indexCount++;
            }
            tupleList.Add(tempTupleList);
            listCount++;
        }
        return tupleList;
    }

    public static void PrintTupleList(List<List<(bool, int)>> tupleList)
    {
        int line = 0;
        StringBuilder lineString = new StringBuilder();
        foreach (var item in tupleList)
        {
            line += 1;
            Console.WriteLine($"Line: {line}");
            lineString.Clear();
            foreach (var item2 in item)
            {
                lineString.Append(item2.Item1.ToString() + ":" + item2.Item2.ToString() + ", ");
            }
            Console.WriteLine(lineString);
            Console.WriteLine("\n");
        }
    }
}
