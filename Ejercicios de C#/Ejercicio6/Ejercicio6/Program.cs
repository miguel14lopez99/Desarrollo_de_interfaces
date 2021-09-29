using System;

namespace Ejercicio6
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 20;

            int[] array = new int[n];

            array[0] = 1;
            array[1] = 1;
            array[2] = 2;

            for (int i = 3; i < array.Length; i++)
            {
                array[i] = array[i - 1] + array[i - 2] + array[i - 3];
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            
        }
    }
}
