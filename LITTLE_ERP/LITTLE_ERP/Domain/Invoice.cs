using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    /// <summary>
    /// Class for create invoice objects
    /// </summary>
    class Invoice
    {
        public Int64 id { get; set; }
        public DateTime date { get; set; }
        public Boolean accounted { get; set; }

        public Order order { get; set; }

        public Manage.OrderManage manage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Invoice"/> class.
        /// </summary>
        public Invoice()
        {
            this.manage = new Manage.OrderManage();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Invoice"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public Invoice(Int64 id)
        {
            this.id = id;
            this.manage = new Manage.OrderManage();
        }

        /// <summary>
        /// Reads all invoices from the database.
        /// </summary>
        public void ReadAll()
        {
            manage.ReadAllInvoices();
        }

        /// <summary>
        /// Reads an spacific invoice from the database.
        /// </summary>
        public void ReadInvoice()
        {
            manage.ReadInvoice(this);
        }

        /// <summary>
        /// Inserts the invoice in the database.
        /// </summary>
        public void Insert()
        {
            manage.InsertInvoice(this);
        }

        /// <summary>
        /// Deletes the invoice from the database.
        /// </summary>
        public void Delete()
        {
            manage.DeleteInvoice(this);
        }

        /// <summary>
        /// Updates the accounted field of the invoice.
        /// </summary>
        public void UpdateAccounted()
        {
            manage.UpdateAccounted(this);
        }

        /// <summary>
        /// Fill a datatable with the invoice data.
        /// </summary>
        public void MakeInvoiceDataTable()
        {
            manage.MakeInvoiceDataTable(this);
        }

        /// <summary>
        /// Fill a datatable with the invoice's order data.
        /// </summary>
        public void MakeOrdersDataTable()
        {
            manage.MakeOrdersDataTable(this);
        }

        public override string ToString()
        {
            return id.ToString() + order.idOrder.ToString();
        }


    }
}
