using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio17
{
    class PrintPatterns
    {

        public static void a(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write("# ");
                }
                Console.WriteLine();
            }
        }

        public static void b(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                for (int j = 0; j <= size - i; j++)
                {
                    Console.Write("# ");
                }
                Console.WriteLine();
            }
        }

        public static void c(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                for (int j = 0; j <= size; j++)
                {
                    if (j >= i)
                    {
                        Console.Write("# ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void d(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                for (int j = 0; j <= size; j++)
                {
                    if (j > size - i)
                    {
                        Console.Write("# ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void e(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    if (i == 1 || i == size || j == 1 || j == size)
                    {
                        Console.Write("# ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }

                Console.WriteLine();

            }
        }

        public static void f(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    if (i == 1 || i == j || i == size)
                    {
                        Console.Write("# ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }

                Console.WriteLine();

            }
        }

        public static void g(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == 1 || i == size - j || i == size)
                    {
                        Console.Write("# ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }

                Console.WriteLine();

            }
        }

        public static void h(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == 1 || i == size - j || i == j + 1 || i == size)
                    {
                        Console.Write("# ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }

                Console.WriteLine();

            }
        }

        public static void i(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == 1 || j == 0 || i == size - j || i == j + 1 || i == size || j == size - 1)
                    {
                        Console.Write("# ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }

                Console.WriteLine();

            }
        }

        public static void j(int size)
        {
            int floor = (size * 2) - 1;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < floor; j++)
                {
                    if (i <= floor - j - 1 && i <= j)
                    {
                        Console.Write("# ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }

                Console.WriteLine();

            }
        }

        public static void k(int size)
        {
            int floor = (size * 2) - 1;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < floor; j++)
                {
                    if (size - i - 1 <= floor - j - 1 && size - i - 1 <= j)
                    {
                        Console.Write("# ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }

                Console.WriteLine();

            }
        }

        public static void l(int size)
        {
            int floor = (size * 2) - 1;
            for (int i = 0; i < floor; i++)
            {
                for (int j = 0; j < floor; j++)
                {

                    if (i < size)
                    {
                        if (size - i - 1 <= floor - j - 1 && size - i - 1 <= j)
                        {
                            Console.Write("# ");
                        }
                        else
                        {
                            Console.Write("  ");
                        }
                    }
                    else
                    {
                        if (i - size + 1 <= floor - j - 1 && i - size + 1 <= j)
                        {
                            Console.Write("# ");
                        }
                        else
                        {
                            Console.Write("  ");
                        }
                    }
                }

                Console.WriteLine();

            }
        }

        public static void m(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(j + 1 + " ");
                }
                Console.WriteLine();
            }
        }

        public static void n(int size)
        {
            int printnum = 1;
            for (int i = 1; i <= size; i++)
            {
                for (int j = 0; j <= size; j++)
                {
                    if (j >= i)
                    {
                        Console.Write(printnum + " ");
                        printnum++;
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
                printnum = 1;
            }
        }

        public static void o(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                for (int j = 0; j <= size; j++)
                {
                    if (j > size - i)
                    {
                        Console.Write(size + 1 - j + " ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void p(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                for (int j = 0; j <= size - i; j++)
                {
                    Console.Write(size + 1 - j - i + " ");
                }
                Console.WriteLine();
            }
        }

        public static void q(int size)
        {
            int printnum = 1;
            int floor = (size * 2) - 1;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < floor; j++)
                {
                    if (size - i - 1 <= floor - j - 1 && size - i - 1 <= j)
                    {

                        if (j < size - 1)
                        {
                            Console.Write(printnum + " ");
                            printnum++;
                        }
                        else
                        {
                            Console.Write(printnum + " ");
                            printnum--;
                        }

                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }

                Console.WriteLine();
                printnum = 1;

            }
        }

        public static void r(int size)
        {
            int printnum = 1;
            int floor = (size * 2) - 1;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < floor; j++)
                {
                    if (i <= floor - j - 1 && i <= j)
                    {
                        if (j < size - 1)
                        {
                            Console.Write(printnum + " ");
                            printnum++;
                        }
                        else
                        {
                            Console.Write(printnum + " ");
                            printnum--;
                        }
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }

                Console.WriteLine();
                printnum = 1;
            }
        }

        public static void s(int size)
        {
            int printnum = 1;
            for (int i = 1; i <= size; i++)
            {
                int floor = (size * 2) - 1;
                for (int j = 0; j != floor; j++)
                {
                    if (j < i || j >= floor - i)
                    {
                        if (j < size - 1)
                        {
                            Console.Write(printnum + " ");

                        }
                        else
                        {

                            Console.Write(printnum + " ");

                        }

                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    if (j < size - 1)
                    {
                        printnum++;
                    }
                    else
                    {
                        printnum--;
                    }


                }
                Console.WriteLine();
                printnum = 1;
            }



        }
        public static void t(int size)
        {
            int printnum = 1;
            int floor = (size * 2) - 1;
            for (int i = 1; i <= size; i++)
            {
                for (int j = 0; j < floor; j++)
                {
                    if (j < size - (i - 1) || j - (i - 2) >= size)
                    {
                        Console.Write(printnum + " ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    if (j < size - 1)
                    {
                        printnum++;
                    }
                    else
                    {
                        printnum--;
                    }

                }
                Console.WriteLine();
                printnum = 1;
            }
        }

    }
}
