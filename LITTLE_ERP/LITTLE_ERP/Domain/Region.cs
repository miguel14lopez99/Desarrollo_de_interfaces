using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    class Region
    {

        public int id { get; set; }
        public String name { get; set; }

        public Manage.CustomerManage manage { get; set; }

        public Region()
        {
            this.manage = new Manage.CustomerManage();
        }

        public Region(int idRegion)
        {
            this.manage = new Manage.CustomerManage();
            this.id = idRegion;
        }

        public void ReadAll()
        {
            manage.ReadAllRegions();
        }
    }
}
