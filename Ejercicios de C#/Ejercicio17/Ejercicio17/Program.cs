using System;

namespace Ejercicio17
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Type a letter from A to T (type 'x' to exit): ");
            char opt = Console.ReadLine().ToLower()[0];

            while (opt != 'x')
            {
                Console.WriteLine("Insert the size: ");
                int size = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (opt)
                {
                    case 'a':
                        PrintPatterns.a(size);
                        break;
                    case 'b':
                        PrintPatterns.b(size);
                        break;
                    case 'c':
                        PrintPatterns.c(size);
                        break;
                    case 'd':
                        PrintPatterns.d(size);
                        break;
                    case 'e':
                        PrintPatterns.e(size);
                        break;
                    case 'f':
                        PrintPatterns.f(size);
                        break;
                    case 'g':
                        PrintPatterns.g(size);
                        break;
                    case 'h':
                        PrintPatterns.h(size);
                        break;
                    case 'i':
                        PrintPatterns.i(size);
                        break;
                    case 'j':
                        PrintPatterns.j(size);
                        break;
                    case 'k':
                        PrintPatterns.k(size);
                        break;
                    case 'l':
                        PrintPatterns.l(size);
                        break;
                    case 'm':
                        PrintPatterns.m(size);
                        break;
                    case 'n':
                        PrintPatterns.n(size);
                        break;
                    case 'o':
                        PrintPatterns.o(size);
                        break;
                    case 'p':
                        PrintPatterns.p(size);
                        break;
                    case 'q':
                        PrintPatterns.q(size);
                        break;
                    case 'r':
                        PrintPatterns.r(size);
                        break;
                    case 's':
                        PrintPatterns.s(size);
                        break;
                    case 't':
                        PrintPatterns.t(size);
                        break;
                    default:
                        Console.WriteLine("The letter is incorrect");
                        break;
                }

                Console.WriteLine("\nType a letter from A to T (type 'x' to exit): ");
                opt = Console.ReadLine().ToLower()[0];
                
            }

            Console.WriteLine("\nGoodBye");
        }

    }

}
