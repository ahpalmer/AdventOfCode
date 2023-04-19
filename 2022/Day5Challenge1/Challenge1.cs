using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day5;

namespace Day5
{
    public class Challenge1
    {
        private Utility Utility;

        public Challenge1()
        {
            this.Utility = new Utility();
        }

        public static void ChallengeOneSolve()
        {
            string dir = Directory.GetCurrentDirectory();
            Console.WriteLine(dir);
            string path = dir + "\\..\\..\\..\\data\\input.txt";

            List<string> fileOutput = Utility.CreateStringList(path);

            List<Stack<char>> stackList = new List<Stack<char>>();
            stackList = Utility.CreateStackList(fileOutput);

            IEnumerable<IEnumerable<int>> intList = Utility.CreateIntList(fileOutput);

            List<Stack<char>> finalStackList = Utility.SolveStackProblem(stackList, intList);

            Utility.PrintAllStacks(finalStackList);
        }
    }
}
