﻿// See https://aka.ms/new-console-template for more information
using System;
using System.Numerics;
using System.Linq;


/*namespace Day3
{
    class up_or_down
    {
        public void Up()
        {

        }
    }
}*/
class mainclass
{
    static void Main()
    {
        Day3.up_or_down algorithms = new Day3.up_or_down();
        string text = System.IO.File.ReadAllText(@"C:\Users\ahpal\OneDrive\Documents\2CSharp\AdventOfCode\2015\Day3_Challenge1\D3C1_input.txt");
        char[] chars = text.ToCharArray();
        int number_of_coordinates = text.Length + 1;
        /*int[,] multidimensionalArray = new int[number_direction_changes, 2];
        multidimensionalArray[0, 0] = 0;
        multidimensionalArray[0, 1] = 0;
        */
        Vector2[] array1 = new Vector2[number_of_coordinates];
        array1[0] = new Vector2(0, 0);

        int i = 0;
        foreach (char character in chars)
        {
            i++;
            if (character.ToString() == "^")
            {
                float value_x = array1[i - 1].X;
                float value_y = array1[i - 1].Y;

                array1[i] = new Vector2(value_x, value_y + 1);
                
            }
            else if (character.ToString() == "v")
            {
                float value_x = array1[i - 1].X;
                float value_y = array1[i - 1].Y;

                array1[i] = new Vector2(value_x, value_y - 1);
                
            }
            else if (character.ToString() == "<")
            {
                float value_x = array1[i - 1].X;
                float value_y = array1[i - 1].Y;

                array1[i] = new Vector2(value_x - 1, value_y + 1);
                
            }
            else if (character.ToString() == ">")
            {
                float value_x = array1[i - 1].X;
                float value_y = array1[i - 1].Y;

                array1[i] = new Vector2(value_x + 1, value_y + 1);
                
            }
        }


    }
}