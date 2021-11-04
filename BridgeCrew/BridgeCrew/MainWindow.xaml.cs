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

namespace BridgeCrew
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Man hombre = new Man(1,InterfaceBridge.Graduation.Army_General, "Capitan", InterfaceBridge.Planet.Earth);
            Vulcan noHombre = new Vulcan(1, InterfaceBridge.Graduation.Army_General, "UnTioRaro", true);

            txtNombre.Text = noHombre.Name;

            Console.WriteLine(hombre.Name);
        }
    }
}
