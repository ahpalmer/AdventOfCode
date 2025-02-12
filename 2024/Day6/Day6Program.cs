using Advent2024Utility;
using Day1;

namespace Day6;

public class Day6Program : IRunProgram
{
    public async Task<List<string>> Run()
    {
        List<string> inputList = Utility.CreateStringList("Day6.txt");
        List<Day6Coordinates> coordinateList = CreateInputList(inputList);

        Day6.Challenge1 chal1 = new Challenge1();
        var task1 = Task.Run(() => chal1.Solve(coordinateList, inputList));
        var results = (await Task.WhenAll(task1)).ToList();

        //Day6.Challenge2 chal2 = new Challenge2();
        //var task2 = Task.Run(() => chal2.Solve(pageRules, pageUpdates));
        //var results2 = (await Task.WhenAll(task2)).ToList();

        return results;
    }

    static List<Day6Coordinates> CreateInputList(List<string> inputList)
    {
        List<Day6Coordinates> coordinateList = new List<Day6Coordinates>();
        for (int y = 0; y < inputList.Count; y++)
        {
            for (int x = 0; x < inputList[0].Length; x++)
            {
                switch (inputList[y][x])
                {
                    case '.':
                        coordinateList.Add(new Day6Coordinates(x, y, coordinateContent.Empty));
                        break;
                    case '#':
                        coordinateList.Add(new Day6Coordinates(x, y, coordinateContent.Box));
                        break;
                    case '^':
                        coordinateList.Add(new Day6Coordinates(x, y, coordinateContent.Guard));
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }

            }
        }

        return coordinateList;
    }
}

public class Day6Coordinates
{
    public int x;
    public int y;
    public coordinateContent content;

    public Day6Coordinates(int x, int y, coordinateContent content)
    {
        this.x = x;
        this.y = y;
        this.content = content;
    }
}

public enum coordinateContent
{
    Empty = 1,
    Box = 2,
    GuardPath = 3,
    Guard = 4
}