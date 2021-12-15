using LITTLE_ERP.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain.Manage
{
    class UserManage
    {

        public List<User> list { get; set; } //List where users are stored

        public UserManage()
        {
            this.list = new List<User>();
        }

        public void ReadAll() //Read the users from the database and save them to the list
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT idUser FROM users where deleted=0", "users"); //all users who are not deleted are recovered

            DataTable table = data.Tables["users"];

            User aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new User(Convert.ToInt32(row["idUser"]));
                ReadUser(aux);
                list.Add(aux);
            }
        }

        public void ReadUser(User user) //Read a user through their id and assign their name
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT * FROM users where idUser=" + user.idUser, "users");

            DataTable table = data.Tables["users"];

            DataRow row = table.Rows[0];
            user.name = Convert.ToString(row["Name"]);
        }

        public void InsertUser(User user) //Insert a user in the database
        {
            ConnectOracle Search = new ConnectOracle();

            int maximun = Convert.ToInt32("0" + Search.DLookUp("max(idUser)", "users", "")) + 1;

            user.idUser = maximun;

            Search.setData("INSERT INTO users VALUES(" + user.idUser + ",'" + user.name + "','" + user.password + "',0)");
        }

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

        public void DeleteUser(User user) //Delete a user from the database
        {
            ConnectOracle Search = new ConnectOracle();

            Search.setData("Update users set deleted=1 where idUser = " + user.idUser);
        }

        public void UpdateName(User user, String newName) //Modify the username
        {
            ConnectOracle Search = new ConnectOracle();

            Search.setData("Update users set name='"+newName+"' where idUser = " + user.idUser);
        }

        public void addRol(Rol rol, User user) //Add a role to the user
        {
            ConnectOracle Search = new ConnectOracle();

            int maximun = Convert.ToInt32("0" + Search.DLookUp("max(IDUSER_ROL)", "users_roles", "")) + 1;

            Search.setData("INSERT INTO users_roles VALUES(" + maximun + ",'" + user.idUser + "','" + rol.idRol + "')");
        }

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

        public int getUserID(String name, String password) //Retrieve the user id through their name and password
        {
            ConnectOracle Search = new ConnectOracle();
            int userID = Convert.ToInt32(Search.DLookUp("idUser", "users", "name = '" + name + "' and password = '" + password+ "'"));
            return userID;
        }

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
                    }
                }
            }


            
        }

    }
}
