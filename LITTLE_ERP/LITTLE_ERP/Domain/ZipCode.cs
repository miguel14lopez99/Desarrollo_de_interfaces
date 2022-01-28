using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    class ZipCode
    {
        public int id { get; set; }
        public String name { get; set; }

        public Manage.CustomerManage manage { get; set; }

        public ZipCode()
        {
            this.manage = new Manage.CustomerManage();
        }

        public ZipCode(int idZipCode)
        {
            this.manage = new Manage.CustomerManage();
            this.id = idZipCode;
        }

        public ZipCode(int idZipCode, String name)
        {
            this.manage = new Manage.CustomerManage();
            this.id = idZipCode;
            this.name = name;
        }

        public void ReadAll(City city)
        {
            manage.ReadAllZipCodes(city);
        }

        public override bool Equals(object obj)
        {
            return obj is ZipCode code &&
                   id == code.id;
        }
    }
}
