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

namespace Ejercicio_Barcos2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            grdTablero.ShowGridLines =  true;
        }

        private void btnGenerar_Click(object sender, RoutedEventArgs e)
        {
            grdTablero.RowDefinitions.Clear();
            grdTablero.ColumnDefinitions.Clear();
            grdTablero.Children.Clear();

            //dim
            int N = Convert.ToInt32(txtDim.Text);

            //vector de los barcos
            int[] vectorB = { 1, 2, 5, 3 };

            //crear tablero
            char[,] tablero = new char[N, N];

            for (int i = 0; i < N; i++)
            {
                RowDefinition rd = new RowDefinition();
                grdTablero.RowDefinitions.Add(rd);

                ColumnDefinition cd = new ColumnDefinition();
                grdTablero.ColumnDefinitions.Add(cd);
            }

            colocarBarcos(tablero, vectorB, grdTablero);

        }

        private static void colocarBarcos(char[,] tablero, int[] vectorB, Grid grdtablero)
        {
            for (int i = 0; i < vectorB.Length; i++)
            {
                Barco b = new Barco(vectorB[i], tablero.GetLength(0)); //longitud y dim del tablero

                //comprobar si el barco se puede colocar
                while (!barcoOK(b, tablero))
                {
                    b = new Barco(vectorB[i], tablero.GetLength(0));
                }

                //colocar el barco en el tablero
                foreach (Celda celda in b.celdas)
                {
                    tablero[celda.posX, celda.posY] = 'B';

                    TextBlock tb = new TextBlock();
                    tb.Text = "B";
                    tb.FontWeight = FontWeights.Bold;
                    tb.TextAlignment = TextAlignment.Center;
                    Grid.SetRow(tb, celda.posX);
                    Grid.SetColumn(tb, celda.posY);
                    grdtablero.Children.Add(tb);

                }

            }

        }

        private static Boolean barcoOK(Barco b, char[,] tablero)
        {
            Boolean barcoOK = true;

            foreach (Celda celda in b.celdas)
            {
                if (tablero[celda.posX, celda.posY] == 'B')
                    barcoOK = false;
            }

            return barcoOK;
        }
    }

    
}
