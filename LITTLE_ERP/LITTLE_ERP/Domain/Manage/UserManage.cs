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

        public List<User> list { get; set; }

        public UserManage()
        {
            this.list = new List<User>();
        }

        public void ReadAll()
        {
            DataSet data = new DataSet(); //se necesita un DataSet para guardar lo que se rec
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT idUser FROM users where deleted=0", "users");

            DataTable table = data.Tables["users"];

            User aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new User(Convert.ToInt32(row["idUser"]));
                ReadUser(aux);
                list.Add(aux);
            }
        }

        public void ReadUser(User user)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT * FROM users where idUser=" + user.idUser, "users");

            DataTable table = data.Tables["users"];

            DataRow row = table.Rows[0];
            user.name = Convert.ToString(row["Name"]);
        }

        public void InsertUser(User user)
        {
            ConnectOracle Search = new ConnectOracle();

            int maximun = Convert.ToInt32("0" + Search.DLookUp("max(idUser)", "users", "")) + 1;

            user.idUser = maximun;

            Search.setData("INSERT INTO users VALUES(" + user.idUser + ",'" + user.name + "','" + user.password + "',0)");
        }

        public Boolean CheckUser(User user)
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

        public void DeleteUser(User user)
        {
            ConnectOracle Search = new ConnectOracle();

            Search.setData("Update users set deleted=1 where idUser = " + user.idUser);
        }

        //modificar nombre usuario
        public void UpdateName(User user, String newName)
        {
            ConnectOracle Search = new ConnectOracle();

            Search.setData("Update users set name='"+newName+"' where idUser = " + user.idUser);
        }

        //añadir rol a user
        public void addRol(Rol rol, User user)
        {
            ConnectOracle Search = new ConnectOracle();

            int maximun = Convert.ToInt32("0" + Search.DLookUp("max(IDUSER_ROL)", "users_roles", "")) + 1;

            Search.setData("INSERT INTO users_roles VALUES(" + maximun + ",'" + user.idUser + "','" + rol.idRol + "')");
        }

        //traerse los roles al usuario
        public void setRolList(User user)
        {
            DataSet data = new DataSet(); //se necesita un DataSet para guardar lo que se rec

            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT idRol FROM users_roles where idUser="+user.idUser, "users_roles");

            DataTable table = data.Tables["users_roles"];

            Rol aux;

            user.rolesList = new List<Rol>(); ;

            foreach (DataRow row in table.Rows)
            {
                aux = new Rol(Convert.ToInt32(row["idRol"]));
                aux.readRol();
                user.rolesList.Add(aux);
            }
        }

        public int getUserID(String name, String password)
        {
            ConnectOracle Search = new ConnectOracle();
            int userID = Convert.ToInt32(Search.DLookUp("idUser", "users", "name = '" + name + "' and password = '" + password+ "'"));
            return userID;
        }

        

    }
}
