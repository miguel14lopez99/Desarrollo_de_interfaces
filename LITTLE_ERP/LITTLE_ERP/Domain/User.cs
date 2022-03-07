using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    /// <summary>
    /// Class for create User objects
    /// </summary>
    class User
    {
        /// <summary>
        /// Class for create User's permissions objects
        /// </summary>
        public class UserPermissions
        {
            public Boolean addUser { get; set; }
            public Boolean editUser { get; set; }
            public Boolean showUser { get; set; }
            public Boolean deleteUser { get; set; }
            public Boolean usersAccess { get; set; }
            public Boolean showCustomers { get; set; }
            public Boolean showProducts { get; set; }
            public Boolean accountInvoices { get; set; }
            public Boolean showOrders { get; set; }
            public Boolean showInvoices { get; set; }
        }

        public int idUser { get; set; }
        public String name { get; set; }
        public String password { get; set; }
        public List<Rol> rolesList;
        public UserPermissions userPermissions;

        public Manage.UserManage manage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            manage = new Manage.UserManage();
            rolesList = new List<Rol>();
            userPermissions = new UserPermissions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="idUser">The user identifier.</param>
        public User(int idUser)
        {
            manage = new Manage.UserManage();
            rolesList = new List<Rol>();
            userPermissions = new UserPermissions();

            this.idUser = idUser;
            setRolList();
            setPermissions();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="name">The user name.</param>
        /// <param name="password">The user password.</param>
        public User(String name, String password)
        {
            manage = new Manage.UserManage();
            rolesList = new List<Rol>();
            userPermissions = new UserPermissions();

            this.name = name;
            this.password = password;
            this.idUser = getUserID(name, password);
            setRolList();
            setPermissions();
        }

        /// <summary>
        /// Insert the user in the database.
        /// </summary>
        public void insert()
        {
            manage.InsertUser(this);
        }

        /// <summary>
        /// Checks if a user exists in the database.
        /// </summary>
        /// <returns></returns>
        public Boolean check()
        {
            return manage.CheckUser(this);
        }

        /// <summary>
        /// Reads all users from the database.
        /// </summary>
        public void readAll()
        {
            manage.ReadAll();
        }

        /// <summary>
        /// Reads a specific user from the database.
        /// </summary>
        public void readUser()
        {
            manage.ReadUser(this);
        }

        /// <summary>
        /// Delete the user from the database.
        /// </summary>
        public void delete()
        {
            manage.DeleteUser(this);
        }

        /// <summary>
        /// Adds a rol to the user.
        /// </summary>
        /// <param name="rol">The rol.</param>
        public void addRol(Rol rol)
        {
            manage.addRol(rol, this);
        }

        /// <summary>
        /// Remove all roles from the user.
        /// </summary>
        public void deleteRoles()
        {
            manage.deleteRoles(this);
        }

        /// <summary>
        /// Retrieves the roles assigned to the user and sets them in the list of user roles.
        /// </summary>
        public void setRolList()
        {
            manage.setRolList(this);
        }

        /// <summary>
        /// Updates the name field of the user.
        /// </summary>
        /// <param name="name">The name.</param>
        public void updateName(String name) //Modify the username
        {
            manage.UpdateName(this, name);
        }

        /// <summary>
        /// Updates the password field of the user.
        /// </summary>
        /// <param name="pass">The pass.</param>
        public void updatePass(String pass) //Modify the password
        {
            manage.UpdatePass(this, pass);
        }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <param name="login">The user's name.</param>
        /// <param name="pass">The user's password.</param>
        /// <returns></returns>
        public int getUserID(String login, String pass) //Retrieve the user id through their name and password
        {
            return manage.getUserID(login, pass);
        }

        /// <summary>
        /// Sets the permissions to the user.
        /// </summary>
        public void setPermissions() //Assign user permissions
        {
            manage.setPermissions(this);
        }

        public override string ToString()
        {
            String rolesString = "";

            foreach (Rol rol in rolesList)
            {
                rolesString = rolesString + rol.ToString();
            }

            return idUser + name + rolesString;
        }
    }
}
