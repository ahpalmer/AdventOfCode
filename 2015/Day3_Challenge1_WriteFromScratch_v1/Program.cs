using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;

namespace Day3_Challenge1_WriteFromScratch_v1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"C:/Users/ahpal/OneDrive/Documents/2CSharp/AdventOfCode/2015/Day3_Challenge1_WriteFromScratch_v1/D3C1_input.txt");
            //Console.WriteLine(text);
            char[] chars = text.ToCharArray();
            //Console.WriteLine(chars);
            int number_of_coordinates = text.Length + 1;
            Console.WriteLine((text.Length/2)+1);
            Vector2[] Santa = new Vector2[(text.Length/2)+1];
            Vector2[] Robo_Santa = new Vector2[(text.Length/2)+1];
            Console.WriteLine($"Santa and Robo_santa sizes.  Santa: {Santa.Count()}, Robo_Santa: {Robo_Santa.Count()}");
            int Santa_count = 0;
            int Robo_count = 1;
            for (int i = 1; i < number_of_coordinates/2; i++)
            {
                Santa[i] = Choosing_a_Direction(Santa[i - 1], chars[Santa_count]);
                Robo_Santa[i] = Choosing_a_Direction(Robo_Santa[i - 1], chars[Robo_count]);
                Santa_count = Santa_count + 2;
                Robo_count = Robo_count + 2;
            }
            Console.WriteLine("Number of characters: {0}", text.Length);
            Console.WriteLine("Number of Vectors in Santa Array (Should be 1 more than text) {0}", Santa.Count());
            Console.WriteLine("Number of Vectors in Robo_Santa Array (Should be 1 less than Santa) {0}", Robo_Santa.Count());


            int final_count = Array_Final_Count(Combine_Arrays(Santa, Robo_Santa));
            Console.WriteLine("The Final count is: {0}", final_count);
            Console.ReadKey();
        }

        static Vector2 Choosing_a_Direction(Vector2 original_vector, char c)
        {
            if (c.ToString() == "^")
            {
                //Console.WriteLine("New Vector: X: {0}, Y: {1}", original_vector.X,original_vector.Y + 1);
                Vector2 placeholder = new Vector2(original_vector.X,original_vector.Y + 1);
                return placeholder;
            }
            else if (c.ToString() == "v")
            {
                //Console.WriteLine("New Vector: X: {0}, Y: {1}", original_vector.X,original_vector.Y - 1);
                Vector2 placeholder = new Vector2(original_vector.X,original_vector.Y - 1);
                return placeholder;
            }
            else if (c.ToString() == ">")
            {
                //Console.WriteLine("New Vector: X: {0}, Y: {1}", original_vector.X+1,original_vector.Y);
                Vector2 placeholder = new Vector2(original_vector.X + 1,original_vector.Y);
                return placeholder;
            }
            else if (c.ToString() == "<")
            {
                //Console.WriteLine("New Vector: X: {0}, Y: {1}", original_vector.X-1,original_vector.Y);
                Vector2 placeholder = new Vector2(original_vector.X - 1,original_vector.Y);
                return placeholder;
            }
            else
            {
                Console.WriteLine("Error");
                Console.ReadKey();
                return original_vector;
            }
        }

        static Vector2[] Combine_Arrays(Vector2[] Santa, Vector2[] Robo_Santa)
        {
            Vector2[] Combined = Santa.Concat(Robo_Santa).ToArray();
            return Combined;
        }

        static int Array_Final_Count(Vector2[] print_array)
        {
            var distinct_array = print_array.Distinct();
            Console.WriteLine(distinct_array.Count());
            return distinct_array.Count();
        }
    }
}
