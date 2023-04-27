namespace Day6;

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
        string data = Utility.RetrieveData();
        int answer = FindUnique(data);
        Console.WriteLine($"Challenge 1 answer: {answer}");
    }

    public static int FindUnique(string data)
    {
        for (int i = 0; i < data.Length - 3; i++)
        {
            string testSequence = data.Substring(i, 4);
            IEnumerable<char> answer = testSequence.Distinct();
            int testDebug = answer.Count();
            if (answer.Count() == 4)
            {
                return i + 4;
            }
        }
        return -1;
    }
}