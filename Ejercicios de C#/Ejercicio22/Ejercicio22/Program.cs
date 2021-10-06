using System;

namespace Ejercicio22
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Insert the first number: ");
            int numA = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert the second number: ");
            int numB = Convert.ToInt32(Console.ReadLine());

            int result = GCD(numA, numB);
            Console.WriteLine("The result: "+result);

        }

        public static int GCD(int a, int b)
        {
            int result = 0;

            if (b == 0)
            {
                result = a;
            }
            else
            {
                int res = a % b;

                result = GCD(b, res);
            }

            return result;
        }
    }
}
