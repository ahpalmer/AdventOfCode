namespace Day8;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Challenge1
{
    private Utility utility;

    public Challenge1()
    {
        this.utility = new Utility();
    }

    public static void ChallengeOneSolve()
    {
        List<List<(bool, int)>> data = Utility.RetrieveData();
        //Utility.PrintTupleList(data);
        data = SolveLeftToRightAndTopToBottom(data);
        data = SolveRightToLeftAndBottomToTop(data);

        int boolCount = data.SelectMany(x => x).Where(x => x.Item1 == true).Count();
        Console.WriteLine($"There are {boolCount} visible trees");
        Console.ReadKey();
    }

    public static List<List<(bool, int)>> SolveLeftToRightAndTopToBottom(List<List<(bool, int)>> data)
    {
        int NumberOfRows = data.Count;
        int NumberOfColumns = data[0].Count;

        List<int> MaxColumnHeight = data[0].Select(x => x.Item2).ToList();

        for (int rowCount = 0; rowCount < NumberOfRows; rowCount++)
        {
            int rowMaxHeight = data[rowCount][0].Item2;

            for (int c = 0; c < NumberOfColumns; c++)
            {
                if (data[rowCount][c].Item1 == true)
                {
                    Console.WriteLine("Skip");
                    continue;
                }

                if (data[rowCount][c].Item2 > rowMaxHeight)
                {
                    rowMaxHeight = data[rowCount][c].Item2;
                    (bool, int) tempTuple = (true, data[rowCount][c].Item2);

                    data[rowCount][c] = tempTuple;

                    Console.WriteLine($"Left to Right: Replaced Row: {rowCount} and Column: {c}");
                }

                if (data[rowCount][c].Item2 > MaxColumnHeight[c])
                {
                    MaxColumnHeight[c] = data[rowCount][c].Item2;
                    (bool, int) tempTuple = (true, data[rowCount][c].Item2);

                    data[rowCount][c] = tempTuple;

                    Console.WriteLine($"Top Down: Replaced Row: {rowCount} and Column: {c}");

                }
            }
        }

        return data;
    }

    public static List<List<(bool, int)>> SolveRightToLeftAndBottomToTop(List<List<(bool, int)>> data)
    {
        int NumberOfRows = data.Count - 1;
        int NumberOfColumns = data[0].Count - 1;

        List<int> MaxColumnHeight = data[NumberOfRows].Select(x => x.Item2).ToList();

        for (int rowCount = NumberOfRows - 1; rowCount > 0; rowCount--)
        {
            int rowMaxHeight = data[rowCount][NumberOfColumns].Item2;

            for (int columnCount = NumberOfColumns; columnCount > 0; columnCount--)
            {
                if (data[rowCount][columnCount].Item2 > rowMaxHeight)
                {
                    rowMaxHeight = data[rowCount][columnCount].Item2;
                    (bool, int) tempTuple = (true, data[rowCount][columnCount].Item2);

                    data[rowCount][columnCount] = tempTuple;

                    Console.WriteLine($"Left to Right: Replaced Row: {rowCount} and Column: {columnCount}");
                }

                if (data[rowCount][columnCount].Item2 > MaxColumnHeight[columnCount])
                {
                    MaxColumnHeight[columnCount] = data[rowCount][columnCount].Item2;
                    (bool, int) tempTuple = (true, data[rowCount][columnCount].Item2);

                    data[rowCount][columnCount] = tempTuple;

                    Console.WriteLine($"Top Down: Replaced Row: {rowCount} and Column: {columnCount}");

                }
            }
        }

        return data;
    }
}