using System;

namespace Ejercicio15
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
                Console.WriteLine("Enter the grade for student " + (i + 1) + ": ");
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
            Console.WriteLine("The average is:" + avg);

            int min = calculateMin(grades);
            Console.WriteLine("The minimum is:" + min);

            int max = calculateMax(grades);
            Console.WriteLine("The maximum is:" + max);

            double sd = calculate_Standard_Deviation(grades, avg);
            Console.WriteLine("The standard deviation is:" + sd);

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

        static int calculateMin(int[] grades)
        {
            int min = 0;

            foreach (int grade in grades)
            {
                if (min > grade)
                {
                    min = grade;
                }
            }

            return min;
        }

        static int calculateMax(int[] grades)
        {
            int max = 0;

            foreach (int grade in grades)
            {
                if (max < grade)
                {
                    max = grade;
                }
            }

            return max;
        }

        static double calculate_Standard_Deviation(int[] grades, double avg)
        {

            double res = 0;
            foreach (int grade in grades)
            {
                res += (grade) * (grade);
            }
            double sumOfDerivationAverage = res / (grades.Length - 1);
            return Math.Sqrt(sumOfDerivationAverage - (avg * avg));
        }
    }
}
