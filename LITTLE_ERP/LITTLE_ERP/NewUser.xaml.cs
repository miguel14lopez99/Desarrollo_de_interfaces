using LITTLE_ERP.Domain;
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

namespace LITTLE_ERP
{
    /// <summary>
    /// Lógica de interacción para NewUser.xaml
    /// </summary>
    public partial class NewUser : Window
    {
        public NewUser()
        {
            Rol aux = new Rol();
            aux.readAll();

            InitializeComponent();

            //no mostrar cuando se abre la ventana
            lblError.Visibility = Visibility.Hidden;

            //recuperar los roles
            lstAllowedRoles.ItemsSource = aux.manage.list;
        }

        private TabsWindow tabsWindow = null;
        public NewUser(Window callingForm)
        {
            Rol aux = new Rol();
            aux.readAll();

            tabsWindow = callingForm as TabsWindow;
            InitializeComponent();

            //no mostrar cuando se abre la ventana
            lblError.Visibility = Visibility.Hidden;

            //recuperar los roles
            lstAllowedRoles.ItemsSource = aux.manage.list;
            
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Resources.useful useful = new Resources.useful();

            //verificamos si ha dejado algún campo en blanco

            if(txtName.Text.Length != 0 && txtPass.Password.Length != 0)
            {
                //verificamos si ha introducido bien la contraseña

                User aux = new User();

                if (txtPass.Password.Equals(txtRepPass.Password))
                {
                    
                    aux.name = txtName.Text;

                    aux.password = useful.getHashSha256(txtPass.Password);

                    aux.insert();
                    //actualizamos el data grid
                    aux.readAll();
                    this.tabsWindow.dgrUsers.ItemsSource = aux.manage.list;

                    //cerrar la ventana cuando se crea el usuario
                    this.Close();
                }
                else
                {
                    lblError.Content = "La contraseña no coincide";
                    lblError.Visibility = Visibility.Visible;
                }

            } 
            else
            {
                lblError.Content = "Debe rellenar todos los datos";
                lblError.Visibility = Visibility.Visible;
            }

            

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAssign_Click(object sender, RoutedEventArgs e)
        {
            List<Rol> data = new List<Rol>();
            int indice = 0;

            if (lstAllowedRoles.SelectedItems.Count > 0)
            {
                data = (List<Rol>)lstAllowedRoles.ItemsSource; // los obj del datagrid a la lista

                for (int i = 0; i < lstAllowedRoles.SelectedItems.Count; i++)
                {
                    indice = lstAllowedRoles.Items.IndexOf(lstAllowedRoles.SelectedItems[i]);
                    //meter roles en la listbox de asignados
                    lstAssignedRoles.Items.Add(data[i]);
                    //quitar rol de la lista de allowed
                    data.RemoveAt(indice);
                }
                lstAllowedRoles.ItemsSource = null;
                lstAllowedRoles.ItemsSource = data;
            }
            else
            {
                MessageBox.Show("You must select at least one row");
            }

        }

        private void btnDeny_Click(object sender, RoutedEventArgs e)
        {
            List<Rol> data = new List<Rol>();
            int indice = 0;

            if (lstAssignedRoles.SelectedItems.Count > 0)
            {
                data = (List<Rol>)lstAssignedRoles.ItemsSource; // los obj del datagrid a la lista

                for (int i = 0; i < lstAssignedRoles.SelectedItems.Count; i++)
                {
                    indice = lstAssignedRoles.Items.IndexOf(lstAssignedRoles.SelectedItems[i]);
                    //meter roles en la listbox de allowed
                    lstAllowedRoles.Items.Add(data[i]);
                    //quitar rol de la lista de deny
                    data.RemoveAt(indice);
                }
                lstAssignedRoles.ItemsSource = null;
                lstAssignedRoles.ItemsSource = data;
            }
            else
            {
                MessageBox.Show("You must select at least one row");
            }
        }
    }
}
