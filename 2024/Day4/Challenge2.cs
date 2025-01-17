namespace Day4;

public class Challenge2
{
    private static readonly (int dx, int dy, int direction)[] directions = new[]
    {
        (-1, -1, 0), (-1, 1, 1),  // Top left,top right
        (1, -1, 2),  (1, 1, 3)    // Bottom left, bottom right
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
                if (inputList[y][x] == 'A')
                {
                    if (CheckForMASX(inputList, x, y)) { totalXmas++; }
                }
            }
        }

        Console.WriteLine(totalXmas.ToString());
        return totalXmas.ToString();
    }

    public bool CheckForMASX(List<string> inputList, int x, int y)
    {
        if (y - 1 >= 0 && x - 1 >= 0 && y + 1 < inputList.Count && x + 1 < inputList[0].Count())
        {
            char upperLeft = inputList[y - 1][x - 1];
            char upperRight = inputList[y - 1][x + 1];
            char lowerLeft = inputList[y + 1][x - 1];
            char lowerRight = inputList[y + 1][x + 1];
            if ((upperLeft == 'M' && lowerRight == 'S') || (upperLeft == 'S' && lowerRight == 'M'))
            {
                if ((upperRight == 'M' && lowerLeft == 'S') || (upperRight == 'S' && lowerLeft == 'M'))
                {
                    return true;
                }
            }
        }


        return false;
    }
}
