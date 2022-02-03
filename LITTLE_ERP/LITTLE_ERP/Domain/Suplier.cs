using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    class Suplier
    {
        public int idSuplier { get; set; }
        public String name { get; set; }
        public String goods { get; set; }

        public Manage.SuplierManage manage { get; set; }

        public Suplier()
        {
            manage = new Manage.SuplierManage();
        }

        public void ReadAll()
        {
            manage.ReadAll();
        }

        public override string ToString()
        {
            return idSuplier + name + goods;
        }

    }
}
