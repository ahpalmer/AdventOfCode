namespace Day6;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Challenge2
{
    private Utility utility;

    public Challenge2()
    {
        this.utility = new Utility();
    }
    public static void ChallengeTwoSolve()
    {
        string data = Utility.RetrieveData();
        int answer = FindUnique(data);
        Console.WriteLine($"Challenge 2 answer: {answer}");
    }

    public static int FindUnique(string data)
    {
        for (int i = 0; i < data.Length - 13; i++)
        {
            string testSequence = data.Substring(i, 14);
            IEnumerable<char> answer = testSequence.Distinct();
            int testDebug = answer.Count();
            if (answer.Count() == 14)
            {
                return i + 14;
            }
        }
        return -1;
    }
}