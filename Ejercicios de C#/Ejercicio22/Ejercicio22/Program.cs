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

            
            int result = 0;
            if (numA < numB) // if the second number is greater than the first they have to enter in the GCD method inversely
            {
                result = GCD(numB, numA);
            }
            else
            {
                result = GCD(numA, numB);
            }

            Console.WriteLine("The result: "+result);

        }

        public static int GCD(int a, int b) // a and b integers have to enter into the method in order. This method returns the GCD of the inserted numbers
        {
            int result = 0;

            if (b == 0)
            {
                result = a; // if b is equal to 0, the result is a
            }
            else
            {
                int res = a % b;

                result = GCD(b, res); // if not the method is called recursively with b and (a mod b)
            }

            return result;
        }
    }
}
