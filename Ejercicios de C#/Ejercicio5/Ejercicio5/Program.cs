using System;

namespace Ejercicio5
{
    class Program
    {
        static void Main(string[] args)
        {

            double sum = 0.0;
            int op = 1; // is a variable that is updated with each iteration

            for (int i = 1; i < 1000; i+=2) 
            {
                switch (op) // I use a switch to change the sign of the sum from positive to negative successively
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

            double pi = 4 * sum; // finally the sum is multiplied by 4, and you get the pi number

            Console.WriteLine("Result: " + pi);
        }
    }
}
