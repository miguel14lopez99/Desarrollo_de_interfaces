using System;

namespace Ejercicio13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of students: ");
            int students = Convert.ToInt32(Console.ReadLine());

            int[] grades = new int[students];

            for (int i = 0; i < students; i++)
            {
                Console.WriteLine("Enter the grade for student "+ (i + 1) +": ");
                int grade = Convert.ToInt32(Console.ReadLine());
                
                while (grade < 0 || grade > 100)
                {
                    Console.WriteLine("Invelid grade, try again...");
                    Console.WriteLine("Enter the grade for student " + (i + 1) + ": ");
                    grade = Convert.ToInt32(Console.ReadLine());
                }

                grades[i] = grade;

            }

            double avg = calculateAvg(grades);

            Console.WriteLine("The average is:"+avg );

        }

        static double calculateAvg(int[] grades)
        {
            double avg = 0;
            int sum = 0;

            foreach (int grade in grades)
            {
                sum += grade;
            }

            avg = (double)sum / (double)grades.Length;

            return avg;
        }
    }
}
