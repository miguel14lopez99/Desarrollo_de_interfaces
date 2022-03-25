using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleJSON.Domain.Manage;

namespace ExampleJSON.Domain
{
    class People
    {
        public int DNI { get; set; }
        public String name { get; set; }
        public String gender { get; set; }

        public PeopleManage manage { get; set; }

        public People()
        {
            manage = new PeopleManage();
        }

        public void ReadAll()
        {
            manage.ReadAll();
        }
    }
}
