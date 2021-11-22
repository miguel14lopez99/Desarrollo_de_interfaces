using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    class Permission
    {
        public int idPermision { get; set; }
        public String description { get; set; }

        public Manage.PermissionManage manage { get; set; }

        public Permission()
        {
            manage = new Manage.PermissionManage();
        }

        public Permission(int idPermission)
        {
            manage = new Manage.PermissionManage();
            this.idPermision = idPermission;
        }

    }
}
