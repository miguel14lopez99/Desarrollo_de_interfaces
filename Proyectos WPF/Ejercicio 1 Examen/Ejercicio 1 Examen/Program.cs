using System;

namespace Ejercicio_1_Examen
{
    class Program
    {
        static void Main(string[] args)
        {

            //Basica mente es un ejercicio en el que tienes un tablero de caracteres donde se le pedira
            //al usuario las dimensiones del tablero y la pieza que va a mover

            // dimensiones del tablero

            Console.WriteLine("INSERTA LAS FILAS: ");
            int filas = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("INSERTA LAS COLUMNAS: ");
            int columnas = Convert.ToInt32(Console.ReadLine());

            char[,] tablero = new char[filas,columnas];
            rellenarTablero(tablero);

            // calcular posicion de la pieza
            int posFila = RandomNumber.random_Number(0, filas);
            int posCol = RandomNumber.random_Number(0, columnas);

            //pedir una pieza al usuario con un menú
            Console.WriteLine("Elige una pieza: " +
                "\n1.Alfil" +
                "\n2.Torre" +
                "\n3.Reina" +
                "\n4.Caballo");

            int opt = Convert.ToInt32(Console.ReadLine());
            while(opt < 1 || opt > 4)
            {
                Console.WriteLine("Error. Elige una opción entre 1 y 4");
                opt = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    switch (opt)
                    {
                        case 1:
                            //moviento alfil
                            if (Math.Abs(posFila - i) == Math.Abs(posCol - j))
                            {
                                tablero[i, j] = '*';
                            }
                            break;
                        case 2:
                            //movTorre();
                            if ((posFila == i) || (posCol == j))
                            {
                                tablero[i, j] = '*';
                            }
                            break;
                        case 3:
                            //movReina();
                            if ((posFila == i) || (posCol == j) || Math.Abs(posFila - i) == Math.Abs(posCol - j))
                            {
                                tablero[i, j] = '*';
                            }
                            break;
                        case 4:
                            //movCaballo();
                            if ((posFila - i) * (posFila - i) + (posCol - j) * (posCol - j) == 5)
                            {
                                tablero[i, j] = '*';
                            }
                            break;
                    }
                }
            }

            char[] fichas = { 'A', 'T', 'R', 'C' };
            tablero[posFila, posCol] = fichas[opt-1];

            mostrarTablero(tablero);


        }

        public static void rellenarTablero(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = '_';
                }
            }
        }

        public static void mostrarTablero(char[,] board)
        {

            int dimA = board.GetLength(0);
            int dimB = board.GetLength(1);

            for (int i = 0; i < dimA; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < dimB; j++)
                {
                    Console.Write(board[i, j] + " | ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }

    
}
