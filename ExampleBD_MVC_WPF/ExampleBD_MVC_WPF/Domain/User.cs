using ExampleBD_MVC_WPF.Domain.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleBD_MVC_WPF.Domain
{
    class User
    {
        public int idUser { get; set; }
        public String name { get; set; }
        public String password { get; set; }

        public Manage.UserManage manage { get; set; }

        public User()
        {
            manage = new Manage.UserManage();
        }

        public User(int idUser)
        {
            manage = new Manage.UserManage();
            this.idUser = idUser;
        }

        public void insert()
        {
            manage.InsertUser(this);
        }

        public Boolean check()
        {
            return manage.CheckUser(this);
        }

        public void readAll()
        {
            manage.ReadAll();
        }

        public void readUser()
        {
            manage.ReadUser(this);
        }

        public void delete()
        {
            manage.DeleteUser(this);
        }
    }
}
