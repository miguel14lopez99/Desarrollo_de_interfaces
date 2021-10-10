using System;

namespace Ejercicio6
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 20; // the number of elements in the serie

            int[] array = new int[n]; // the array containing the elements of the serie

            array[0] = 1; // I introduce the first 3 elements of the serie
            array[1] = 1;
            array[2] = 2;

            for (int i = 3; i < array.Length; i++) // and then I start to calculate after the last number
            {
                array[i] = array[i - 1] + array[i - 2] + array[i - 3];
            }

            for (int i = 0; i < array.Length; i++) // this prints the serie
            {
                Console.Write(array[i] + " ");
            }
            
        }
    }
}
