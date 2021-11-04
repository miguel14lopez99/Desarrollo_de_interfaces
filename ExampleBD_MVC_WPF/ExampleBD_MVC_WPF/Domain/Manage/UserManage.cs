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
            DataSet data = new DataSet();
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

            Search.setData("INSERT INTO users VALUES("+user.idUser+","+user.name+","+user.password+")");
        }

        public Boolean CheckUser(User user)
        {
            return true;
        }
    }
}
