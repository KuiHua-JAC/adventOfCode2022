using System;
using System.IO;

namespace adventOfCode2022
{
    class Program
    {
        static void Main(string[] args)
        {
            AdventQuestionI();
        }

        static string[] ReadFile(string fileName)
        {
            try
            {
                if (!File.Exists(fileName))
                    throw new ArgumentException("No such file exists");

                return File.ReadAllLines(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new string[] {};
        }

        /// <summary>
        /// Question 1 in Advent of calendar. Finding the max in an "array" and top 3.
        /// </summary>
        static void AdventQuestionI()
        {
            string[] content = ReadFile("advent1.txt");

            int max = 0, sum = 0, max1 = 0, max2 = 0;

            foreach(string line in content)
            {
                if (string.IsNullOrEmpty(line))
                {
                    // Looks for the max value. Will store the "max" value if it's not the same as the biggest,etc.
                    if (max < sum)
                        max = sum;
                    else if (max1 < sum && max1 != max)
                        max1 = sum;
                    else if (max2 < sum && max2 != max1)
                        max2 = sum;
                    sum = 0;
                }
                else
                    sum += int.Parse(line);
            }
            Console.WriteLine(max+max1+max2);
        }
    }
}

