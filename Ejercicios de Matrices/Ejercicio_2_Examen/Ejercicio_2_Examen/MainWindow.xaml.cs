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

namespace Ejercicio_2_Examen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lblError.Visibility = Visibility.Hidden;
        }

        private void btnGenerar_Click(object sender, RoutedEventArgs e)
        {
            grdTablero.RowDefinitions.Clear();
            grdTablero.ColumnDefinitions.Clear();
            grdTablero.Children.Clear();

            grdTablero.ShowGridLines = true;
            int filas = 10, columnas = 10;
            if (txtFilas.Text.Length != 0)
                filas = Convert.ToInt32(txtFilas.Text);
            if (txtColumnas.Text.Length != 0)
                columnas = Convert.ToInt32(txtColumnas.Text);

            //definir matriz con filas y columnas

            char[,] tablero = new char[filas, columnas];           

            for (int i = 0; i < filas; i++)
            {
                RowDefinition rowDef = new RowDefinition();
                grdTablero.RowDefinitions.Add(rowDef);
            }

            for (int i = 0; i < columnas; i++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                grdTablero.ColumnDefinitions.Add(colDef);
            }

            //elegir una pos random para las piezas

            int posFila = RandomNumber.random_Number(0, filas);
            int posCol = RandomNumber.random_Number(0, columnas);

            //crear un label, cambiar letra según pieza y mostrar en el grid
            char[] piezas = {'T','A','R','C'};
            int indice = lstPiezas.SelectedIndex;
            if (indice == -1)
            {
                lblError.Visibility = Visibility.Visible;
            }
            else
            {
                lblError.Visibility = Visibility.Hidden;

                //calcular los movimientos

                for (int i = 0; i < filas; i++)
                {
                    for (int j = 0; j < columnas; j++)
                    {
                        switch (indice)
                        {
                            case 1:
                                //moviento alfil
                                if (Math.Abs(posFila - i) == Math.Abs(posCol - j))
                                {
                                    tablero[i, j] = '*';
                                }
                                break;
                            case 0:
                                //movTorre();
                                if ((posFila == i) || (posCol == j))
                                {
                                    tablero[i, j] = '*';
                                }
                                break;
                            case 2:
                                //movReina();
                                if ((posFila == i) || (posCol == j) || Math.Abs(posFila - i) == Math.Abs(posCol - j))
                                {
                                    tablero[i, j] = '*';
                                }
                                break;
                            case 3:
                                //movCaballo();
                                if ((posFila - i) * (posFila - i) + (posCol - j) * (posCol - j) == 5)
                                {
                                    tablero[i, j] = '*';
                                }
                                break;
                        }
                    }
                }

                tablero[posFila, posCol] = piezas[indice];

                //mostrar el tablero

                for (int i = 0; i < filas; i++)
                {
                    for (int j = 0; j < columnas; j++)
                    {

                        Label lblPos = new Label();
                        lblPos.Content = tablero[i, j];
                        lblPos.FontSize = 15;
                        lblPos.HorizontalAlignment = HorizontalAlignment.Center;
                        lblPos.VerticalAlignment = VerticalAlignment.Center;
                        lblPos.FontWeight = FontWeights.Bold;
                        Grid.SetRow(lblPos, i);
                        Grid.SetColumn(lblPos, j);
                        grdTablero.Children.Add(lblPos);

                    }
                }
            }
          
        }
    }
}
