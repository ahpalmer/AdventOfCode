using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class Challenge2
    {
        private Utility Utility;

        public Challenge2()
        {
            this.Utility = new Utility();
        }

        public static void ChallengeTwoSolve()
        {
            string dir = Directory.GetCurrentDirectory();
            Console.WriteLine(dir);
            string path = dir + "\\..\\..\\..\\data\\input.txt";

            List<string> fileOutput = Utility.CreateStringList(path);

            List<Stack<char>> stackList = new List<Stack<char>>();
            stackList = Utility.CreateStackList(fileOutput);

            IEnumerable<IEnumerable<int>> intList = Utility.CreateIntList(fileOutput);

            List<Stack<char>> finalStackList = Utility.SolveStackProblemTwo(stackList, intList);

            Utility.PrintAllStacks(finalStackList);
        }

    }
}
