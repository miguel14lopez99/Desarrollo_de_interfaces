using System;

namespace Ejercicio17
{
    class Program
    {

        static void Main(string[] args)
        {
            e();
        }

        static void a()
        {
            int length = 8;

            int cont = 1;

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < (cont + i); j++)
                {

                    Console.Write("# ");

                }
                Console.WriteLine();
            }
        }

        static void b()
        {
            int length = 8;

            int cont = 0;

            for (int i = length; i > 0; i--)
            {
                for (int j = 0; j < (cont + i); j++)
                {

                    Console.Write("# ");

                }
                Console.WriteLine();
            }
        }

        static void c()
        {
            int length = 8;

            int cont = -1;

            for (int i = length; i > 0; i--)
            {
                for (int j = 0; j < (cont + i); j++)
                {
                    Console.Write("  ");
                }

                for (int k = 0; k < length-(cont + i); k++)
                {
                    Console.Write("# ");
                }

                Console.WriteLine();
            }
        }

        static void d()
        {
            int length = 8;

            int cont = -1;

            for (int i = 0 ; i < length; i++)
            {
                for (int j = 0; j < (cont + i); j++)
                {
                    Console.Write("  ");
                }

                for (int k = 0; k < length - (cont + i); k++)
                {
                    Console.Write("# ");
                }

                Console.WriteLine();
            }
        }

        static void e()
        {
            int length = 7;

            for (int i = 0; i < length; i++)
            {
                if (i == 0 || i == length-1)
                {
                    for (int j = 0; j < length; j++)
                    {
                        Console.Write("# ");
                    }
                }

                if (i != 0 || i != length-1)
                {
                    for (int j = 0; j < length; j++)
                    {
                        if (j == 0 || j == length)
                        {
                            Console.Write("# ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        static void f()
        {

        }

        static void g()
        {

        }

        static void h()
        {

        }

        static void i()
        {

        }

        static void j()
        {

        }

        static void k()
        {

        }

        static void l()
        {

        }

        static void m()
        {

        }

        static void n()
        {

        }

        static void o()
        {

        }

        static void p()
        {

        }

        static void q()
        {

        }

        static void r()
        {

        }

        static void s()
        {

        }

        static void t()
        {

        }

    }
}
