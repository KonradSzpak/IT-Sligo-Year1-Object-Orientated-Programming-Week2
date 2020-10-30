using System;
using System.IO;
namespace Year2Sem1Week2Ex1
{
    class Program
    {

        static void Main(string[] args)
        {
            string filePath = @"C:\Users\konra\OneDrive - Institute of Technology Sligo\Modules\Year 2\Semester 1\Object Orientated Programming sem1 yr2\Year2Sem1Week2Ex1\Year2Sem1Week2Ex1\results.txt";
            string[] fileContents = File.ReadAllLines(filePath);


            int totalPoints = CalculatePoints(fileContents);

            Console.WriteLine($"total points {totalPoints}");

            Console.ReadLine();

        }


        private static int CalculatePoints(string[] data)
        {


            int[] gradeBoundaries = new int[8] { 90, 80, 70, 60, 50, 40, 30, 0 };
            int[] higherPoints = new int[8] { 100, 88, 77, 66, 56, 46, 37, 0 };

            int result = 0;
            int points = 0;
            int totalPoints = 0;

            for (int i = 0; i < data.Length; i++)
            {
                result = Convert.ToInt32(data[i]);

                for (int j = 0; j < gradeBoundaries.Length; j++)
                {

                    if (result >= gradeBoundaries[j])
                    {
                        points = higherPoints[j];
                        break;
                    }
                }
                totalPoints += points;
            }
            return totalPoints;
        }
    }
}
