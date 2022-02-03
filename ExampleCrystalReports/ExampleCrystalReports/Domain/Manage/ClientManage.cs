using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleCrystalReports.Domain.Manage
{
    class ClientManage
    {

        public List<Client> list { get; set; }
        public DataTable tCustomers { get; set; }

        public ClientManage()
        {
            tCustomers = new DataTable();
            list = new List<Client>();
        }

        public void ReadAll()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT name,surname FROM customers", "customers");

            tCustomers = data.Tables["customers"];

        }

        public DataTable MakeReport()
        {
            DataTable tmp = new DataTable();

            tmp.Columns.Add("Name", Type.GetType("System.String"));
            tmp.Columns.Add("Surname", Type.GetType("System.String"));

            //datos de la base de datos
            foreach (DataRow row in tCustomers.Rows)
            {
                tmp.Rows.Add(new Object[] { row["Name"], row["Surname"] });
            }

            return tmp;
        }

    }
}
