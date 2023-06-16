using System.Text;

namespace Day1;

public class Utility
{
    public static string RetrieveData()
    {
        string dir = Directory.GetCurrentDirectory();
        string path = dir + "\\..\\..\\..\\data\\input.txt";

        return CreateInputString(path);
    }

    public static string CreateInputString(string path)
    {
        string returnString;
        StringBuilder sb = new StringBuilder();
        using (StreamReader sr = File.OpenText(path))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                sb.AppendLine(line);
            }
        }

        return sb.ToString();
    }

    public static List<string> CreateStringListCSV(string inputString)
    {
        string[] returnStringList = inputString.Split(",", StringSplitOptions.TrimEntries);
        return returnStringList.ToList();
    }
}
