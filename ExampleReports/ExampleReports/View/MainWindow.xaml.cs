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
using System.Data;
using ExampleReports.Domain;
using ExampleReports.View;

namespace ExampleReports
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Client c = new Client();
            c.readAll();            
           
            // Load the values in the Report
            CrystalReport1 miReporte = new CrystalReport1();
            miReporte.Database.Tables["Customers"].SetDataSource(c.manage.tcustomers);
            Cr1.ViewerCore.ReportSource = miReporte;
        }
    }
}
