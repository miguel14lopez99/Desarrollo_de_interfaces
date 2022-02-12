using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    class Order
    {
        public class OrderStatus
        {
            public Boolean confirmed { get; set; }
            public Boolean labeled { get; set; }
            public Boolean sent { get; set; }
            public Boolean invoiced { get; set; }
        }

        public Int64 idOrder { get; set; }
        public int idCustomer { get; set; }
        public int idUser { get; set; }
        public DateTime datetime { get; set; }
        public int idPaymentMethod { get; set; }
        public double total { get; set; }
        public double prepaid { get; set; }

        public PaymentMethod payment { get; set; }
        public OrderStatus status { get; set; }
        public Customer customer { get; set; }
        public User user { get; set; }

        //me falta la lista de productos

        public Manage.OrderManage manage { get; set; }

        public Order()
        {
            manage = new Manage.OrderManage();
        }

        public Order(int idOrder)
        {
            manage = new Manage.OrderManage();
            this.idOrder = idOrder;
        }

        public void ReadAll()
        {
            manage.ReadAll();
        }

        public void ReadOrder()
        {
            manage.ReadOrder(this);
        }

        public void Insert()
        {
            manage.InsertOrder(this);
        }

        public void Update()
        {
            manage.UpdateOrder(this);
        }

        public void Delete()
        {
            manage.DeleteOrder(this);
        }

        public override string ToString()
        {
            return idOrder.ToString() + customer.name + user.name ;
        }


    }
}
