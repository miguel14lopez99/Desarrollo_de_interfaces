using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ExampleReports.Domain.Manage
{
    class ClientManage
    {
       
        public DataTable tcustomers { get; set; }

        public ClientManage()
        {
            tcustomers = new DataTable();        
        }

        public void readAll()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("Select name,surname from Customers", "customers");
            DataTable tmp = data.Tables["customers"];

            tcustomers.Columns.Add("Name", Type.GetType("System.String"));
            tcustomers.Columns.Add("Surname", Type.GetType("System.String"));

            // Data from the database
            foreach (DataRow row in tmp.Rows)
            {
                tcustomers.Rows.Add(new Object[] { row["Name"], row["Surname"] });
            }

        }
    }
}
