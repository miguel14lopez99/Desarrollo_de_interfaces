using LITTLE_ERP.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain.Manage
{
    class RolManage
    {

        public List<Rol> list { get; set; }

        public RolManage()
        {
            this.list = new List<Rol>();
        }

        public void ReadAll()
        {
            DataSet data = new DataSet(); //se necesita un DataSet para guardar lo que se rec
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT idUser FROM users where deleted=0", "users");

            DataTable table = data.Tables["users"];

            Rol aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new Rol(Convert.ToInt32(row["idRol"]));
                ReadRol(aux);
                list.Add(aux);
            }
        }

        public void ReadRol(Rol rol)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT * FROM roles where idRol=" + rol.idRol, "roles");

            DataTable table = data.Tables["roles"];

            DataRow row = table.Rows[0];
            rol.description = Convert.ToString(row["Description"]);
        }

    }
}
