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

namespace Ejercicio_SAW2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            grdTabla.ShowGridLines = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            grdTabla.RowDefinitions.Clear();
            grdTabla.ColumnDefinitions.Clear();
            grdTabla.Children.Clear();

            //pedir los datos
            int N = Convert.ToInt32(txtPers.Text);

            int[] vector = { 1, 4, 6, 8 };

            //crear la matriz de enteros
            int[,] tabla = new int[vector.Length, N];

            for (int i = 0; i < vector.Length; i++)
            {
                RowDefinition rd = new RowDefinition();
                grdTabla.RowDefinitions.Add(rd);
            }

            for (int j = 0; j < N; j++)
            {
                ColumnDefinition cd = new ColumnDefinition();
                grdTabla.ColumnDefinitions.Add(cd);
            }

            calcularTabla(tabla, vector, grdTabla);
        }

        public static void calcularTabla(int[,] tabla, int[] vector, Grid grdTabla)
        {
            for (int i = 0; i < vector.Length; i++) //DEVICES
            {
                for (int j = 1; j <= tabla.GetLength(1); j++) //PEOPLE de 1 a 10
                {
                    //calcular dispositivos por personas
                    int devices = (int)j / vector[i];
                    if ((j % vector[i]) != 0)
                        devices++;

                    tabla[i, j - 1] = devices;

                    TextBlock tb = new TextBlock();
                    tb.Text = devices.ToString();
                    tb.FontWeight = FontWeights.Bold;
                    tb.TextAlignment = TextAlignment.Center;
                    Grid.SetRow(tb, i);
                    Grid.SetColumn(tb, j - 1);
                    grdTabla.Children.Add(tb);
                }
            }
        }
    }
}
