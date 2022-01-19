using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    class Customer
    {

        public int idCustomer { get; set; }
        public String name { get; set; }
        public String surname { get; set; }
        public String address { get; set; }
        public String phone { get; set; }
        public String email { get; set; }
        public String refZipCodesCities { get; set; }

        public Manage.CustomerManage manage { get; set; }

        public Customer()
        {
            manage = new Manage.CustomerManage();
        }

        public Customer(int idCustomer)
        {
            manage = new Manage.CustomerManage();
            this.idCustomer = idCustomer;
        }

        public void ReadAll()
        {
            manage.ReadAll();
        }

        public void ReadCustomer()
        {
            manage.ReadCustomer(this);
        }

        public void Insert()
        {
            manage.InsertCustomer(this);
        }

        public void Delete()
        {
            manage.DeleteCustomer(this);
        }

    }
}
