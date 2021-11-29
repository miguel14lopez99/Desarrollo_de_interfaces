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
using System.Windows.Shapes;
using LITTLE_ERP.Domain;

namespace LITTLE_ERP
{
    /// <summary>
    /// Lógica de interacción para TabsWindow.xaml
    /// </summary>
    public partial class TabsWindow : Window
    {

        public TabsWindow()//usuario00
        {
            
            InitializeComponent();
            lblUserName.Content = "Name: " + user.name;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            User aux = new User();
            aux.readAll();

            //mostrar la ventana de nuevo user
            NewUser newUserWindow = new NewUser();
            newUserWindow.Show();

            dgrUsers.ItemsSource = aux.manage.list;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            List<User> data = new List<User>();
            int indice = 0;
            if (dgrUsers.SelectedItems.Count > 0)
            {
                data = (List<User>)dgrUsers.ItemsSource; // los obj del datagrid a la lista

                for (int i = 0; i < dgrUsers.SelectedItems.Count; i++)
                {
                    indice = dgrUsers.Items.IndexOf(dgrUsers.SelectedItems[i]);
                    data.RemoveAt(indice);
                    User row = (User)dgrUsers.SelectedItems[i];
                    row.delete();
                }
                dgrUsers.ItemsSource = null;
                dgrUsers.ItemsSource = data;
            }
            else
            {
                MessageBox.Show("You must select at least one row");
            }
        }
    }
}
