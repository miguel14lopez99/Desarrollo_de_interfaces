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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ejercicio_Barcos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Cell[,] board;
        private List<Barco> list;

        public MainWindow()
        {
            list = new List<Barco>();

            InitializeComponent();

            int N = 5; //dimension de la matriz
            int[] vector = { 2, 4, 1, 5 }; //barcos

            //se inicializa el tablero
            board = new Cell[N, N];

            InicialiceBoard();

            //para cada pos en vector se crea un barco
            for (int i = 0; i < vector.Length; i++)
            {
                Barco b = new Barco(randomCell(), vector[i], randomDirection());

                while (!barcoOK(b))
                {
                    b = new Barco(randomCell(), vector[i], randomDirection());
                }

                //cuando el barco esta ok asignamos sus celdas
                foreach (Cell cell in b.cells)
                {
                    cell.asigned = true;
                }

                //metemos el barco en una lista
                list.Add(b);

            }



        }

        public void InicialiceBoard()
        {
            int dim = board.GetLength(0);

            int i = 0;
            int j = 0;

            for (int k = 0; k < dim * dim; k++)
            {

                board[i, j] = new Cell(i, j);
                MessageBox.Show("Cell: " + i + j);

                if (j == dim - 1)
                {
                    i++;
                    j = 0;
                }
                else
                {
                    j++;
                }

            }

        }

        //coje una celda random del tablero
        private Cell randomCell()
        {
            Cell aux = board[RandomNumber.random_Number(0, board.GetLength(0)), RandomNumber.random_Number(0, board.GetLength(0))];
            return aux;
        }

        private int randomDirection()
        {
            int direction = RandomNumber.random_Number(0, 4);
            return direction;
        }

        private Boolean barcoOK(Barco b)
        {
            Boolean barcoOK = true;

            // cuando el barco se sale del tablero
            if (!inBoard(b.cells))
            {
                // cuando una cell ya está asignada
                if (celdaAsignada(b.cells))
                {
                    barcoOK = false;
                }
            }

            return barcoOK;
        }

        //recorre el array de celdas y cuando encuentra una asignada devuelve true
        private Boolean celdaAsignada(Cell[] cells)
        {
            Boolean asignada = false;

            int cont = 0;
            while (cont < cells.Length || asignada == false)
            {
                asignada = board[cells[cont].posX, cells[cont].posY].asigned;
                cont++;
            }

            return asignada;
        }

        //recorre el array de celdas y cuando una celda se sale del tablero devuelve false
        private Boolean inBoard(Cell[] cells)
        {
            Boolean dentro = true;

            int cont = 0;
            while (cont < cells.Length || dentro == true)
            {
                if (cells[cont].posX < 0 || cells[cont].posX > board.GetLength(0) ||
                    cells[cont].posY < 0 || cells[cont].posY > board.GetLength(0))
                {
                    dentro = false;
                }

                cont++;
            }

            return dentro;
        }

    }
    
}
