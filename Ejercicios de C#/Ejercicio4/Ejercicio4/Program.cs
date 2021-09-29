using System;

namespace Ejercicio4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 50000;
            double sum = 0;

            for (int i = n; i >= 1; i--)
            {
                sum += (1 / i);
            }

            Console.WriteLine("The sum is: "+sum);
        }
    }
}
