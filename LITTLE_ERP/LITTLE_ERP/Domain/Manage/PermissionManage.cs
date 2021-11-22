using LITTLE_ERP.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain.Manage
{
    class PermissionManage
    {

        public List<Permission> list { get; set; }

        public PermissionManage()
        {
            this.list = new List<Permission>();
        }

        public void ReadAll()
        {
            DataSet data = new DataSet(); //se necesita un DataSet para guardar lo que se rec
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT idPermission FROM permissions where deleted=0", "permissions");

            DataTable table = data.Tables["permissions"];

            Permission aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new Permission(Convert.ToInt32(row["idPermission"]));
                ReadPermission(aux);
                list.Add(aux);
            }
        }

        public void ReadPermission(Permission permission)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT * FROM permissions where idPermission=" + permission.idPermision, "permissions");

            DataTable table = data.Tables["permissions"];

            DataRow row = table.Rows[0];
            permission.description = Convert.ToString(row["Description"]);
        }

    }
}
