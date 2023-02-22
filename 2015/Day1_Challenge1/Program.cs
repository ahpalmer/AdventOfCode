// See https://aka.ms/new-console-template for more information
using System;

//Console.WriteLine("Hello, World!");

namespace Day1
{
    class floorcount
    {
        public int floor = 0;
        public void floorup()
        {
            floor += 1;
        }
        public void floordown()
        {
            floor -= 1;
        }
    }

}

class mainclass
{
    static void Main()
    {
        Day1.floorcount Test = new Day1.floorcount();
        string text = System.IO.File.ReadAllText(@"C:\Users\ahpal\OneDrive\Documents\2CSharp\AdventOfCode\2015\Day1_Challenge1\D1C1_input.txt");
        char[] chars = text.ToCharArray();
        int counter = 0;
        foreach (char c in chars)
        {
            if (c == '(')
            {
                Test.floorup();
                //Console.WriteLine(Test.floor);
                counter++;
                if(Test.floor == -1)
                {
                    Console.WriteLine(counter);
                    break;
                }
            }
            else if (c == ')')
            {
                Test.floordown();
                //Console.WriteLine(Test.floor);
                counter++;
                if(Test.floor == -1)
                {
                    Console.WriteLine(counter);
                    break;
            }
        }
    }

}