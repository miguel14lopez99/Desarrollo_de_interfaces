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

namespace BuscaminasWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private char[,] tablero;
        private int score;

        public MainWindow()
        {
            InitializeComponent();
            grdBoard.ShowGridLines = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Limpiamos el score
            score = 0;
            txtScore.Text = "Score: " + score;

            //LIMPIAR EL GRID

            grdBoard.RowDefinitions.Clear();
            grdBoard.ColumnDefinitions.Clear();
            grdBoard.Children.Clear(); 

            //CREAR EL GRID y tablero de chars

            int filas = Convert.ToInt32(txtFilas.Text);
            int cols = Convert.ToInt32(txtCols.Text);

            tablero = new char[filas,cols];

            //RELLENAR TABLERO 

            for (int i = 0; i < filas; i++)
            {
                RowDefinition rd = new RowDefinition();
                grdBoard.RowDefinitions.Add(rd);
            }

            for (int i = 0; i < cols; i++)
            {
                ColumnDefinition cd = new ColumnDefinition();
                grdBoard.ColumnDefinitions.Add(cd);
            }

            grdBoard.IsEnabled = true;

            //POBLAR EL GRID

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Boolean colocarMina = SomeResources.RandomNumber.random_Number(0, 3) == 1;
                    if (colocarMina)
                    {
                        //CREAMOS EL OBJETO MINA
                        TextBlock mina = new TextBlock();
                        mina.Text = "*";
                        mina.HorizontalAlignment = HorizontalAlignment.Center;
                        mina.VerticalAlignment = VerticalAlignment.Center;
                        mina.FontWeight = FontWeights.Bold;                      

                        Grid.SetRow(mina, i);
                        Grid.SetColumn(mina, j);
                        grdBoard.Children.Add(mina);

                        tablero[i, j] = '*';
                        
                    }

                    //CREAMOS OBJETO BOTON PARA OCULTAR LA MINA
                    Button bloque = new Button();
                    bloque.Content = "?";
                    bloque.Tag = i + ";" + j;
                    bloque.HorizontalAlignment = HorizontalAlignment.Stretch;
                    bloque.VerticalAlignment = VerticalAlignment.Stretch;
                    bloque.Click += new RoutedEventHandler(Click_bloque);

                    Grid.SetRow(bloque, i);
                    Grid.SetColumn(bloque, j);
                    grdBoard.Children.Add(bloque);
                }
            }


            
        }

        private void Click_bloque (object sender, RoutedEventArgs e)
        {
            Button bloque = (Button)sender;
            bloque.Visibility = Visibility.Hidden;
            String ruta = bloque.Tag.ToString();
            String[] coords_string = ruta.Split(';');
            int fila = Convert.ToInt32(coords_string[0]);
            int col = Convert.ToInt32(coords_string[1]);
            if(tablero[fila,col] != '*')
            {
                score++;
                txtScore.Text = "Score: " + score;

                //Despejar las celdas adyacentes que no tengan minas
            }
            else
            {
                MessageBox.Show("GAME OVER\n Score: " + score);
                grdBoard.IsEnabled = false;
                //nueva ventana que deje poner nombre, muestre lista con los mejores jugadores

                View.Scores scores = new View.Scores(score);
                scores.Show();
            }
        }
    }
}
