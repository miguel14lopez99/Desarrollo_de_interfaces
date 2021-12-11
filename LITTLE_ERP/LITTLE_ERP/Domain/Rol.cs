using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    class Rol
    {
        public int idRol { get; set; }
        public String description { get; set; }

        public Manage.RolManage manage { get; set; }

        public Rol()
        {
            manage = new Manage.RolManage();
        }

        public Rol(int idRol)
        {
            manage = new Manage.RolManage();
            this.idRol = idRol;
        }      

        public void readAll()
        {
            manage.ReadAll();
        }

        public void readRol()
        {
            manage.ReadRol(this);
        }

        public override string ToString()
        {
            return description;
        }

    }

    
}
