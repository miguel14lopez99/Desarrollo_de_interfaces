using System;

namespace Ejercicio18
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number: ");
            double num = Convert.ToDouble(Console.ReadLine());

            double res = TrigonometricSeries.sin(num);
            Console.WriteLine("The sin of " + num + " is: " + res);

            res = TrigonometricSeries.cos(num);
            Console.WriteLine("The cos of " + num + " is: " + res);

        }
    }
}
