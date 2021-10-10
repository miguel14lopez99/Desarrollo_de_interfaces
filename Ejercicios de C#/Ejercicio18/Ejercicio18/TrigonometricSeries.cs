using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio18
{
    class TrigonometricSeries
    {

        public static double sin(double x)
        {
            double rad = x * (Math.PI / 180); // I change the angle to radians
            double res = 0;
            int opt = 1;

            for (int i = 1; i < 20; i += 2) // this loop only makes 20 iterations, I show if I let it make more loops it returns a NaN value
            {

                switch (opt)
                {
                    case 1:
                        res += (Math.Pow(rad, i) / (double)factorial(i));
                        opt = 2;
                        break;

                    case 2:
                        res -= (Math.Pow(rad, i) / (double)factorial(i));
                        opt = 1;
                        break;
                }

            }

            return res;
        }

        public static double cos(double x) // the cos method is the same as the sin method, the only thing that changes is that the loop is initialized to 0 and not 1
        {
            double rad = x * (Math.PI / 180);
            double res = 0;
            int opt = 1;

            for (int i = 0; i < 20; i += 2)
            {

                switch (opt)
                {
                    case 1:
                        res += (Math.Pow(rad, i) / (double)factorial(i));
                        opt = 2;
                        break;

                    case 2:
                        res -= (Math.Pow(rad, i) / (double)factorial(i));
                        opt = 1;
                        break;
                }

            }

            return res;
        }

        private static int factorial(int num) // this method returns the factorial of a number using a for loop
        {
            int fact = 1;

            for (int i = 1; i <= num; i++)
            {
                fact = fact * i;

            }

            return fact;
        }
    }
}
