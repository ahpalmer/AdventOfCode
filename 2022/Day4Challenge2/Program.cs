string path = "C:\\Users\\andrewpalmer\\Documents\\CloudRepos\\AdventOfCode\\2022\\Day4Challenge1VS\\data\\input.txt";
List<string> list = CustomCreateList(path);

var dividedList = list
    .Select(x => x.Split("-")
        .Aggregate((workingTotal, currentNum) => workingTotal + "," + currentNum))
    .Select(s => s.Split(",").Select(x => Int32.Parse(x)).ToList());

var count = 0;
//foreach (var item1 in dividedList)
//    Console.WriteLine($"item[0]: {item1[0]}: item[1]: {item1[1]}\nitem[2]: {item1[2]}: item[3]: {item1[3]}");

foreach (var item in dividedList)
{

    //Challenge 2: This logic is incorrect.The answer must be higher than the answer for challenge 1: 530
    if (item[0] >= item[2] && item[0] <= item[3])
    { count++; }
    else if (item[2] >= item[0] && item[2] <= item[1])
    { count++; }
}

Console.WriteLine(count);
//var dividedList = list.Select(s => new { One = s.Substring(0, (s.Length / 2) - 1), Two = s.Substring(s.Length / 2) + 1 });

//foreach (var item in dividedList)
//{
//    Console.WriteLine($"One: {item.One}, Two: {item.Two}.");
//}



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