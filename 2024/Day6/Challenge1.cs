namespace Day6;

public class Challenge1
{
    public string Solve(List<Day6Coordinates> coordinateList, List<string> inputList)
    {
        coordinateList = RunGuardProcess(coordinateList, inputList);

        string guardSteps = CountGuardSteps(coordinateList).ToString();
        Console.WriteLine(guardSteps);
        return guardSteps;
    }

    public List<Day6Coordinates> RunGuardProcess(List<Day6Coordinates> coordinateList, List<string> inputList)
    {
        Day6Coordinates guardCoordinate = coordinateList.First(x => x.content == coordinateContent.Guard);

        Direction guardDirection = Direction.North;

        while(guardCoordinate.x >= 0 && guardCoordinate.x < inputList[0].Length && guardCoordinate.y >= 0 && guardCoordinate.y < inputList.Count())
        {
            var nextCoordinateTuple = GetNewCoordinate(guardCoordinate, guardDirection);
            List<Day6Coordinates> nextCoordinateList = coordinateList.Where(nextCoord => nextCoord.x == nextCoordinateTuple.Item1 && nextCoord.y == nextCoordinateTuple.Item2).ToList();

            if (nextCoordinateList.Any())
            {
                var nextCoordinate = nextCoordinateList.First();
                if (nextCoordinate.content == coordinateContent.Box)
                {
                    guardDirection = ChangeDirection(guardDirection);
                    continue;
                }
                Day6Coordinates updatedCoordinate = new Day6Coordinates(nextCoordinate.x, nextCoordinate.y, coordinateContent.GuardPath);

                int index = coordinateList.FindIndex(coor => coor.x == nextCoordinate.x && coor.y == nextCoordinate.y);
                if (index != -1)
                {
                    coordinateList[index] = updatedCoordinate;
                    guardCoordinate = updatedCoordinate;
                }
                else
                {
                    Console.WriteLine("Couldn't find index.  Stop");
                }
            }
            else
            {
                break;
            }
        }

        return coordinateList;
    }

    public int CountGuardSteps(List<Day6Coordinates> coordinateList)
    {
        return coordinateList.Where(coord => coord.content == coordinateContent.GuardPath || coord.content == coordinateContent.Guard).Count();
    }

    public static (int, int) GetNewCoordinate(Day6Coordinates guardCoordinate, Direction guardDirection)
    {
        int x = 0, y = 0;
        switch (guardDirection)
        {
            case Direction.North:
                y = guardCoordinate.y - 1;
                x = guardCoordinate.x;
                break;
            case Direction.South:
                y = guardCoordinate.y + 1;
                x = guardCoordinate.x;
                break;
            case Direction.East:
                y = guardCoordinate.y;
                x = guardCoordinate.x + 1;
                break;
            case Direction.West:
                y = guardCoordinate.y;
                x = guardCoordinate.x - 1;
                break;
        }

        return (x, y);
    }

    public Direction ChangeDirection(Direction direction)
    {
        if (direction == Direction.North)
        {
            return Direction.East;
        }
        else if (direction == Direction.East)
        {
            return Direction.South;
        }
        else if (direction == Direction.South)
        {
            return Direction.West;
        }
        return Direction.North;
    }
}

public enum Direction
{
    North,
    South,
    East,
    West
}

