using System;
using System.Collections.Generic;
using System.Data;
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
using ExampleCrystalReports.Domain;
using ExampleCrystalReports.View;

namespace ExampleCrystalReports
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
            Client aux = new Client();
            aux.ReadAll();

            //Carga los valores en el reporte
            CrystalReport1 mireporte = new CrystalReport1();
            //ESTO FUNCIONA PORQUE TODO LO QUE TIENE LA TABLA SON STRING, si no habría que tratar los datos
            mireporte.Database.Tables["Customers"].SetDataSource(aux.manage.tCustomers /*aux.MakeReport()*/); 
            CR1.ViewerCore.ReportSource = mireporte;

        }
    }
}
