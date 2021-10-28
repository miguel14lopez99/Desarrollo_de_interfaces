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

namespace Controles2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnResolver_Click(object sender, RoutedEventArgs e)
        {
            double a = double.Parse(txtA.Text);
            double b = double.Parse(txtB.Text);
            double c = double.Parse(txtC.Text);

            double raizPositiva = (-b + Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a);
            double raizNegativa = (-b - Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a);

            if (raizNegativa.ToString() == "NaN" || raizPositiva.ToString() == "NaN")
            {
                txtX1.Text = "No hay raices reales";
            }
            else if (raizPositiva != raizNegativa)
            {
                txtX1.Text = raizNegativa.ToString();
                txtX2.Text = raizPositiva.ToString();
            }
            else
            {
                txtX1.Text = raizPositiva.ToString();
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtA.Text = "";
            txtB.Text = "";
            txtC.Text = "";
            txtX2.Text = "";
            txtX1.Text = "";
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
