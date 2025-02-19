using System.Diagnostics;
using Newtonsoft.Json;

namespace Day6;

public class Challenge2
{
    public Challenge1 challenge1 { get; set; } = new Challenge1();

    // Probably going to brute force this one.  Do it async so that it's a little more efficient, and print how long it takes.
    public async Task<string> Solve(List<Day6Coordinates> coordinateList, List<string> inputList)
    {
        // Debug:
        //bool check = RunGuardProcessPossiblyUnbounded(coordinateList, inputList);

        // Check Memory 
        long memoryBefore = GC.GetTotalMemory(false);
        Console.WriteLine($"Memory before: {memoryBefore} bytes");

        // Check Time
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // Run the program
        string answer = await SolveBruteForce(coordinateList, inputList);

        // Measure memory usage after allocation
        long memoryAfter = GC.GetTotalMemory(false);
        Console.WriteLine($"Memory after: {memoryAfter} bytes");

        // Stop time, get elapsed time
        stopwatch.Stop();
        TimeSpan elapsed = stopwatch.Elapsed;

        // Calculate memory difference
        long memoryUsed = memoryAfter - memoryBefore;

        Console.WriteLine($"Memory used: {memoryUsed / 1048576.0:F6} MB\nElapsed Time: {elapsed.TotalSeconds:F2} seconds");

        // To trigger garbage collection (if needed):
        GC.Collect();

        Console.WriteLine(answer);
        return answer;
    }

    // Brute force.  Add one blocker at a time and check if the guard can get to the end.
    public async Task<string> SolveBruteForce(List<Day6Coordinates> coordinateList, List<string> inputList)
    {
        List<Task<bool>> runningGuardProcesses = new List<Task<bool>>();

        foreach (var coord in coordinateList)
        {
            if (coord.content == coordinateContent.Empty)
            {
                coord.content = coordinateContent.Box;
                var newCoordinateList = DeepCopy(coordinateList);
                newCoordinateList = ReplaceCoordinate(newCoordinateList, coord);
                
                Task<bool> runGuardProcess = Task.Run(() => RunGuardProcessPossiblyUnbounded(newCoordinateList, inputList));
                runningGuardProcesses.Add(runGuardProcess);
            }
        }

        List<bool> numberOfSuccessfulObstructions = (await Task.WhenAll(runningGuardProcesses)).ToList();

        return numberOfSuccessfulObstructions.Where(b => b == true).Count().ToString();
    }

    public bool RunGuardProcessPossiblyUnbounded(List<Day6Coordinates> coordinateList, List<string> inputList)
    {
        Day6Coordinates guardCoordinate = coordinateList.First(x => x.content == coordinateContent.Guard);

        Direction guardDirection = Direction.North;
        List<Day6Coordinates> lastEightObstacles = new List<Day6Coordinates>();

        while (guardCoordinate.x >= 0 && guardCoordinate.x < inputList[0].Length && guardCoordinate.y >= 0 && guardCoordinate.y < inputList.Count())
        {
            var nextCoordinateTuple = Challenge1.GetNewCoordinate(guardCoordinate, guardDirection);
            List<Day6Coordinates> nextCoordinateList = coordinateList.Where(nextCoord => nextCoord.x == nextCoordinateTuple.Item1 && nextCoord.y == nextCoordinateTuple.Item2).ToList();

            // if the nextcoordinateList does not have any coordinates then the guard has wandered off the map.
            if (nextCoordinateList.Any())
            {
                var nextCoordinate = nextCoordinateList.First();
                if (nextCoordinate.content == coordinateContent.Box)
                {
                    guardDirection = challenge1.ChangeDirection(guardDirection);

                    if (CheckLastFourObstacles(lastEightObstacles))
                    {
                        // if true, then the guard is going in circles
                        return true;
                    }
                    lastEightObstacles.Add(nextCoordinate);
                    if (lastEightObstacles.Count() > 8)
                    {
                        lastEightObstacles.RemoveAt(0);
                    }

                    continue;
                }
                Day6Coordinates updatedCoordinate = new Day6Coordinates(nextCoordinate.x, nextCoordinate.y, coordinateContent.GuardPath);

                // This might screw up the loop
                coordinateList = ReplaceCoordinate(coordinateList, updatedCoordinate);
                guardCoordinate = updatedCoordinate;
                //int index = freshCoordinateList.FindIndex(coor => coor.x == nextCoordinate.x && coor.y == nextCoordinate.y);
                //if (index != -1)
                //{
                //    freshCoordinateList[index] = updatedCoordinate;
                //    guardCoordinate = updatedCoordinate;
                //}
                //else
                //{
                //    Console.WriteLine("Couldn't find index.  Stop");
                //}
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    // Checks to see if the guard is going in circles.  True = he is going in circles.
    public bool CheckLastFourObstacles(List<Day6Coordinates> lastFourObstacles)
    {
        if (lastFourObstacles.Count() < 8)
        {
            return false;
        }
        else if (lastFourObstacles[0] == lastFourObstacles[4] && lastFourObstacles[1] == lastFourObstacles[5] && lastFourObstacles[2] == lastFourObstacles[6] && lastFourObstacles[3] == lastFourObstacles[7])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<Day6Coordinates> ReplaceCoordinate(List<Day6Coordinates> coordinateList, Day6Coordinates replacementCoordinate)
    {
        int index = coordinateList.FindIndex(coor => coor.x == replacementCoordinate.x && coor.y == replacementCoordinate.y);

        if (index != -1)
        {
            coordinateList[index] = replacementCoordinate;
        }
        else
        {
            Console.WriteLine("Couldn't find index.  Stop");
        }

        return coordinateList;
    }

    public static T DeepCopy<T>(T obj)
    {
        string json = JsonConvert.SerializeObject(obj);
        return JsonConvert.DeserializeObject<T>(json);
    }

    // Greedy solution.  It's a little bit brute force, but I follow the route of the guard and only add possible blockers in places that might work.  They might not work, and I check for that.  This is SLIGHTLY more efficient than raw brute force.
    public async Task<string> SolveGreedy(List<Day6Coordinates> coordinateList, List<string> inputList)
    {
        throw new NotImplementedException();
    }



}
