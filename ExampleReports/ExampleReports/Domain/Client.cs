using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleReports.Domain
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

        public void readAll ()
        {
            manage.readAll();
        }

      
    }
}
