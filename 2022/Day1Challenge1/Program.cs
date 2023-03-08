string path = "C:\\Users\\ahpalmer\\OneDrive\\Documents\\0LocalProgrammingProjects\\AdventOfCode\\2022\\Day1Challenge1\\data\\input.txt";
using (StreamReader sr = File.OpenText(path))
{
    int biggest = 0;
    string s;
    List<int> list = new List<int>();
    while((s = sr.ReadLine()) != null)
    {
        if(s == "")
        {
            var total = list.Sum();
            foreach(var num in list)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine($"Current total: {total}");
            if (biggest < total)
            {
                biggest = total;
            }
            list.Clear();
        }
        else
        {
            list.Add(Int32.Parse(s));
        }
    }
    Console.WriteLine(biggest);
}