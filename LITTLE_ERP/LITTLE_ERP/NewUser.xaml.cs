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
        private static User userMod;
        private static Boolean isMod;
        internal static User UserMod { get => userMod; set => userMod = value; }
        public static bool IsMod { get => isMod; set => isMod = value; }

        private List<Rol> allowed;
        private List<Rol> assigned;

        private TabsWindow tabsWindow = null;

        public NewUser(Window callingForm)
        {           
            InitializeComponent();

            tabsWindow = callingForm as TabsWindow;

            allowed = new List<Rol>();
            assigned = new List<Rol>();

            Rol aux = new Rol();
            aux.readAll();

            //recuperar los roles
            allowed = aux.manage.list;
            lstAllowedRoles.ItemsSource = allowed;

            if (isMod)
            {
                lblTitle.Content = "Modify User";
                txtPass.IsEnabled = false;
                txtRepPass.IsEnabled = false;

                //añadir nombre al txtName
                txtName.Text = userMod.name;

                //añadir los roles del usuario a su lista
                userMod.setRolList();

                //añadir los roles asignados y ponerlos a la lista
                assigned = userMod.rolesList;
                lstAssignedRoles.ItemsSource = assigned;

                //restar los roles asignados a los allowed           
                for (int i = 0; i < allowed.Count; i++)
                {
                    for (int j = 0; j < assigned.Count; j++)
                    {
                        if (allowed[i].Equals(assigned[j]))
                            allowed.Remove(allowed[i]);
                    }
                }
                lstAllowedRoles.ItemsSource = allowed;

            }

            //no mostrar cuando se abre la ventana
            lblError.Visibility = Visibility.Hidden;
            
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {

            User aux = new User();

            if (isMod)
            {
                //MODIFICAR USUARIO

                if (txtName.Text.Length != 0)
                {
                    aux = userMod;
                    String newName = txtName.Text;
                    aux.updateName(newName);

                    // se eliminan los roles que ya tenía
                    aux.deleteRoles();

                }
                else
                {
                    lblError.Content = "Debe rellenar todos los datos";
                    lblError.Visibility = Visibility.Visible;
                }
            }
            else
            {
                //AÑADIR USUARIO

                //verificamos si ha dejado algún campo en blanco

                if (txtName.Text.Length != 0 && txtPass.Password.Length != 0)
                {
                    //verificamos si ha introducido bien la contraseña

                    if (txtPass.Password.Equals(txtRepPass.Password))
                    {
                        if (lstAssignedRoles.Items.Count != 0)
                        {
                            // se inserta el usuario
                            aux.name = txtName.Text;
                            aux.password = SomeResources.Useful.getHashSha256(txtPass.Password);
                            aux.insert();

                        }

                    }
                    //verificamos si tiene al menos un rol asignado

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

            // se añaden los roles                        
            foreach (Rol rol in assigned)
            {
                aux.addRol(rol);
            }

            //actualizamos el data grid
            aux.readAll();
            this.tabsWindow.dgrUsers.ItemsSource = aux.manage.list;

            //cerrar la ventana cuando se crea el usuario
            this.Close();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAssign_Click(object sender, RoutedEventArgs e)
        {
            //añadir el rol selecionado a la lista de asignados
            if (lstAllowedRoles.SelectedItems.Count > 0)
            {
                //cuando tiene un rol selecionado
                Rol aux = (Rol)lstAllowedRoles.SelectedItem;
                //el rol lo añadimos a la lista de asignados
                assigned.Add(aux);
                allowed.Remove(aux);

                lstAssignedRoles.ItemsSource = null;
                lstAssignedRoles.ItemsSource = assigned;
                lstAllowedRoles.ItemsSource = null;
                lstAllowedRoles.ItemsSource = allowed;
            }
            else
            {
                MessageBox.Show("You must select at least one rol");
            }
        }

        private void btnDeny_Click(object sender, RoutedEventArgs e)
        {
            //quitamos el rol selecionado de la lista de asignados
            if (lstAssignedRoles.SelectedItems.Count > 0)
            {
                //cuando tiene un rol selecionado
                Rol aux = (Rol)lstAssignedRoles.SelectedItem;
                //el rol lo añadimos a la lista de asignados
                allowed.Add(aux);
                assigned.Remove(aux);

                lstAssignedRoles.ItemsSource = null;
                lstAssignedRoles.ItemsSource = assigned;
                lstAllowedRoles.ItemsSource = null;
                lstAllowedRoles.ItemsSource = allowed;
            }
            else
            {
                MessageBox.Show("You must select at least one rol");
            }

        }

    }

}
