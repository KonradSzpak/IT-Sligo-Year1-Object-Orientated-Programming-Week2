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

            int result = 0;
            int points = 0;
            int totalPoints = 0;

            foreach (string s in fileContents)
            {
                result = Convert.ToInt32(s);

                if (result >= 90)
                    points = 100;
                else if (result >= 80)
                    points = 88;
                else if (result >= 70)
                    points = 77;
                else if (result >= 60)
                    points = 66;
                else if (result >= 50)
                    points = 56;
                else if (result >= 40)
                    points = 46;
                else if (result >= 30)
                    points = 37;
                else
                    points = 0;

                totalPoints += points;


            }
            Console.WriteLine(totalPoints);
        }
    }
}
