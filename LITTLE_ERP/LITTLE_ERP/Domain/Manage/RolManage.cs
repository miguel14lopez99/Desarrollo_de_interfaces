using LITTLE_ERP.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain.Manage
{
    /// <summary>
    /// Class for manage rol objects
    /// </summary>
    class RolManage
    {

        public List<Rol> list { get; set; }

        /// <summary>
        /// Initializes the list of the <see cref="RolManage"/> class.
        /// </summary>
        public RolManage()
        {
            this.list = new List<Rol>();
        }

        /// <summary>
        /// Read all roles from the database.
        /// </summary>
        public void ReadAll()
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


        /// <summary>
        /// Reads a specific rol from the database.
        /// </summary>
        /// <param name="rol">The rol.</param>
        public void ReadRol(Rol rol)
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
