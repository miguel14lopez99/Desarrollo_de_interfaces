using System;

namespace Ejercicio5
{
    class Program
    {
        static void Main(string[] args)
        {

            double sum = 0.0;
            int op = 1;

            Console.WriteLine("Result: " + sum);

            for (int i = 1; i < 1000; i+=2)
            {
                switch (op)
                {
                    case 1:
                        sum += (1 / (double)i);
                        op = 2;
                        break;

                    case 2:
                        sum -= (1 / (double)i);
                        op = 1;
                        break;
                }
            }

            double pi = 4 * sum;

            Console.WriteLine("Result: " + pi);
        }
    }
}
