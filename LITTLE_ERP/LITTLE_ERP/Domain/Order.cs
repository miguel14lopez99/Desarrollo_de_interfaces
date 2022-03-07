using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    /// <summary>
    /// Class for create order objects
    /// </summary>
    class Order
    {
        /// <summary>
        /// Class for create the order's status
        /// </summary>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        public Order()
        {
            manage = new Manage.OrderManage();
            listOP = new List<OrderProducts>();
            status = new OrderStatus();
            prepaid = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="idOrder">The identifier order.</param>
        public Order(Int64 idOrder)
        {
            manage = new Manage.OrderManage();
            this.idOrder = idOrder;
            listOP = new List<OrderProducts>();
            status = new OrderStatus();
            prepaid = 0;
        }

        /// <summary>
        /// Reads all orders from the database.
        /// </summary>
        public void ReadAll()
        {
            manage.ReadAll();
        }

        /// <summary>
        /// Reads a specific order from the database.
        /// </summary>
        public void ReadOrder()
        {
            manage.ReadOrder(this);
        }

        /// <summary>
        /// Inserts the order in the database.
        /// </summary>
        public void Insert()
        {
            manage.InsertOrder(this);
        }

        /// <summary>
        /// Updates the order data from the database.
        /// </summary>
        public void Update()
        {
            manage.UpdateOrder(this);
        }

        /// <summary>
        /// Deletes the order from the database.
        /// </summary>
        public void Delete()
        {
            manage.DeleteOrder(this);
        }

        /// <summary>
        /// Reads all order products from database.
        /// </summary>
        public void ReadAllOrderProducts()
        {
            manage.ReadAllOrderProducts(this);
        }

        /// <summary>
        /// Inserts the order products in the database.
        /// </summary>
        public void InsertOrderProducts()
        {
            manage.InsertOrderProducts(this);
        }

        /// <summary>
        /// Inserts the order status in the database.
        /// </summary>
        public void InsertOrderStatus()
        {
            manage.InsertOrderStatus(this);
        }

        /// <summary>
        /// Updates the order status from the database.
        /// </summary>
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
