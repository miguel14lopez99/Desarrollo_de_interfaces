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
        private static User setUser;
        private static User userMod;
        private static Boolean isMod;
        internal static User SetUser { get => setUser; set => setUser = value; }
        internal static User UserMod { get => userMod; set => userMod = value; }
        public static bool IsMod { get => isMod; set => isMod = value; }

        private List<Rol> allowed;
        private List<Rol> assigned;

        private TabsWindow tabsWindow = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewUser"/> class.
        /// 
        /// Initializes the form to create or modify users
        /// </summary>
        /// <param name="callingForm">The calling form.</param>
        public NewUser(Window callingForm)
        {           
            InitializeComponent();
            lblError.Visibility = Visibility.Hidden;

            tabsWindow = callingForm as TabsWindow;

            allowed = new List<Rol>();
            assigned = new List<Rol>();

            Rol aux = new Rol();
            aux.readAll();

            //retrieve the roles
            allowed = aux.manage.list;
            lstAllowedRoles.ItemsSource = allowed;

            //if the user is admin, we remove the admin option            
            for (int i = 0; i < setUser.rolesList.Count; i++)
            {
                if (setUser.rolesList[i].description.Equals("admin"))
                {
                    for (int j = 0; j < allowed.Count; j++)
                    {
                        if (allowed[j].description.Equals("admin"))
                            allowed.Remove(allowed[j]);
                    }
                }
            }
            lstAllowedRoles.ItemsSource = allowed;

            //if you click on the Modify button the window changes
            if (isMod)
            {
                lblTitle.Content = "Modify User";
                txtPass.IsEnabled = false;
                txtRepPass.IsEnabled = false;

                //add name to txtName
                txtName.Text = userMod.name;

                //add user roles to the list
                userMod.setRolList();

                //add assigned roles and put them into the list
                assigned = userMod.rolesList;
                lstAssignedRoles.ItemsSource = assigned;

                //subtract assigned roles from allowed          
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

        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// 
        /// Save the user in the users datagrid
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {

            User aux = new User();

            if (isMod)
            {
                //MODIFY USER

                if (txtName.Text.Length != 0)
                {
                    aux = userMod;
                    String newName = txtName.Text;
                    aux.updateName(newName);

                    //the roles that user already had are eliminated
                    aux.deleteRoles();

                    //the roles are added                       
                    foreach (Rol rol in assigned)
                    {
                        aux.addRol(rol);
                    }

                    //close the window when the user is modified
                    this.Close();
                }
                else
                {
                    lblError.Content = "Debe rellenar todos los datos";
                    lblError.Visibility = Visibility.Visible;
                }
            }
            else
            {
                //ADD USER

                //check if you have left any blank fields
                if (txtName.Text.Length != 0 && txtPass.Password.Length != 0)
                {
                    //check if you have entered the password correctly
                    if (txtPass.Password.Equals(txtRepPass.Password))
                    {
                        //check if you have assigned at least one role
                        if (lstAssignedRoles.Items.Count != 0)
                        {
                            //user is inserted
                            aux.name = txtName.Text;
                            aux.password = SomeResources.Useful.getHashSha256(txtPass.Password);
                            aux.insert();

                            //the roles are added                      
                            foreach (Rol rol in assigned)
                            {
                                aux.addRol(rol);
                            }

                            //close the window when the user is created
                            this.Close();
                        }
                        else
                        {
                            lblError.Content = "You must add at least one role";
                            lblError.Visibility = Visibility.Visible;
                        }
                    }                   
                    else
                    {
                        lblError.Content = "The password doesn't match";
                        lblError.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    lblError.Content = "You must fill all the data";
                    lblError.Visibility = Visibility.Visible;
                }

            }

            //update the data grid
            aux.readAll();
            this.tabsWindow.dgrUsers.ItemsSource = aux.manage.list;

        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnAssign control.
        /// 
        /// Assign a role to the user
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnAssign_Click(object sender, RoutedEventArgs e)
        {
            //add the selected role to the assigned list and remove from the allowed list
            if (lstAllowedRoles.SelectedItems.Count > 0)
            {
                Rol aux = (Rol)lstAllowedRoles.SelectedItem;
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

        /// <summary>
        /// Handles the Click event of the btnDeny control.
        /// 
        /// Deny a role to the user
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnDeny_Click(object sender, RoutedEventArgs e)
        {
            //remove the selected role from the assigned list and add to the allowed list
            if (lstAssignedRoles.SelectedItems.Count > 0)
            {
                Rol aux = (Rol)lstAssignedRoles.SelectedItem;
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
