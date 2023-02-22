using System;

namespace day2
{
    class present
    {
        public double presentcalc(string dimensions)
        {
            double area = 0;
            string[] xyz = dimensions.Split('x');
            /*foreach (var word in xyz)
            {
                System.Console.WriteLine($"<{word}>");
            }*/
            double[] double_xyz = new double[xyz.Length];
            for (int i = 0; i<xyz.Length; i++)
            {
                double_xyz[i] = Double.Parse(xyz[i]);
            }

            area = 2*(double_xyz[0] * double_xyz[1]) + 2*(double_xyz[0] * double_xyz[2]) + 2*(double_xyz[1] * double_xyz[2])+Math.Min(Math.Min(double_xyz[0] * double_xyz[1], double_xyz[0] * double_xyz[2]), double_xyz[1] * double_xyz[2]);
            System.Console.WriteLine(area);

            return area;

        }
    }
}
class mainclass
{ 
    public static void Main()
    {
        day2.present calculation = new day2.present();
        string[] filearray = System.IO.File.ReadAllLines(@"C:\Users\ahpal\OneDrive\Documents\2CSharp\AdventOfCode\2015\Day2_Challenge1\D2C1_input.txt");
        double total_area = 0;
        foreach(string line in filearray)
        {
            double temp_area = calculation.presentcalc(line);
            total_area = total_area + temp_area;
        }
        Console.WriteLine("Total area: "+total_area);
            
    }
}