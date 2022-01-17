using System;

namespace Ejercicio_Matrices_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Me piden que ingrese unos datos a una matriz de dimensiones a elegir por el user e imprimirla

            //Introducir las dimensiones
            int filas, columnas;
            int[,] matriz;

            Console.WriteLine("Introduce las filas: ");
            filas = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Introduce las columnas: ");
            columnas = Convert.ToInt32(Console.ReadLine());

            //Ya tenemos las dimensiones, ahora hay que inicializar la matriz
            matriz = new int[filas, columnas];

            //Recorremos la matriz, usando un bucle
            int i = 0, j = 0, cont = 0;
            while (i < matriz.GetLength(0))
            {
                Console.Write("Posición: " + cont);
                Console.WriteLine("\nIntroduce la coord ["+i+","+j+"]: ");
                matriz[i, j] = Convert.ToInt32(Console.ReadLine());
                cont++;

                if (j == matriz.GetLength(1) - 1)
                {
                    i++;
                    j = 0;
                } else
                {
                    j++;
                }
            }

            //Mostramos la matriz usando el mismo tipo de bucle

            Console.WriteLine("\n---Matriz---\n");

            i = 0; j = 0; cont = 0;
            while (i < matriz.GetLength(0))
            {
                Console.Write(matriz[i, j]+" ");

                if (j == matriz.GetLength(1) - 1)
                {
                    Console.WriteLine();
                    i++;
                    j = 0;
                } else
                {
                    j++;
                }
            }


        }

    }
}
