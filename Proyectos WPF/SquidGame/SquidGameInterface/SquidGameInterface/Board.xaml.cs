using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SquidGameInterface
{
    /// <summary>
    /// Lógica de interacción para Board.xaml
    /// </summary>
    public partial class Board : Window
    {
        RowDefinition rowDef1;
        ColumnDefinition colDef1;

        private static char[,] board;

        public Board()
        {
            InitializeComponent();

            MainWindow main = new MainWindow();

            int a = MainWindow.DimA;
            int b = MainWindow.DimB;
            String f = MainWindow.figure;

            board = new char[a, b];


            int posX = RandomNumber.random_Number(0, a);
            int posY = RandomNumber.random_Number(0, b);

            if (f.Equals("System.Windows.Controls.ListBoxItem: Bishop"))
            {
                BishopAttacks(posX, posY);
            }
            if (f.Equals("System.Windows.Controls.ListBoxItem: Tower"))
            {
                TowerAttacks(posX, posY);
            }
            if (f.Equals("System.Windows.Controls.ListBoxItem: Queen"))
            {
                QueenAttacks(posX, posY);
            }
            if (f.Equals("System.Windows.Controls.ListBoxItem: Horse"))
            {
                HorseAttacks(posX, posY);
            }

            showGrid(grdBoard);

        }

        public static void showGrid(Grid grid)
        {
            

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j].Equals('*'))
                    {
                        Label label = new Label();
                        label.Content = '*';
                        //añado el elemento al grid
                    }

                    

                }
            }

        }

        public static void BishopAttacks(int x, int y)
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

            board[x, y] = 'B';

        }

        public static void TowerAttacks(int x, int y)
        {

            int cont = 0;
            int posY = y;
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

        }


    }
}
