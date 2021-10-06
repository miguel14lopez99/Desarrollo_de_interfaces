using System;
using System.Collections.Generic;

namespace Ejercicio21
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the upper bound: ");
            int upperBound = Convert.ToInt32(Console.ReadLine());
            List<int> perfectList = new List<int>();
            List<int> deficientList = new List<int>();
            List<int> norPerfect_norDeficient = new List<int>();

            for (int i = 2; i < upperBound; i++)
            {

                if (isPerfect(i))
                {
                    perfectList.Add(i);
                }
                else if (isDeficient(i))
                {
                    deficientList.Add(i);
                }
                else
                {
                    norPerfect_norDeficient.Add(i);
                }

            }

            Console.WriteLine("These numbers are perfect: ");
            printList(perfectList, upperBound);
            Console.WriteLine("These numbers are deficient: ");
            printList(deficientList, upperBound);
            Console.WriteLine("These numbers are neither deficient nor perfect:: ");
            printList(norPerfect_norDeficient, upperBound);

        }

        static Boolean isPerfect(int num)
        {
            Boolean isPerfect = false;

            if (sumProperDivisors(num) == num)
            {
                isPerfect = true;
            }

            return isPerfect;
        }

        static Boolean isDeficient(int num)
        {
            Boolean isDeficient = false;

            if(sumProperDivisors(num) < num)
            {
                isDeficient = true;
            }

            return isDeficient;
        }

        static int sumProperDivisors(int num)
        {
            // Final result of summation of divisors
            int result = 0;
            if (num == 1) // there will be no proper divisor
                result = 0;
            // find all divisors which divides 'num'
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                // if 'i' is divisor of 'num'
                if (num % i == 0)
                {
                    // if both divisors are same then add
                    // it only once else add both
                    if (i == (num / i))
                        result += i;
                    else
                        result += (i + num / i);
                }
            }

            // Add 1 to the result as 1 is also a divisor
            return (result + 1);
        }

        static void printList(List<int> numList, int upperBound)
        {
            foreach (int item in numList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            double percent = (double)(numList.Count * 100) / (double)upperBound;
            Console.WriteLine("["+ numList.Count + " numbers found ("+ percent + "%)]");
        }
    }
}
