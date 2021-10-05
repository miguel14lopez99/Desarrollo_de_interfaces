using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio18
{
    class TrigonometricSeries
    {

        public static double sin(double x)
        {
            double res = 0;
            int opt = 1;

            for (int i = 1; i < 10; i += 2)
            {

                switch (opt)
                {
                    case 1:
                        res += (Math.Pow(x, i) / factorial(i));
                        opt = 2;
                        break;

                    case 2:
                        res -= (Math.Pow(x, i) / factorial(i));
                        opt = 2;
                        break;
                }

            }

            return res;
        }

        public static double cos(double x)
        {
            double res = 0;
            int opt = 1;

            for (int i = 0; i < 10; i += 2)
            {

                switch (opt)
                {
                    case 1:
                        res += (Math.Pow(x, i) / factorial(i));
                        opt = 2;
                        break;

                    case 2:
                        res -= (Math.Pow(x, i) / factorial(i));
                        opt = 2;
                        break;
                }

            }

            return res;
        }

        private static double factorial(double num)
        {

            //Falta el factorial

        }

    }
}
