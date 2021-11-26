using System;

namespace SquidGameConsole
{
    class Program
    {

        private static char[,] board;

        static void Main(string[] args)
        {

            //insert A and B dimensions

            Console.WriteLine("Insert A dimension: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Insert B dimension: ");
            int b = Convert.ToInt32(Console.ReadLine());

            //create de board

            board = new char[a, b];

            initBoard();

            //random position for the figure

            int posX = RandomNumber.random_Number(0, a);
            int posY = RandomNumber.random_Number(0, b);

            //choose a figure

            Console.WriteLine("Choose a figure: " +
                "\n1. Bishop" +
                "\n2. Tower" +
                "\n3. Queen" +
                "\n4. Horse");

            Console.WriteLine("Insert your option: ");
            int opt = Convert.ToInt32(Console.ReadLine());

            while(opt < 1 || opt > 4)
            {
                Console.WriteLine("Insert your option: ");
                opt = Convert.ToInt32(Console.ReadLine());
            }

            switch (opt)
            {
                case 1:
                    //bishop opt
                    board[posX, posY] = 'B';
                    BishopAttacks(posX, posY);
                    break;
                case 2:
                    //tower opt
                    board[posX, posY] = 'T';
                    TowerAttacks(posX, posY);
                    break;
                case 3:
                    //queen opt
                    board[posX, posY] = 'Q';
                    QueenAttacks(posX, posY);
                    break;
                case 4:
                    //horse opt
                    board[posX, posY] = 'H';
                    HorseAttacks(posX, posY);
                    break;
            }

        }

        public static void initBoard()
        {

            int dimA = board.GetLength(0);
            int dimB = board.GetLength(1);

            for (int i = 0; i < dimA; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < dimB; j++)
                {
                    board[i, j] = '_';
                    Console.Write(board[i, j] + " | ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void showBoard()
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

        public static void BishopAttacks(int x, int y)
        {
            int cont = 0;
            int posX = x;
            int posY = y;
            while (posY < board.GetLength(0) - 1 && posX < board.GetLength(1) - 1)
            {
                board[x+cont, y+cont] = '*';
                posY = y + cont;
                posX = x + cont;
                cont++;
            }

            cont = 0;
            posX = x;
            posY = y;
            while (posY > 0 && posX > 0)
            {
                board[x - cont, y - cont] = '*';
                posY = y - cont;
                posX = x - cont;
                cont++;
            }

            cont = 0;
            posX = x;
            posY = y;
            while (posX > 0 && posY < board.GetLength(0))
            {
                board[x - cont, y + cont] = '*';
                posY = y + cont;
                posX = x - cont;
                cont++;
            }

            cont = 0;
            posX = x;
            posY = y;
            while (posY > 0 && posX < board.GetLength(0))
            {
                board[x + cont, y - cont] = '*';
                posY = y - cont;
                posX = x + cont;
                cont++;
            }

            board[x, y] = 'B';

            showBoard();
        }

        public static void TowerAttacks(int x, int y)
        {

            int cont = 0;
            int posY = y;
            while (posY < board.GetLength(0)-1)
            {
                board[x, y+cont] = '*';
                posY = cont + y;
                cont++;
            }

            cont = 0;
            posY = y;
            while (posY > 0)
            {
                board[x, y+cont] = '*';
                posY = cont + y;
                cont--;
            }

            cont = 0;
            int posX = x;
            while (posX > 0)
            {
                board[x + cont, y] = '*';
                posX = x + cont;
                cont--;
            }

            cont = 0;
            posX = x;
            while (posX < board.GetLength(1) - 1)
            {
                board[x + cont, y] = '*';
                posX = x + cont; ;
                cont++;
            }

            board[x, y] = 'T';

            showBoard();
        }

        public static void QueenAttacks(int x, int y)
        {
            int cont = 0;
            int posX = x;
            int posY = y;
            while (posY < board.GetLength(0) - 1 && posX < board.GetLength(1) - 1)
            {
                board[x + cont, y + cont] = '*';
                posY = y + cont;
                posX = x + cont;
                cont++;
            }

            cont = 0;
            posX = x;
            posY = y;
            while (posY > 0 && posX > 0)
            {
                board[x - cont, y - cont] = '*';
                posY = y - cont;
                posX = x - cont;
                cont++;
            }

            cont = 0;
            posX = x;
            posY = y;
            while (posX > 0 && posY < board.GetLength(0))
            {
                board[x - cont, y + cont] = '*';
                posY = y + cont;
                posX = x - cont;
                cont++;
            }

            cont = 0;
            posX = x;
            posY = y;
            while (posY > 0 && posX < board.GetLength(0))
            {
                board[x + cont, y - cont] = '*';
                posY = y - cont;
                posX = x + cont;
                cont++;
            }

            cont = 0;
            posY = y;
            while (posY < board.GetLength(0) - 1)
            {
                board[x, y + cont] = '*';
                posY = cont + y;
                cont++;
            }

            cont = 0;
            posY = y;
            while (posY > 0)
            {
                board[x, y + cont] = '*';
                posY = cont + y;
                cont--;
            }

            cont = 0;
            posX = x;
            while (posX > 0)
            {
                board[x + cont, y] = '*';
                posX = x + cont;
                cont--;
            }

            cont = 0;
            posX = x;
            while (posX < board.GetLength(1) - 1)
            {
                board[x + cont, y] = '*';
                posX = x + cont; ;
                cont++;
            }

            board[x, y] = 'Q';

            showBoard();

        }

        public static void HorseAttacks(int x, int y)
        {
            board[x - 1, y - 2] = '*'; 
            board[x - 1, y + 2] = '*';
            board[x + 1, y - 2] = '*'; 
            board[x + 1, y + 2] = '*'; 
            board[x - 2, y - 1] = '*';
            board[x - 2, y + 1] = '*';
            board[x + 2, y - 1] = '*';
            board[x + 2, y + 1] = '*';

            board[x, y] = 'H';

            showBoard();
        }

    }
}
