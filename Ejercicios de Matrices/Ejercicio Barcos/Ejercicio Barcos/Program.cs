using System;

namespace Ejercicio_Barcos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inserta N: ");
            //dim
            int N = Convert.ToInt32(Console.ReadLine());

            //vector de los barcos
            int[] vectorB = { 1, 2, 5, 3 };

            //crear tablero
            char[,] tablero = new char[N,N];

            rellenarTablero(tablero);

            colocarBarcos(tablero, vectorB);

            mostrarTablero(tablero);

        }

        public static void colocarBarcos(char[,] tablero, int[] vectorB)
        {
            for (int i = 0; i < vectorB.Length; i++)
            {
                Barco b = new Barco(vectorB[i], tablero.GetLength(0)); //longitud y dim del tablero

                //comprobar si el barco se puede colocar
                while (!barcoOK(b,tablero))
                {
                    b = new Barco(vectorB[i], tablero.GetLength(0));
                }

                //colocar el barco en el tablero
                foreach (Celda celda in b.celdas)
                {
                    tablero[celda.posX, celda.posY] = 'B';
                }

            }

        }

        public static Boolean barcoOK(Barco b, char[,] tablero)
        {
            Boolean barcoOK = true;

            foreach (Celda celda in b.celdas)
            {
                if (tablero[celda.posX, celda.posY] == 'B')
                    barcoOK = false;
            }

            return barcoOK;
        }

        public static void rellenarTablero(char[,] tablero)
        {
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    tablero[i, j] = '_';
                }
            }
        }

        public static void mostrarTablero(char[,] tablero)
        {
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    Console.Write(tablero[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
