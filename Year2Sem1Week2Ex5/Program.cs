using System;
using System.IO;
namespace Year2Sem1Week2Ex5
{
    class Program
    {
        static void Main(string[] args)
        {


            int j = 1;
            string name = "";
            string studentNumber = "";
            string[] subjects = new string[7] { " ", " ", " ", " ", " ", " ", " ", };
            string[] levels = new string[7] { " ", " ", " ", " ", " ", " ", " ", };
            string[] grades = new string[7] { " ", " ", " ", " ", " ", " ", " ", };
            int[] points = new int[7];

            Console.Write("Enter name: ");
            name = Console.ReadLine();

            Console.Write("enter student number: ");
            studentNumber = Console.ReadLine();

            for (int i = 0; i < subjects.Length; i++)
            {
                Console.Write("Enter subject {0}: ", j);
                subjects[i] = Console.ReadLine();

                Console.Write("Enter level for {0}: ", subjects[i]);
                levels[i] = Console.ReadLine();

                Console.Write("Enter grade for {0}: ", subjects[i]);
                grades[i] = Console.ReadLine();
                j++;
            }
            Array.Sort(grades);
            //calls method
            int totalPoint = CalculatePoints(grades, levels, points); 
            DisplayResults(name, studentNumber, subjects, grades, levels, points, totalPoint);
            WriteDetailsToFile(name, studentNumber, subjects, grades, levels, points, totalPoint);

        }



        private static int CalculatePoints(string[] data, string[] levels, int[] studentPoints)
        {

            int[] gradeBoundaries = new int[8] { 90, 80, 70, 60, 50, 40, 30, 0 };
            int[] higherPoints = new int[8] { 100, 88, 77, 66, 56, 46, 37, 0 };
            int[] ordinaryPoints = new int[8] { 56, 46, 37, 28, 20, 12, 0, 0 };

            int totalPoints = 0;
            int points = 0;


            for (int i = 0; i < data.Length; i++)
            {
                int result = Convert.ToInt32(data[i]);

                for (int j = 0; j < gradeBoundaries.Length; j++)
                {

                    if (result >= gradeBoundaries[j])
                    {
                        points = levels[i].ToLower().Equals("h") ? higherPoints[j] : ordinaryPoints[j];
                        break;
                    }
                }
                studentPoints[i] = points;
            }
            Array.Sort(studentPoints);
            Array.Reverse(studentPoints);

            for (int i =0; i <6; i++)
            {
                totalPoints += studentPoints[i];
            }
            return totalPoints;
        }

        private static void DisplayResults(string name, string studentNum, string[] subjects, string[] results, string[] levels, int[] points, int totalPoints)
        {
            Console.WriteLine("Name: {0}", name);
            Console.WriteLine("Student number {0}: ", studentNum);
            
            for (int i=0; i < results.Length; i++)
            {
                Console.WriteLine($"{subjects[i],10} {levels[i],10} {results[i],10 } {points[i],10}");
            }
            Console.WriteLine($"total points {totalPoints}");


        }

        private static void WriteDetailsToFile(string name, string studentNum, string[] subjects, string[] results, string[] levels, int[] points, int totalPoints)
        {
            string filePath = @"C:\Users\konra\OneDrive - Institute of Technology Sligo\Modules\Year 2\Semester 1\Object Orientated Programming sem1 yr2\Year2Sem1Week2Ex1\Year2Sem1Week2Ex1\results.txt";
            StreamWriter sw = new StreamWriter(filePath);
            sw.WriteLine("Name: {0}", name);
            sw.WriteLine("Student number {0}: ", studentNum);

            for (int i = 0; i < results.Length; i++)
            {
                sw.WriteLine($"{subjects[i],10} {levels[i],10} {results[i],10 } {points[i],10}");
            }
            sw.WriteLine($"total points {totalPoints}");

            sw.Flush();
            sw.Close();

            Console.WriteLine("sucessfully writen to file");
        }
    }
}
