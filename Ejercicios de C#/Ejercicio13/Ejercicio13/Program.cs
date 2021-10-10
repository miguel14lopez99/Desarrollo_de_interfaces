using System;

namespace Ejercicio13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of students: ");
            int students = Convert.ToInt32(Console.ReadLine());

            int[] grades = new int[students]; // this array stores all the students grades

            for (int i = 0; i < students; i++)
            {
                Console.WriteLine("Enter the grade for student "+ (i + 1) +": ");
                int grade = Convert.ToInt32(Console.ReadLine());
                
                while (grade < 0 || grade > 100) // the error is displayed until the user inserts a number on range, and it's stored in the array
                {
                    Console.WriteLine("Invelid grade, try again...");
                    Console.WriteLine("Enter the grade for student " + (i + 1) + ": ");
                    grade = Convert.ToInt32(Console.ReadLine());
                }

                grades[i] = grade;

            }

            double avg = calculateAvg(grades); //the average is calculated

            Console.WriteLine("The average is:"+avg );

        }

        static double calculateAvg(int[] grades)  // method that calculate the average of all the grades in the array
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
