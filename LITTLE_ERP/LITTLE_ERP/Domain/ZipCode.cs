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
        public int name { get; set; }

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

        public void ReadAll(City city)
        {
            manage.ReadAllZipCodes(city);
        }

    }
}
