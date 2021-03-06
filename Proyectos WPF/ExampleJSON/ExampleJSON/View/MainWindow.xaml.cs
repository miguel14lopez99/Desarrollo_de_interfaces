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

using Avalonia;
//using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

using ExampleJSON.Domain;

namespace ExampleJSON
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AvaloniaXamlLoader.Load(this);
            try
            {
                People aux = new People();
                aux.ReadAll();
                lstPeople.ItemsSource = aux.manage.list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

   
    }
}
