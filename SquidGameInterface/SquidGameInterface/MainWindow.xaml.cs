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

namespace SquidGameInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int DimA { get; set; }
        public static int DimB { get; set; }
        public static String figure { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            DimA = Convert.ToInt32(txtDimA.Text);
            DimB = Convert.ToInt32(txtDimB.Text);
            figure = lstFigures.SelectedItem.ToString();

            Board board = new Board();
            board.Show();
        }

        private void btnEnd_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
