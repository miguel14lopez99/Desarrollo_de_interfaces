using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleCrystalReports.Domain
{
    class Client
    {
        public String name { get; set; }
        public String surname { get; set; }

        public Manage.ClientManage manage { get; set; }

        public Client()
        {
            manage = new Manage.ClientManage();
        }

        public void ReadAll()
        {
            manage.ReadAll();
        }

        public DataTable MakeReport()
        {
            return manage.MakeReport();
        }
    }
}
