using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ExampleBD_MVC_WPF.Domain.Manage
{
    class UserManage
    {

        public List<User> list { get; set; }
        
        public UserManage()
        {
            list = new List<User>();
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

            data = Search.getData("SELECT * FROM users where idUser="+user.idUser, "users");

            DataTable table = data.Tables["users"];

            DataRow row = table.Rows[0];
            user.name = Convert.ToString(row["Name"]);
        }

        public void InsertUser(User user)
        {
            ConnectOracle Search = new ConnectOracle();
            Resources.useful useful = new Resources.useful();

            user.password = useful.getHashSha256(user.password);

            int maximun = Convert.ToInt32("0"+Search.DLookUp("max(idUser)","users","")) + 1;

            Search.setData("INSERT INTO users VALUES("+maximun+",'"+user.name+"','"+user.password+"',0)");
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

            Search.setData("Update users set deleted=1 where idUser = "+user.idUser);
        }
    }
}
