using System;

namespace Ejercicio7
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 9; // the length of the table

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    Console.Write(i*j+ "\t|"); // I multiply each number with the others with two nested for's and show the result
                }
                Console.WriteLine();
            }
        }
    }
}
