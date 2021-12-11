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
        private static User setUser;
        private static DataGrid setDataGrid;
        internal static User SetUser { get => setUser; set => setUser = value; }
        internal static DataGrid SetDataGrid { get => setDataGrid; set => setDataGrid = value; }

        public TabsWindow()//usuario00
        {
            DateTime ahora = DateTime.Now;

            InitializeComponent();
            lblUserName.Content = "Name: " + SetUser.name;
            lblDate.Content = "Date: " + ahora.ToString("F");

            User aux = new User();
            aux.readAll();
            dgrUsers.ItemsSource = aux.manage.list;
        }      

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NewUser.IsMod = false;
            User aux = new User();
            
            aux.readAll();

            //mostrar la ventana de nuevo user
            NewUser newUserWindow = new NewUser(this);
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

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            if (dgrUsers.SelectedItems.Count == 1)
            {
                NewUser.IsMod = true;
                NewUser.UserMod = (User)dgrUsers.SelectedItem;   
                //mostrar la ventana de nuevo user
                NewUser newUserWindow = new NewUser(this);               
                newUserWindow.Show();

            }
            else
            {
                MessageBox.Show("You must select only one row");
            }
        }
    }
}
