string path = "C:\\Users\\ahpalmer\\OneDrive\\Documents\\0LocalProgrammingProjects\\AdventOfCode\\2022\\Day1Challenge1\\data\\input.txt";
using (StreamReader sr = File.OpenText(path))
{
    Console.WriteLine("Start");
    List<int> biggest = new List<int> { 0, 0, 0 };
    string s;
    List<int> list = new List<int>();
    while ((s = sr.ReadLine()) != null)
    {
        if (s == "")
        {
            var total = list.Sum();

            Console.WriteLine($"Current total: {total}");
            if (biggest[2] < total)
            {
                Console.WriteLine("List before sort:");
                biggest.Add(total);
                foreach (var num2 in biggest)
                {
                    Console.WriteLine(num2);
                }

                Console.WriteLine("List after sort:");
                biggest.Sort((a, b) => b.CompareTo(a));
                foreach (var num3 in biggest)
                {
                    Console.WriteLine(num3);
                }
                Console.WriteLine("List after removal:");
                biggest.RemoveAt(3);
                foreach (var num4 in biggest)
                {
                    Console.WriteLine(num4);
                }

            }
            list.Clear();
        }
        else
        {
            list.Add(Int32.Parse(s));
        }
    }
    Console.WriteLine("Answer:");
    foreach(var num in biggest)
    {
        Console.WriteLine(num);
    }
    Console.WriteLine(biggest.Sum());
    Console.ReadKey();
}