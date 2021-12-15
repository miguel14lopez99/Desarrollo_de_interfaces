using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    class User
    {
        public class UserPermissions
        {
            public Boolean addUser { get; set; }
            public Boolean editUser { get; set; }
            public Boolean showUser { get; set; }
            public Boolean deleteUser { get; set; }

            public UserPermissions()
            {

            }
        }

        public int idUser { get; set; }
        public String name { get; set; }
        public String password { get; set; }
        public List<Rol> rolesList;
        public UserPermissions userPermissions;

        public Manage.UserManage manage { get; set; }

        public User()
        {
            manage = new Manage.UserManage();
            rolesList = new List<Rol>();
            userPermissions = new UserPermissions();
        }

        public User(int idUser)
        {
            manage = new Manage.UserManage();
            rolesList = new List<Rol>();
            userPermissions = new UserPermissions();

            this.idUser = idUser;
            setRolList();
            setPermissions();
        }

        public User(String name, String password)
        {
            manage = new Manage.UserManage();
            rolesList = new List<Rol>();
            userPermissions = new UserPermissions();

            this.name = name;
            this.password = password;
            this.idUser = getUserID(name, password);
            setRolList();
            setPermissions();
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

        public void addRol(Rol rol)
        {
            manage.addRol(rol, this);
        }

        public void setRolList()
        {
            manage.setRolList(this);
        }

        public void updateName(String name)
        {
            manage.UpdateName(this, name);
        }

        public int getUserID(String login, String pass)
        {
            return manage.getUserID(login, pass);
        }

        public void setPermissions()
        {
            manage.setPermissions(this);
        }
    }
}
