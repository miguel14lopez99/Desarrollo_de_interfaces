using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio18
{
    class TrigonometricSeries //ESTO ESTÁ MAL
    {

        public static double sin(double x)
        {
            double rad = x * (Math.PI / 180);
            double res = 0;
            int opt = 1;

            for (int i = 1; i < 20; i += 2)
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

        public static double cos(double x)
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

        private static int factorial(int num)
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
