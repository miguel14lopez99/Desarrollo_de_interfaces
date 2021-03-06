using LITTLE_ERP.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LITTLE_ERP.SomeResources;

namespace LITTLE_ERP.Domain.Manage
{
    /// <summary>
    /// Class for manage user objects
    /// </summary>
    class UserManage
    {
        public List<User> list { get; set; }
        public List<User> selectedList { get; set; }

        /// <summary>
        /// Initializes all the lists of the <see cref="UserManage"/> class.
        /// </summary>
        public UserManage()
        {
            this.list = new List<User>();
            this.selectedList = new List<User>();
        }

        /// <summary>
        /// Reads all users from the database.
        /// </summary>
        public void ReadAll()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT idUser FROM users where deleted=0", "users"); //all users who are not deleted or aren't the root user are recovered

            DataTable table = data.Tables["users"];

            User aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new User(Convert.ToInt32(row["idUser"]));
                ReadUser(aux);
                if (aux.idUser != 1) //the program don't show root user
                    list.Add(aux);
           
            }
        }

        /// <summary>
        /// Reads a specific user from the database.
        /// </summary>
        /// <param name="user">The user.</param>
        public void ReadUser(User user) //Read a user through their id and assign their name
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT * FROM users where idUser=" + user.idUser, "users");

            DataTable table = data.Tables["users"];

            DataRow row = table.Rows[0];
            user.name = Convert.ToString(row["Name"]);
        }

        /// <summary>
        /// Adds to a list all users that meet a pattern.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        public void setSelectedList(string pattern)
        {
            selectedList.Clear();

            ReadAll();

            foreach (User user in list)
            {
                if (user.ToString().Contains(pattern))
                {
                    selectedList.Add(user);
                }
            }
        }

        /// <summary>
        /// Inserts the user in the database.
        /// </summary>
        /// <param name="user">The user.</param>
        public void InsertUser(User user)
        {
            ConnectOracle Search = new ConnectOracle();

            int maximun = Convert.ToInt32("0" + Search.DLookUp("max(idUser)", "users", "")) + 1;

            user.idUser = maximun;

            Search.setData("INSERT INTO users VALUES(" + user.idUser + ",'" + user.name + "','" + user.password + "',0)");
        }

        /// <summary>
        /// Checks if a user exists in the database.
        /// </summary>
        /// <param name="user">The user.</param>
        public Boolean CheckUser(User user) //Checks if a user, with name and password, exists in the database
        {
            Boolean found = false;

            ConnectOracle Search = new ConnectOracle();

            int count = Convert.ToInt32(Search.DLookUp("count(idUser)", "users", "name = '" + user.name + "' and password = '" + user.password + "'"));

            if (count != 0)
            {
                found = true;
            }

            return found;
        }

        /// <summary>
        /// Logically deletes the user from the database.
        /// </summary>
        /// <param name="user">The user.</param>
        public void DeleteUser(User user)
        {
            ConnectOracle Search = new ConnectOracle();

            Search.setData("Update users set deleted=1 where idUser = " + user.idUser);
        }

        /// <summary>
        /// Updates the user's name field from the database.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="newName">The new user name.</param>
        public void UpdateName(User user, String newName)
        {
            ConnectOracle Search = new ConnectOracle();

            Search.setData("Update users set name='"+newName+"' where idUser = " + user.idUser);
        }

        /// <summary>
        /// Updates the user's password field from the database.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="newPass">The new user password.</param>
        public void UpdatePass(User user, String newPass)
        {
            ConnectOracle Search = new ConnectOracle();

            Search.setData("Update users set password='" + SomeResources.Useful.getHashSha256(newPass) + "' where idUser = " + user.idUser);
        }

        /// <summary>
        /// Adds a rol to the user.
        /// </summary>
        /// <param name="rol">The rol.</param>
        /// <param name="user">The user.</param>
        public void addRol(Rol rol, User user) //Add a role to the user
        {
            ConnectOracle Search = new ConnectOracle();

            int maximun = Convert.ToInt32("0" + Search.DLookUp("max(IDUSER_ROL)", "users_roles", "")) + 1;

            Search.setData("INSERT INTO users_roles VALUES(" + maximun + ",'" + user.idUser + "','" + rol.idRol + "')");
        }

        /// <summary>
        /// Remove all roles from the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void deleteRoles(User user) //Remove all roles from the user
        {
            ConnectOracle Search = new ConnectOracle();

            Search.setData("DELETE FROM users_roles where idUser = "+user.idUser);
        }

        /// <summary>
        /// Retrieves the roles assigned to the user and sets them in the list of user roles.
        /// </summary>
        /// <param name="user">The user.</param>
        public void setRolList(User user) //Retrieves the roles assigned to the user and puts them in the list of user roles
        {
            DataSet data = new DataSet();

            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT idRol FROM users_roles where idUser="+user.idUser, "users_roles");

            DataTable table = data.Tables["users_roles"];

            Rol aux;

            user.rolesList = new List<Rol>();

            foreach (DataRow row in table.Rows)
            {
                aux = new Rol(Convert.ToInt32(row["idRol"]));
                aux.readRol();
                user.rolesList.Add(aux);
            }
        }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="password">The password.</param>
        public int getUserID(String name, String password) //Retrieve the user id through their name and password
        {
            ConnectOracle Search = new ConnectOracle();
            int userID = Convert.ToInt32(Search.DLookUp("idUser", "users", "name = '" + name + "' and password = '" + password+ "'"));
            return userID;
        }

        /// <summary>
        /// Sets the permissions to the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void setPermissions(User user) //Assign user permissions
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            List<Rol> roles = user.rolesList;

            foreach (Rol rol in roles) //Cycle through the list of user roles
            {
                data = Search.getData("SELECT IDPERMISSION FROM ROLES_PERMISSIONS where idRol=" + rol.idRol, "ROLES_PERMISSIONS");
                DataTable table = data.Tables["ROLES_PERMISSIONS"];

                foreach (DataRow row in table.Rows)
                {
                    int idPermission = Convert.ToInt32(row["IDPERMISSION"]);

                    switch (idPermission)
                    {
                        case 1:
                            user.userPermissions.addUser = true;
                            break;
                        case 2:
                            user.userPermissions.editUser = true;
                            break;
                        case 3:
                            user.userPermissions.showUser = true;
                            break;
                        case 4:
                            user.userPermissions.deleteUser = true;
                            break;
                        case 5:
                            user.userPermissions.usersAccess = true;
                            break;
                        case 6:
                            user.userPermissions.showCustomers = true;
                            break;
                        case 7:
                            user.userPermissions.showProducts = true;
                            break;
                        case 8:
                            user.userPermissions.accountInvoices = true;
                            break;
                        case 9:
                            user.userPermissions.showOrders = true;
                            break;
                        case 10:
                            user.userPermissions.showInvoices = true;
                            break;
                    }
                }
            }
        }
    }
}
