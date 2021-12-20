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

        public void ReadAll() //Read the roles from the database and save them to the list
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT idRol FROM roles where deleted=0", "roles");

            DataTable table = data.Tables["roles"];

            Rol aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new Rol(Convert.ToInt32(row["idRol"]));
                ReadRol(aux);
                list.Add(aux);
            }
        }

        public void ReadRol(Rol rol) //Read a role through their id and assign their description
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT * FROM roles where idRol =" + rol.idRol, "roles");

            DataTable table = data.Tables["roles"];

            DataRow row = table.Rows[0];
            rol.description = Convert.ToString(row["description"]);
        }

        

    }
}
