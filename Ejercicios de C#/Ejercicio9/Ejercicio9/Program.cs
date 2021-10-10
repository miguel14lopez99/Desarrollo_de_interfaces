using System;

namespace Ejercicio9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a String: ");
            String text = Console.ReadLine();

            Console.Write("The reverse of String \""+ text +"\" is: ");
            for (int i = text.Length - 1; i >= 0; i--) // I read through the positions of the variabe text from right to left and then I print the result
            {
                Console.Write(text[i]);
            }

        }
    }
}
