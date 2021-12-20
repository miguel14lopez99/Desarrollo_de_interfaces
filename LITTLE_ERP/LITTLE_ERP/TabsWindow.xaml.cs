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

        public TabsWindow()
        {
            DateTime ahora = DateTime.Now;

            InitializeComponent();
            //set the connected user name and time
            lblUserName.Content = "Name: " + SetUser.name;
            lblDate.Content = "Date: " + ahora.ToString("G");
            lblUsername.Content = SetUser.name;

            //the use of the application is restricted to different users
            if (setUser.idUser != 1) //root
            {
                if (!setUser.userPermissions.usersAccess)
                {
                    tabUsers.Visibility = Visibility.Hidden;

                    if (!setUser.userPermissions.addUser)
                        btnAdd.IsEnabled = false;
                    if (!setUser.userPermissions.deleteUser)
                        btnDelete.IsEnabled = false;
                    if (!setUser.userPermissions.editUser)
                        btnModify.IsEnabled = false;
                    
                }
            }
            if (setUser.userPermissions.showUser || setUser.idUser == 1)
            {
                User aux = new User();
                aux.readAll();
                dgrUsers.ItemsSource = aux.manage.list;
            }

            //update roles
            String sRoles = "";

            foreach (Rol rol in setUser.rolesList)
            {
                sRoles += rol.description + "\n";
            }
            LblRoles.Content = sRoles;
            
        }      

        ///
        /// USERS
        ///

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NewUser.SetUser = setUser;
            NewUser.IsMod = false;
            User aux = new User();

            aux.readAll();

            //show the new user window
            NewUser newUserWindow = new NewUser(this);
            newUserWindow.Show();

            //update the user list
            dgrUsers.ItemsSource = aux.manage.list;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {          
            List<User> data = new List<User>();
            int indice = 0;
            if (dgrUsers.SelectedItems.Count > 0)
            {
                data = (List<User>)dgrUsers.ItemsSource;

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
                NewUser.SetUser = setUser;
                NewUser.IsMod = true;
                NewUser.UserMod = (User)dgrUsers.SelectedItem;
                //show new user window with changes
                NewUser newUserWindow = new NewUser(this);
                newUserWindow.Show();

            }
            else
            {
                MessageBox.Show("You must select only one row");
            }
        }

        ///
        /// PROFILE
        ///

        private void btnChangePwd_Click(object sender, RoutedEventArgs e)
        {
            //check if the previous password is the same as the user password
            if (!SomeResources.Useful.getHashSha256(pwdPrevious.Password).Equals(setUser.password))
            {
                MessageBox.Show("The previous password is incorrect");
            }
            //check if the new password matches
            else if (!pwdNew.Password.Equals(pwdRepeat.Password))
            {
                MessageBox.Show("The new password must match");
            }
            else
            {
                setUser.updatePass(pwdNew.Password);
                MessageBox.Show("Password Changed");
                pwdPrevious.Password = "";
                pwdNew.Password = "";
                pwdRepeat.Password = "";
            }      
        }

    }
}
