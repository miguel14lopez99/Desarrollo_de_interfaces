using LITTLE_ERP.Domain.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    class PaymentMethod
    {
        public int id { get; set; }
        public String name { get; set; }

        public OrderManage manage { get; set; }

        public PaymentMethod()
        {
            manage = new OrderManage();
        }

        public PaymentMethod(int id)
        {
            this.id = id;
            manage = new OrderManage();
        }

        public PaymentMethod(int id, String name)
        {
            this.id = id;
            this.name = name;
            manage = new OrderManage();
        }

        public void ReadAll()
        {
            manage.ReadAllPaymentMethods();
        }
    }
}
