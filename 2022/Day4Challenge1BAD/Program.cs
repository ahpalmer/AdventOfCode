string path = "C:\\Users\\andrewpalmer\\Documents\\CloudRepos\\AdventOfCode\\2022\\Day4Challenge1\\data\\input.txt";
List<string> list = CustomCreateList(path);

var dividedList = list.Select(s => new { One = s.Substring(0, (s.Length / 2) - 1), Two = s.Substring(s.Length / 2)});

foreach (var item in dividedList)
{
    Console.WriteLine($"One: {item.One} Two: {item.Two}.");
}

static List<string> CustomCreateList(string path)
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