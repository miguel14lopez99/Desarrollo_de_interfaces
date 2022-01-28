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

        public Region(int idRegion, String name)
        {
            this.manage = new Manage.CustomerManage();
            this.id = idRegion;
            this.name = name;
        }

        public void ReadAll()
        {
            manage.ReadAllRegions();
        }

        public override bool Equals(object obj)
        {
            return obj is Region region &&
                   id == region.id;
        }
    }
}
