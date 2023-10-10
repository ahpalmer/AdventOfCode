namespace Day8;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class Challenge2
{
    private Utility utility;
    private (int, int) _maxScenicGrid;
    private int _maxScenicScore;

    public (int, int) maxScenicGrid
    {
        get { return _maxScenicGrid; }
        set { _maxScenicGrid = value; }
    }

    public int maxScenicScore { get; set; }

    public Challenge2()
    {
        this.utility = new Utility();
        this.maxScenicGrid = (0, 0);
        this.maxScenicScore = 0;
    }

    public void ChallengeTwoSolve()
    {
        iterateOverData(Utility.RetrieveData());

        Console.WriteLine($"did MaxScenicScore register in this class? {maxScenicScore}");
    }

    public void iterateOverData(List<List<(bool, int)>> data)
    {
        int NumberOfRows = data.Count;
        int NumberOfColumns = data[0].Count;
        int currentScenicScore = 0;

        this.maxScenicScore =
            checkUp(data, 0, 0) *
            checkDown(data, 0, 0) *
            checkRight(data, 0, 0) *
            checkLeft(data, 0, 0);

        for (int rowCurrent = 0; rowCurrent < NumberOfRows; rowCurrent++)
        {
            for (int columnCurrent = 0; columnCurrent < NumberOfColumns; columnCurrent++)
            {
                currentScenicScore =
                    checkUp(data, rowCurrent, columnCurrent) *
                    checkDown(data, rowCurrent, columnCurrent) *
                    checkRight(data, rowCurrent, columnCurrent) *
                    checkLeft(data, rowCurrent, columnCurrent);

                if (currentScenicScore > this.maxScenicScore)
                {
                    this.maxScenicScore = currentScenicScore;
                    this.maxScenicGrid = (rowCurrent, columnCurrent);
                    Console.WriteLine($"Changed maxScenicScore: {this.maxScenicScore}");
                    Console.WriteLine($"maxScenicGrid: {this.maxScenicGrid.Item1}, {this.maxScenicGrid.Item2}");
                }
            }
        }

        Console.WriteLine($"Final maxScenicScore: {this.maxScenicScore}");
        Console.WriteLine($"Final maxScenicGrid: {this.maxScenicGrid.Item1}, {this.maxScenicGrid.Item2}");
    }

    public int checkUp(List<List<(bool, int)>> data, int rowCurrent, int columnCurrent)
    {
        if (rowCurrent == 0 || columnCurrent == 0)
        { return 0; }

        int checkUpCount = 0;

        for (int rowTest = rowCurrent - 1; rowTest >= 0; rowTest--)
        {
            if (data[rowCurrent][columnCurrent].Item2 > data[rowTest][columnCurrent].Item2)
            {
                checkUpCount++;
            }
            else
            {
                checkUpCount++;
                break;
            }
        }

        return checkUpCount;
    }

    public int checkDown(List<List<(bool, int)>> data, int rowCurrent, int columnCurrent)
    {
        if (rowCurrent == 0 || columnCurrent == 0) { return 0; }
        else if (rowCurrent == data.Count || columnCurrent == data[0].Count) { return 0; }

        int checkDownCount = 0;
        for (int rowTest = rowCurrent + 1; rowTest < data.Count; rowTest++)
        {
            if (data[rowCurrent][columnCurrent].Item2 > data[rowTest][columnCurrent].Item2)
            {
                checkDownCount++;
            }
            else
            {
                checkDownCount++;
                break;
            }
        }

        return checkDownCount;
    }

    public int checkRight(List<List<(bool, int)>> data, int rowCurrent, int columnCurrent)
    {
        if (rowCurrent == 0 || columnCurrent == 0) { return 0; }
        else if (rowCurrent == data.Count || columnCurrent == data[0].Count) { return 0; }

        int checkRightCount = 0;
        for (int columnTest = columnCurrent + 1; columnTest < data[0].Count; columnTest++)
        {
            if (data[rowCurrent][columnCurrent].Item2 > data[rowCurrent][columnTest].Item2)
            {
                checkRightCount++;
            }
            else
            {
                checkRightCount++;
                break;
            }
        }

        return checkRightCount;
    }

    public int checkLeft(List<List<(bool, int)>> data, int rowCurrent, int columnCurrent)
    {
        if (rowCurrent == 0 || columnCurrent == 0) { return 0; }
        else if (rowCurrent == data.Count || columnCurrent == data[0].Count) { return 0; }

        int checkLeftCount = 0;
        for (int columnTest = columnCurrent - 1; columnTest >= 0; columnTest--)
        {
            if (data[rowCurrent][columnCurrent].Item2 > data[rowCurrent][columnTest].Item2)
            {
                checkLeftCount++;
            }
            else
            {
                checkLeftCount++;
                break;
            }
        }

        return checkLeftCount;
    }
}
