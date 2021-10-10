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
            int cont = 0; // this variable counts the number of attempts

            while (randomNum != _try) // this loop check if the try is equal to the random number, and shows if the try if higher or lower
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
