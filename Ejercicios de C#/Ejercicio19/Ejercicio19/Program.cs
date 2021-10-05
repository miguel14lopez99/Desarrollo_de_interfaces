using System;

namespace Ejercicio19
{
    class Program
    {
        static void Main(string[] args)
        {

            int randomNum = RandomNumber.random_Number(0, 99);
            Console.WriteLine("Key in your guess: ");
            int _try = Convert.ToInt32(Console.ReadLine());
            int cont = 0;

            while (randomNum != _try)
            {
                cont++;

                if (randomNum > _try)
                {
                    Console.WriteLine("Try higher: ");
                }
                if(randomNum < _try)
                {
                    Console.WriteLine("Try lower: ");
                }

                _try = Convert.ToInt32(Console.ReadLine());

            }

            Console.WriteLine("You got it in " + cont + " trials!");
        }
    }
}
