    using System;

namespace Ejercicio16
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] a = { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
            int[,] b = { { 3, 4 }, { 7, 2 }, { 4, 3 }, { 7, 9 } };

            int[,] res = Matrix.multiplication(a,b);

            Matrix.print(res);
        }
    }
}
