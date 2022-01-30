using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    class User
    {
        public class UserPermissions
        {
            public Boolean addUser { get; set; }
            public Boolean editUser { get; set; }
            public Boolean showUser { get; set; }
            public Boolean deleteUser { get; set; }
            public Boolean usersAccess { get; set; }
            public Boolean showCustomers { get; set; }
            public Boolean showProducts { get; set; }

        }

        public int idUser { get; set; }
        public String name { get; set; }
        public String password { get; set; }
        public List<Rol> rolesList;
        public UserPermissions userPermissions;

        public Manage.UserManage manage { get; set; }

        public User()
        {
            manage = new Manage.UserManage();
            rolesList = new List<Rol>();
            userPermissions = new UserPermissions();
        }

        public User(int idUser)
        {
            manage = new Manage.UserManage();
            rolesList = new List<Rol>();
            userPermissions = new UserPermissions();

            this.idUser = idUser;
            setRolList();
            setPermissions();
        }

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

        public void insert() //Insert a user in the database
        {
            manage.InsertUser(this);
        }

        public Boolean check() //Checks if a user, with name and password, exists in the database
        {
            return manage.CheckUser(this);
        }

        public void readAll() //Read the users from the database and save them to the list
        {
            manage.ReadAll();
        }

        public void readUser() //Read a user through their id and assign their name
        {
            manage.ReadUser(this);
        }

        public void delete() //Delete a user from the database
        {
            manage.DeleteUser(this);
        }

        public void addRol(Rol rol) //Add a role to the user
        {
            manage.addRol(rol, this);
        }

        public void deleteRoles() //Remove all roles from the user
        {
            manage.deleteRoles(this);
        }

        public void setRolList() //Retrieves the roles assigned to the user and puts them in the list of user roles
        {
            manage.setRolList(this);
        }

        public void updateName(String name) //Modify the username
        {
            manage.UpdateName(this, name);
        }

        public void updatePass(String pass) //Modify the password
        {
            manage.UpdatePass(this, pass);
        }

        public int getUserID(String login, String pass) //Retrieve the user id through their name and password
        {
            return manage.getUserID(login, pass);
        }

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
