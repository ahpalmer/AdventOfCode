//practice LINQ statements
//Make a method that returns a Generic list, use LINQ to analyze generic list


using System.Globalization;
using System.Xml;

string path = "D:\\LocalRepos\\AdventOfCode\\2022\\Day3Challenge1\\data\\input.txt";
var list = CreateList(path);
//Now Linq statements
//Write them individually.  You don't have to do a multiple LINQ statement like Marlee does yet.
//Test
/*
var listLinq = list.Where((s, n) => n < (s.Length / 2)).Select((s, n) => s[n]);
var listLinq = list.Select(s => s.Split(s[s.Length / 2], 2));
*/

/*
//This block of code splits every string in half and prints the first half.
var listLinq = list.Select(s => s.Substring(0, (s.Length / 2)));
Console.WriteLine($"Number of items in list 1: {listLinq.Count()}");
Console.WriteLine("Break\nBreak\nBreak\nBreak");

//splits every string in half and prints second half
var listLinq2 = list.Select(s => s.Substring(s.Length / 2));
Console.WriteLine($"Number of items in list 2: {listLinq2.Count()}");
//foreach (var item in listLinq2)
//{
//    Console.WriteLine(item);
//}

//var listLinq3 = listLinq2.Intersect(listLinq);
var listLinq3 = listLinq2.Select(s => s.Intersect(listLinq);
Console.WriteLine(listLinq3);
Console.WriteLine(listLinq3.Count());
foreach (var item in listLinq3)
{
    Console.WriteLine(item);
}
*/

/*List<string> result = list.Select(s => s.Substring(0, s.Length / 2)
                                        .Intersect(s.Substring(s.Length / 2))
                                        .ToList())
                            .ToList();
*/
var result = list.Select(s => s.Substring(0, s.Length / 2)
                                        .Intersect(s.Substring(s.Length / 2))
                                        .ToList());

int count = 0;
List<int> counter = new List<int>();
foreach (var item in result)
{
    if (item[0] > 96)
    {
        //Console.WriteLine($"{item[0]}: {item[0] - 96}");
        counter.Add(item[0] - 96);
    }
    else if (item[0] > 64)
    {
        //Console.WriteLine($"{item[0]}: {item[0] - 38}");
        counter.Add(item[0] - 38);
    }
    else
    {
        Console.WriteLine("Error");
        count++;
    }
}
Console.WriteLine(count);
Console.WriteLine(counter.Sum());

/*
//Nice Try
var listLinq3 = list.Select(s => s.Substring(s.Length / 2)).Intersect(listLinq.Select(s=>s));
Console.WriteLine(listLinq3);
foreach (var item in listLinq3)
{
    Console.WriteLine(item);
}*/

static List<string> CreateList(string path)
{
    var list = new List<string>();
    using (StreamReader sr = File.OpenText(path))
    {
        string s;
        while((s = sr.ReadLine()) != null)
        {
            list.Add(s);
        }
        return list;
    }
}