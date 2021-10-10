using System;

namespace Ejercicio4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 50000;
            double sumLToR = 0; // save the sum from left to right
            double sumRToL = 0; // save the sum from right to left

            for (int i = 0; i <= n; i++)
            {
                sumLToR += (1 / (double)i); // you need to cast the variable i to double to make the division
            }

            for (int i = n; i >= 1; i--)
            {
                sumRToL += (1 / (double)i);
            }

            Console.WriteLine("The sum (Left to Right) is: "+ sumLToR);
            Console.WriteLine("The sum (Right to Left) is: " + sumRToL);

        }
    }
}
