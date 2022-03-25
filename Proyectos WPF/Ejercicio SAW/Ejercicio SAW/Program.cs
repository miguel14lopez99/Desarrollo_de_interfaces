using System;

namespace Ejercicio_SAW
{
    class Program
    {
        static void Main(string[] args)
        {
            //pedir los datos
            Console.WriteLine("Introduce el numero de personas: ");
            int N = Convert.ToInt32(Console.ReadLine());

            int[] vector = { 1,4,6,8 };

            //crear la matriz de enteros
            int[,] tabla = new int[vector.Length, N];

            

            //calcular datos de la tabla
            calcularTabla(tabla, vector);

            //mostrar tabla
            mostrarMatriz(tabla);
        }

        public static void mostrarMatriz(int[,] tabla)
        {
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    Console.Write(tabla[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void calcularTabla(int[,] tabla, int[] vector)
        {
            for (int i = 0; i < vector.Length; i++) //DEVICES
            {
                for (int j = 1; j <= tabla.GetLength(1); j++) //PEOPLE de 1 a 10
                {
                    //calcular dispositivos por personas
                    int devices = (int)j / vector[i];
                    if((j % vector[i]) != 0)
                        devices++;

                    tabla[i, j-1] = devices;
                }
            }
        }
    }
}
