using System;

namespace day2
{
    class ribbon
    {
        public double ribboncalc(string dimensions)
        {
            double ribbon_length = 0;
            string[] xyz = dimensions.Split('x');
            /*foreach (var word in xyz)
            {
                System.Console.WriteLine($"<{word}>");
            }*/
            double[] double_xyz = new double[xyz.Length];
            for (int i = 0; i < xyz.Length; i++)
            {
                double_xyz[i] = Double.Parse(xyz[i]);
            }

            //create an instance of the class middle_number
            middle_number mid_class = new middle_number();
            double middle_number = mid_class.mid_number_calculation(double_xyz);
            double bottom_number = Math.Min(Math.Min(double_xyz[0], double_xyz[1]), double_xyz[2]);

            ribbon_length = (2 * middle_number + 2 * bottom_number + (double_xyz[0] * double_xyz[1] * double_xyz[2]));


            System.Console.WriteLine(ribbon_length);

            return ribbon_length;

        }
    }

    //This Class finds the middle number in a 3 number array
    class middle_number
    {
        public double mid_number_calculation(double[] midnumarray)
        {
            if (midnumarray[0] > midnumarray[1])
            {
                if (midnumarray[1] > midnumarray[2])
                    return midnumarray[1];
                else if (midnumarray[0] > midnumarray[2])
                    return midnumarray[2];
                else
                    return midnumarray[0];
            }
            else
            {
                if (midnumarray[0] > midnumarray[2])
                    return midnumarray[0];
                else if (midnumarray[1] > midnumarray[2])
                    return midnumarray[2];
                else
                    return midnumarray[1];
            }
        }
    }
}
class mainclass
{
    public static void Main()
    {
        day2.ribbon calculation = new day2.ribbon();
        string[] filearray = System.IO.File.ReadAllLines(@"C:\Users\ahpal\OneDrive\Documents\2CSharp\AdventOfCode\2015\Day2_Challenge1\D2C1_input.txt");
        double total_length = 0;
        foreach (string line in filearray)
        {
            double temp_length = calculation.ribboncalc(line);
            total_length = total_length + temp_length;
        }
        Console.WriteLine("Total length: " + total_length);

    }
}