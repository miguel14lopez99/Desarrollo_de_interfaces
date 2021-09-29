using System;

namespace Ejercicio7
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 9;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    Console.Write(i*j+ "\t|");
                }
                Console.WriteLine();
            }
        }
    }
}
