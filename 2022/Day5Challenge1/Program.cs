using System.Text;
using System.Text.RegularExpressions;

class Program
{
    public static void Main(string[] args)
    {
        string dir = Directory.GetCurrentDirectory();
        Console.WriteLine(dir);
        string path = dir + "\\..\\..\\..\\data\\input.txt";
        
        List<string> fileOutput = CreateStringList(path);

        List<Stack<char>> stackList = new List<Stack<char>>();
        stackList = CreateStackList(fileOutput);

        CreateIntList(fileOutput);
    }

    static List<Stack<char>> CreateStackList(List<string> fileOutput)
    {
        List<Stack<char>> reversedStack = new List<Stack<char>>();
        for (int i = 0; i < 9; i++)
        {
            reversedStack.Add(new Stack<char>());
        }

        for (int textFileLineNum = 0; textFileLineNum < 8; textFileLineNum++)
        {
            string firstLines = fileOutput[textFileLineNum];
            int count = 0;
            for (int j = 0; j < 9; j++)
            {
                int indexOfBracket = firstLines.IndexOf('[', count, 3);
                if (!(indexOfBracket == -1))
                {
                    try
                    {
                        char[] charArray = firstLines.ToCharArray();
                        reversedStack[j].Push(charArray[indexOfBracket + 1]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                count = count + 4;
            }
        }

        return ReverseStackList(reversedStack);
    }

    static List<Stack<char>> ReverseStackList(List<Stack<char>> reversedStack)
    {
        List<Stack<char>> stackList = new List<Stack<char>>();
        for (int i = 0; i < 9; i++)
        {
            stackList.Add(new Stack<char>());
        }
        for(int i = 0; i < 9; i++)
        {
            while (reversedStack[i].Count != 0)
            {
                stackList[i].Push(reversedStack[i].Pop());
            }
        }
        return stackList;
    }

    static void PrintAllStacks(List<Stack<char>> stackList)
    {
        int count2 = 0;

        foreach (Stack<char> stack in stackList)
        {
            Console.WriteLine("Stack #: {0}", count2);
            foreach (char c in stack)
            {
                Console.WriteLine(c);
            }
            count2++;
        }
    }

    static List<string> CreateStringList(string path)
    {
        List<string> returnList = new List<string>();
        using (StreamReader sr = File.OpenText(path))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                returnList.Add(line);
            }
        }
        return returnList;
    }

    //Don't actually need this I think.
    static List<List<int>> CreateIntList(List<string> fileOutput)
    {
        List<List<int>> intList = new List<List<int>>();
        fileOutput.RemoveRange(0, 10);

        //I cannot believe this worked. But it did.
        //It did not.  By breaking this down into Char, you mess up every 2 digit int.  Still, pretty cool code so I'm gonna keep it.
        //var outputWhat = fileOutput.AsEnumerable().Select(s => s.ToCharArray().AsEnumerable().Where(x => Int32.TryParse(x.ToString(), out int q)));
        //var anotherOutput = outputWhat.Select(s => s.Select(x => Int32.Parse(x.ToString())));
        //var anotheranotherOutput = anotherOutput.SelectMany((s, index) => s.Where(b => index > 9));

        var stringListOutput = fileOutput.Select(s => Regex.Split(s, " ").ToList());
        foreach(var variable in stringListOutput)
        {
            foreach(var item in variable)
            {

            }
        }

        IEnumerable<List<int>> intArrayOutput = (IEnumerable<List<int>>)stringListOutput.Select(s => s.RemoveAll(x => !Int32.TryParse(x, out var stuff)));

        foreach(var item in intArrayOutput)
        {
            Console.WriteLine($"New Line: {item}");
            foreach ( var item2 in item)
            {
                Console.WriteLine(item2);
            }
            Console.WriteLine("\n");
        }
        Console.ReadKey();

        return intList;
    }
}