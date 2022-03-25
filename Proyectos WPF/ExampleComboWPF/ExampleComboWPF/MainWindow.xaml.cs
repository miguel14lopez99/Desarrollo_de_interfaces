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

namespace ExampleComboWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ComboItem> data = new List<ComboItem>();
        public MainWindow()
        {
            InitializeComponent();
            data.Add(new ComboItem() { id = 1, name = "Miguel", surname = "López" });
            data.Add(new ComboItem() { id = 2, name = "Andrés", surname = "Molina" });
            data.Add(new ComboItem() { id = 3, name = "Asier", surname = "Baos" });

            cboPeople.ItemsSource = data;

        }

        private void cboPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboItem selected = (ComboItem)e.AddedItems[0];
            MessageBox.Show("You have selected the id: " + selected.id.ToString());
        }
    }
}
