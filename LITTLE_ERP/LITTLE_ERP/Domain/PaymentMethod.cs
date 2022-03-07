using LITTLE_ERP.Domain.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    /// <summary>
    /// Class for create PaymentMethods objects
    /// </summary>
    class PaymentMethod
    {
        public int id { get; set; }
        public String name { get; set; }

        public OrderManage manage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentMethod"/> class.
        /// </summary>
        public PaymentMethod()
        {
            manage = new OrderManage();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentMethod"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public PaymentMethod(int id)
        {
            this.id = id;
            manage = new OrderManage();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentMethod"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        public PaymentMethod(int id, String name)
        {
            this.id = id;
            this.name = name;
            manage = new OrderManage();
        }

        /// <summary>
        /// Reads all payment methods from database.
        /// </summary>
        public void ReadAll()
        {
            manage.ReadAllPaymentMethods();
        }
    }
}
