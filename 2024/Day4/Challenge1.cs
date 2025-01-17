using Advent2024Utility;
using System.ComponentModel;
using System.Net.Http.Headers;

namespace Day4;

public class Challenge1
{
    private static readonly (int dx, int dy, int direction)[] directions = new[]
    {
        (-1, -1, 1), (-1, 0, 2), (-1, 1, 3),  // Top left, top, top right
        (0, -1, 4),           (0, 1, 5),   // Left, right
        (1, -1, 6),  (1, 0, 7),  (1, 1, 8)    // Bottom left, bottom, bottom right
    };
    public string Solve(List<string> inputList)
    {
        int yLength = inputList.Count;
        int xLength = inputList[0].Count();
        int totalXmas = 0;

        for (int y = 0; y < yLength; y++)
        {
            for (int x = 0; x < xLength; x++)
            {
                if (inputList[y][x] == 'X')
                {
                    totalXmas = totalXmas + CheckForXMAS(inputList, x, y);
                }
            }
        }

        Console.WriteLine(totalXmas.ToString());
        return totalXmas.ToString();
    }

    public int CheckForXMAS(List<string> inputList, int x, int y)
    {
        int totalXMAS = 0;

        foreach (var (dx, dy, direction) in directions)
        {
            int newXM = x + dx;
            int newYM = y + dy;

            if (newXM >= 0 && newYM >= 0 && newXM < inputList[0].Count() && newYM < inputList.Count)
            {
                char testCharacterM = inputList[newYM][newXM];
                if (testCharacterM == 'M')
                {
                    int newXA = newXM + dx;
                    int newYA = newYM + dy;

                    if (newXA >= 0 && newYA >= 0 && newXA < inputList[0].Count() && newYA < inputList.Count)
                    {
                        char testCharacterA = inputList[newYA][newXA];
                        if (testCharacterA == 'A')
                        {
                            int newXS = newXA + dx;
                            int newYS = newYA + dy;

                            if (newXS >= 0 && newYS >= 0 && newXS < inputList[0].Count() && newYS < inputList.Count)
                            {
                                char testCharacterS = inputList[newYS][newXS];
                                if (testCharacterS == 'S')
                                {
                                    totalXMAS += 1;
                                }
                            }
                        }
                    }

                }
            }
        }

        return totalXMAS;
    }
}
