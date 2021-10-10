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

        static Boolean isPerfect(int num) // this method checks if the number is perfect (when the sum of its proper divisor are equal than the number)
        {
            Boolean isPerfect = false;

            if (sumProperDivisors(num) == num)
            {
                isPerfect = true;
            }

            return isPerfect;
        }

        static Boolean isDeficient(int num) // this method checks if the number is deficient (when the sum of its proper divisor are less than the number)
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

            int result = 0;
            if (num == 1) // there will be no proper divisor
                result = 0;
            
            for (int i = 2; i <= Math.Sqrt(num); i++) // find all divisors which divides by the variable num
            {
                
                if (num % i == 0) // if the posible number is divisor of the variable num
                {
                    if (i == (num / i))
                        result += i;
                    else
                        result += (i + num / i);
                }
            }

            
            return (result + 1); // it return the result plus 1 beacause 1 is also a proper divisor
        }

        static void printList(List<int> numList, int upperBound) // this methiod shows the list of numbers as well as its percertage
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
