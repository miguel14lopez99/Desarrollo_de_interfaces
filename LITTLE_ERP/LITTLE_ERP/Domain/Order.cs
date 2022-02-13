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

        public List<OrderProducts> listOP { get; set; }

        public PaymentMethod payment { get; set; }
        public OrderStatus status { get; set; }
        public Customer customer { get; set; }
        public User user { get; set; }


        public Manage.OrderManage manage { get; set; }

        public Order()
        {
            manage = new Manage.OrderManage();
            listOP = new List<OrderProducts>();
            status = new OrderStatus();
            prepaid = 0;
        }

        public Order(Int64 idOrder)
        {
            manage = new Manage.OrderManage();
            this.idOrder = idOrder;
            listOP = new List<OrderProducts>();
            status = new OrderStatus();
            prepaid = 0;
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

        public void ReadAllOrderProducts()
        {
            manage.ReadAllOrderProducts(this);
        }

        public void InsertOrderProducts()
        {
            manage.InsertOrderProducts(this);
        }

        public void InsertOrderStatus()
        {
            manage.InsertOrderStatus(this);
        }

        public void UpdateOrderStatus()
        {
            manage.UpdateOrderStatus(this);
        }

        public override string ToString()
        {
            return idOrder.ToString() + customer.name + user.name ;
        }


    }
}
