using System.Diagnostics;
using Newtonsoft.Json;

namespace Day6;

public class Challenge2
{
    public Challenge1 challenge1 { get; set; } = new Challenge1();

    // Probably going to brute force this one.  Do it async so that it's a little more efficient, and print how long it takes.
    // It's going to take absolutely forever.  Whoever designed this did it in a way to make brute-forcing insanely inefficient.  I expect it'll take 30-40 minutes to run this even when running it async.
    // Lessons learned: when it comes to competitive programming, brute forcing a program is going to lead to a failure.
    // Running a while loop in an async method is asking for problems.  In my test case, there was only one example of a case that did not break the while loop.  Every other case worked and it took me a while to hunt down the bad case.  You need to exhaustively test while loops in async methods OR put in a hard stop like I did for this program.
    // Lists are not thread safe.  I had to "deep copy" the lists in order to run them async which DRASTICALLY increased the amount of memory the program uses.
    public async Task<string> Solve(List<Day6Coordinates> coordinateList, List<string> inputList)
    {
        // Debug:
        //var debugCoordinateList = DeepCopy(coordinateList);
        ////Day6Coordinates debugGuardCoordinate = new Day6Coordinates(3, 8, coordinateContent.Box);
        //Day6Coordinates debugGuardCoordinate = new Day6Coordinates(0, 0, coordinateContent.Box);
        //debugCoordinateList = ReplaceCoordinate(debugCoordinateList, debugGuardCoordinate);
        //bool check = DEBUGRunGuardProcessPossiblyUnbounded(debugCoordinateList, inputList, 83);

        //var debugCoordinateList2 = DeepCopy(coordinateList);
        //Day6Coordinates debugGuardCoordinate2 = new Day6Coordinates(1, 0, coordinateContent.Box);
        //debugCoordinateList2 = ReplaceCoordinate(debugCoordinateList2, debugGuardCoordinate2);
        //bool check2 = DEBUGRunGuardProcessPossiblyUnbounded(debugCoordinateList2, inputList, 83);


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
        int count = 0;
        foreach (var coord in coordinateList)
        {
            if (coord.content == coordinateContent.Empty)
            {
                Day6Coordinates newCoordinate = new Day6Coordinates(coord.x, coord.y, coordinateContent.Box);
                var newCoordinateList = DeepCopy(coordinateList);
                newCoordinateList = ReplaceCoordinate(newCoordinateList, newCoordinate);
                
                Task<bool> runGuardProcess = RunGuardProcessPossiblyUnbounded(newCoordinateList, inputList, count);
                runningGuardProcesses.Add(runGuardProcess);
            }
            count++;
            if (count % 1000 == 0)
            {
                Console.WriteLine(count);
            }
        }

        try
        {
            var processesComplete = await Task.WhenAll(runningGuardProcesses);
            List<bool> numberOfSuccessfulObstructions = processesComplete.ToList();
            return numberOfSuccessfulObstructions.Where(b => b == true).Count().ToString();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        return "failure";
    }

    public async Task<bool> RunGuardProcessPossiblyUnbounded(List<Day6Coordinates> coordinateList, List<string> inputList, int largeCount)
    {
        Day6Coordinates guardCoordinate = coordinateList.First(x => x.content == coordinateContent.Guard);

        Direction guardDirection = Direction.North;
        List<Day6Coordinates> lastEightObstacles = new List<Day6Coordinates>();
        // Todo: get rid of this?
        await Task.Delay(1);
        int count = 0;
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
                        //Console.WriteLine($"Broke loop: task: {largeCount}, iteration: {count}, true");
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
            }
            else
            {
                //Console.WriteLine($"Broke loop: task: {largeCount}, iteration: {count}, false");
                return false;
            }
            count++;
            //if (count % 10 == 0)
            //{
            //    Console.WriteLine($"task: {largeCount}, iteration: {count}");
            //}
            if (count > coordinateList.Count * 2)
            {
                //Console.WriteLine($"Broke loop: task: {largeCount}, iteration: {count}, true");
                return true;
            }
        }

        //Console.WriteLine($"End of loop: task: {largeCount}, iteration: {count}, true");
        return true;
    }

    // This is for debugging only.  In the test case, number 83 never breaks the while loop.
    public bool DEBUGRunGuardProcessPossiblyUnbounded(List<Day6Coordinates> coordinateList, List<string> inputList, int largeCount)
    {
        Day6Coordinates guardCoordinate = coordinateList.First(x => x.content == coordinateContent.Guard);

        Direction guardDirection = Direction.North;
        List<Day6Coordinates> lastEightObstacles = new List<Day6Coordinates>();
        int count = 0;
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
            }
            else
            {
                return false;
            }
            count++;
            if (count % 10 == 0)
            {
                Console.WriteLine($"task: {largeCount}, iteration: {count}");
            }
            if (count > coordinateList.Count * 2)
            {
                Console.WriteLine($"task: {largeCount}, iteration: {count}");
                return true;
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
