namespace Advent2023Utility;

public class Utility
{
    public static string RetrieveData(string fileName = "input.txt")
    {
        return File.ReadAllText(Utility.GetPath(fileName));
    }

    public static List<string> CreateStringList(string fileName = "input.txt")
    {
        List<string> returnList = new List<string>();
        using (StreamReader sr = File.OpenText(Utility.GetPath(fileName)))
        {
            string line;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            while ((line = sr.ReadLine()) != null)
            {
                returnList.Add(line);
            }
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        }
        return returnList;
    }

    public static string GetPath(string fileName = "input.txt")
    {
        string dir = Directory.GetCurrentDirectory();
        return dir + "\\..\\..\\..\\data\\" + fileName;
    }
}
