using System;
using System.Numerics;
using System.Linq;

class mainclass
{
    static void Main()
    {
        string text = System.IO.File.ReadAllText(@"C:\Users\ahpal\OneDrive\Documents\2CSharp\AdventOfCode\2015\Day3_Challenge1\D3C1_input.txt");
        char[] chars = text.ToCharArray();
        double half = text.Length / 2;
        Console.WriteLine(text.Length.GetType());
        Vector2[] array1 = new Vector2[number_of_coordinates];
        //Vector2[] array2 = new Vector2[]
        array1[0] = new Vector2(0, 0);

        int i = 0;
        foreach (char character in chars)
        {
            i++;
            if (i%2 == 5)
            {
                Console.WriteLine(i);
            }

        }
        
        int totalcount = 0;
        var distinct_array = array1.Distinct();
        totalcount = distinct_array.Count();
        Console.WriteLine("The final count is: ");
        Console.WriteLine(totalcount);
    }
    public void Santa_Movement(ref int i, ref char character, ref Vector2[] array)
    {
        if (character.ToString() == "^")
        {


            float value_x = array[i - 1].X;
            float value_y = array[i - 1].Y;

            array[i] = new Vector2(value_x, value_y + 1);

        }
        else if (character.ToString() == "v")
        {
            float value_x = array[i - 1].X;
            float value_y = array[i - 1].Y;

            array[i] = new Vector2(value_x, value_y - 1);

        }
        else if (character.ToString() == "<")
        {
            float value_x = array[i - 1].X;
            float value_y = array[i - 1].Y;

            array[i] = new Vector2(value_x - 1, value_y);

        }
        else if (character.ToString() == ">")
        {
            float value_x = array[i - 1].X;
            float value_y = array[i - 1].Y;

            array[i] = new Vector2(value_x + 1, value_y);

        }
    }
}