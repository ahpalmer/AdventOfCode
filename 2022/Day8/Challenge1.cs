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
        int columnCount = 0;
        int rowCount = 0;

        foreach (var item in data)
        {
            foreach (var item2 in item)
            {
                if (item2.Item1 == true)
                {
                    Console.WriteLine("Skip");
                    columnCount++;
                    continue;
                }
                columnCount++;

                if (item2.Item2 >= data[rowCount][columnCount].Item2)
                {
                    (bool, int) tempTuple = (true, item2.Item2);

                    data[rowCount][columnCount] = tempTuple;
                }

            }

            rowCount++;
        }

        Console.ReadKey();
    }
}