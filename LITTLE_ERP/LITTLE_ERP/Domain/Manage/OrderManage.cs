using LITTLE_ERP.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain.Manage
{
    /// <summary>
    /// Class for manage order, payment method and invoice objects
    /// </summary>
    class OrderManage
    {
        public List<Order> list { get; set; }
        public List<PaymentMethod> listP { get; set; }
        public List<Order> selectedList { get; set; }
        public List<Invoice> listI { get; set; }
        public List<Invoice> selectedListI { get; set; }

        public DataTable tInvoices { get; set; }
        public DataTable tOrders { get; set; }

        /// <summary>
        /// Initializes all the lists and datatables of the <see cref="OrderManage"/> class.
        /// </summary>
        public OrderManage()
        {
            list = new List<Order>();
            listP = new List<PaymentMethod>();
            selectedList = new List<Order>();
            listI = new List<Invoice>();
            selectedListI = new List<Invoice>();
            tInvoices = new DataTable();
            tOrders = new DataTable();
        }

        /// <summary>
        /// Reads all orders from the database.
        /// </summary>
        public void ReadAll()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT idOrder FROM Orders where deleted = 0 order by idOrder desc", "Orders");

            DataTable table = data.Tables["Orders"];

            Order aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new Order(Convert.ToInt64(row["idOrder"]));
                ReadOrder(aux);
                list.Add(aux);
            }
        }

        /// <summary>
        /// Reads a specific order from the database.
        /// </summary>
        /// <param name="order">The order.</param>
        public void ReadOrder(Order order)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT * FROM Orders where idOrder = " + order.idOrder, "Orders");

            DataTable table = data.Tables["Orders"];

            DataRow row = table.Rows[0];
            order.idCustomer = Convert.ToInt32(row["refCustomer"]);
            order.idUser = Convert.ToInt32(row["refUser"]);
            order.datetime = Convert.ToDateTime(row["datetime"]);
            order.idPaymentMethod = Convert.ToInt32(row["refPaymentMethod"]);
            order.total = Convert.ToDouble(row["total"]);
            order.prepaid = Convert.ToDouble(row["prepaid"]);

            setPaymentStatus(order);
            setCustomerUser(order);
            ReadAllOrderProducts(order);
        }

        /// <summary>
        /// Adds to a list all customers that meet a pattern.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        public void setSelectedList(string pattern)
        {
            selectedList.Clear();

            ReadAll();

            foreach (Order order in list)
            {
                if (order.ToString().Contains(pattern))
                {
                    selectedList.Add(order);
                }
            }

        }

        /// <summary>
        /// Reads all payment methods from the database.
        /// </summary>
        public void ReadAllPaymentMethods()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT * FROM PaymentMethods", "PaymentMethods");

            DataTable table = data.Tables["PaymentMethods"];

            PaymentMethod aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new PaymentMethod(Convert.ToInt32(row["IdPaymentMethod"]));
                aux.name = Convert.ToString(row["paymentMethod"]);
                listP.Add(aux);
            }
        }

        /// <summary>
        /// Retrieves the payment status of an order and sets it to the order.
        /// </summary>
        /// <param name="order">The order.</param>
        public void setPaymentStatus(Order order)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("select idPaymentMethod, paymentMethod from Paymentmethods where idpaymentmethod = " + order.idPaymentMethod , "Paymentmethods");

            DataTable table = data.Tables["Paymentmethods"];
            DataRow row = table.Rows[0];

            order.payment = new PaymentMethod(Convert.ToInt32(row["idPaymentMethod"]), Convert.ToString(row["paymentMethod"]));

            data = Search.getData("select confirmed, labeled, sent, invoiced from orders_status where idorder = " + order.idOrder, "orders_status");

            table = data.Tables["orders_status"];
            row = table.Rows[0];

            row[0] = Convert.ToBoolean(row[0]);

            Order.OrderStatus status = new Order.OrderStatus();
            status.confirmed = Convert.ToBoolean(row["confirmed"]);
            status.labeled = Convert.ToBoolean(row["labeled"]);
            status.sent = Convert.ToBoolean(row["sent"]);
            status.invoiced = Convert.ToBoolean(row["invoiced"]);

            order.status = status;

        }

        /// <summary>
        /// Retrieve the customer and the user of an order an set them to the order.
        /// </summary>
        /// <param name="order">The order.</param>
        public void setCustomerUser(Order order)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            Customer customer = new Customer(order.idCustomer);
            customer.ReadCustomer();
            order.customer = customer;

            User user = new User(order.idUser);
            user.readUser();
            order.user = user;

        }

        /// <summary>
        /// Gets the today maximum identifier for the order.
        /// </summary>
        public int getMaxOrderID()
        {
            ConnectOracle Search = new ConnectOracle();

            return Convert.ToInt32("0" + Search.DLookUp("count(*)", "Orders", "")) + 1;
        }

        /// <summary>
        /// Inserts the order in the database.
        /// </summary>
        /// <param name="order">The order.</param>
        public void InsertOrder(Order order)
        {
            ConnectOracle Search = new ConnectOracle();

            Search.setData("insert into orders (IDORDER, REFCUSTOMER, REFUSER, DATETIME, REFPAYMENTMETHOD, TOTAL, PREPAID, DELETED)" +
                " values ("+ order.idOrder +", "+ order.idCustomer +", "+ order.idUser +", '"+ order.datetime.ToString("dd/MM/yyyy") + 
                "', "+ order.payment.id +", "+ order.total +", "+ order.prepaid +", 0)");

            InsertOrderProducts(order);
            InsertOrderStatus(order);

        }

        /// <summary>
        /// Updates the order from the database.
        /// </summary>
        /// <param name="order">The order.</param>
        public void UpdateOrder(Order order)
        {
            ConnectOracle Search = new ConnectOracle();

            setPaymentStatus(order);

            Search.setData("Update Orders set REFCUSTOMER = " + order.idCustomer + ", REFUSER = " + order.idUser + ", REFPAYMENTMETHOD = " + order.payment + ", TOTAL = " + order.total + ", PREPAID = " + order.prepaid +
                " where idOrder = " + order.idOrder);
        }

        /// <summary>
        /// Deletes logicaly the order from the database.
        /// </summary>
        /// <param name="order">The order.</param>
        public void DeleteOrder(Order order)
        {
            ConnectOracle Search = new ConnectOracle();

            Search.setData("Update Orders set DELETED = 1 where idOrder = " + order.idOrder);
        }

        /// <summary>
        /// Reads all of the order products from the database.
        /// </summary>
        /// <param name="order">The order.</param>
        public void ReadAllOrderProducts(Order order)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("select op.refproduct, " +
                "(select f.frmdesc || ' ' || i.ingdesc from products p, forms f, ingredients i where p.idForm = f.idForm and p.idIngredient = i.idIngredient and p.idProduct = op.refProduct) description," +
                "op.pricesale, op.amount from ordersproducts op where op.deleted = 0 and op.reforder = " + order.idOrder +
                "union select - 1 refproduct, gp.description, gp.priceofsale, gp.amount " +
                "from genericproducts gp where gp.deleted = 0 and gp.idOrder = " + order.idOrder, "ORDERSPRODUCTS");

            DataTable table = data.Tables["ORDERSPRODUCTS"];

            foreach (DataRow row in table.Rows)
            {
                OrderProducts aux = new OrderProducts();
                
                aux.idProduct = Convert.ToInt32(row["refProduct"]);
                aux.description = Convert.ToString(row["description"]);
                aux.amount = Convert.ToInt32(row["amount"]);
                aux.pricesale = Convert.ToDouble(row["pricesale"]);

                order.listOP.Add(aux);
            }
        }

        /// <summary>
        /// Inserts the order products in the database.
        /// </summary>
        /// <param name="order">The order.</param>
        public void InsertOrderProducts(Order order)
        {
            ConnectOracle Search = new ConnectOracle();

            foreach (OrderProducts product in order.listOP)
            {
                if (product.idProduct == -1) //generic product
                {
                    //max id from generic products
                    int maximun = Convert.ToInt32("0" + Search.DLookUp("max(IDGENERICPRODUCT)", "GENERICPRODUCTS", "")) + 1;

                    Search.setData("insert into GENERICPRODUCTS (IDGENERICPRODUCT, IDORDER, DESCRIPTION, AMOUNT, PRICEOFSALE, DELETED)" +
                    " values (" + maximun + ", " + order.idOrder + ", '" + product.description + "', " + product.amount +
                    ", " + product.pricesale + ", 0)");
                }
                else //normal product
                {
                    //max id from order products
                    int maximun = Convert.ToInt32("0" + Search.DLookUp("max(IDORDERPRODUCT)", "ORDERSPRODUCTS", "")) + 1;

                    Search.setData("insert into ORDERSPRODUCTS (IDORDERPRODUCT, REFORDER, REFPRODUCT, AMOUNT, PRICESALE, DELETED)" +
                    " values (" + maximun + ", " + order.idOrder + ", " + product.idProduct + ", " + product.amount +
                    ", " + product.pricesale + ", 0)");
                }

            }

        }

        /// <summary>
        /// Inserts the order status.
        /// </summary>
        /// <param name="order">The order.</param>
        public void InsertOrderStatus(Order order)
        {
            ConnectOracle Search = new ConnectOracle();

            int confirmed, labeled, sent, invoiced;

            if (order.status.confirmed) confirmed = 1; else confirmed = 0;
            if (order.status.labeled) labeled = 1; else labeled = 0;
            if (order.status.sent) sent = 1; else sent = 0;
            if (order.status.invoiced) invoiced = 1; else invoiced = 0;

            Search.setData("insert into ORDERS_STATUS (IDORDER, CONFIRMED, LABELED, SENT, INVOICED)" +
                    " values (" + order.idOrder + ", " + confirmed + ", " + labeled + 
                    ", " + sent + ", " + invoiced + ")");
        }

        /// <summary>
        /// Updates the order status.
        /// </summary>
        /// <param name="order">The order.</param>
        public void UpdateOrderStatus(Order order)
        {
            ConnectOracle Search = new ConnectOracle();

            int confirmed, labeled, sent, invoiced;

            if (order.status.confirmed) confirmed = 1; else confirmed = 0;
            if (order.status.labeled) labeled = 1; else labeled = 0;
            if (order.status.sent) sent = 1; else sent = 0;
            if (order.status.invoiced) invoiced = 1; else invoiced = 0;

            Search.setData("update ORDERS_STATUS set CONFIRMED = "+ confirmed + 
                ", LABELED = "+ labeled + ", SENT = "+ sent +", INVOICED = "+ invoiced +
                " where IDORDER = "+ order.idOrder);
        }

        //
        // INVOICES
        //

        /// <summary>
        /// Reads all invoices for the database.
        /// </summary>
        public void ReadAllInvoices()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT idInvoice FROM Invoices where deleted = 0 order by IDINVOICE desc", "Invoices");

            DataTable table = data.Tables["Invoices"];

            Invoice aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new Invoice(Convert.ToInt64(row["idInvoice"]));
                ReadInvoice(aux);
                listI.Add(aux);
            }
        }

        /// <summary>
        /// Reads the invoice from the database.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        public void ReadInvoice(Invoice invoice)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT * FROM Invoices where idInvoice = " + invoice.id, "Invoices");

            DataTable table = data.Tables["Invoices"];

            DataRow row = table.Rows[0];
            invoice.date = Convert.ToDateTime(row["dateinvoice"]);
            if (Convert.ToInt32(row["accounted"]) == 0)
                invoice.accounted = false;
            else
                invoice.accounted = true;

            setOrder(invoice);
        }

        /// <summary>
        /// Retrieve the invoice's order and sets it to the invoice.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        public void setOrder(Invoice invoice)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            Int64 idOrder = Convert.ToInt64(Search.DLookUp("idOrder", "ORDERS_INVOICES", "idInvoice = " + invoice.id));

            Order aux = new Order();
            aux.idOrder = idOrder;
            ReadOrder(aux);

            invoice.order = aux;
        }

        /// <summary>
        /// Adds to a list all invoices that meet a pattern.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        public void setInvoicesSelectedList(string pattern)
        {
            selectedListI.Clear();

            ReadAll();

            foreach (Invoice invoice in listI)
            {
                if (invoice.ToString().Contains(pattern))
                {
                    selectedListI.Add(invoice);
                }
            }

        }

        /// <summary>
        /// Inserts the invoice in the database.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        public void InsertInvoice (Invoice invoice)
        {
            ConnectOracle Search = new ConnectOracle();

            Search.setData("Insert into invoices (IDINVOICE, DATEINVOICE, ACCOUNTED, DELETED)" +
                " values (" + invoice.id + ", '" + invoice.date.ToShortDateString() + "', 0, 0)");

            Search.setData("Insert into orders_invoices (IDORDERINVOICE, IDORDER, IDINVOICE) " +
                " values ((select count(*) from orders_invoices)+1,"+invoice.order.idOrder+","+invoice.id+")");
        }

        /// <summary>
        /// Logically deletes the invoice from the database.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        public void DeleteInvoice (Invoice invoice)
        {
            ConnectOracle Search = new ConnectOracle();

            Search.setData("Update invoices set deleted = 1 where idinvoice = " + invoice.id);
            Search.setData("Update orders_status set invoiced = 0 where idOrder = " + invoice.order.idOrder);
        }

        /// <summary>
        /// Gets the maximum invoice identifier.
        /// </summary>
        public int getMaxInvoiceID()
        {
            ConnectOracle Search = new ConnectOracle();

            return Convert.ToInt32("0" + Search.DLookUp("count(*)", "Invoices", "")) + 1;
        }

        /// <summary>
        /// Updates the accounted field of an invoice.
        /// </summary>
        /// <param name="invoice">The invoice.</param>
        public void UpdateAccounted(Invoice invoice)
        {
            ConnectOracle Search = new ConnectOracle();

            Search.setData("Update invoices set accounted = 1 where idinvoice = " + invoice.id);
        }

        //
        // REPORTS
        //

        /// <summary>
        /// Fill a datatable with the invoice data.
        /// </summary>
        /// <param name="i">The invoice.</param>
        public void MakeInvoiceDataTable(Invoice i)
        {
            tInvoices = new DataTable();

            tInvoices.Columns.Add("Name", Type.GetType("System.String"));
            tInvoices.Columns.Add("Surname", Type.GetType("System.String"));
            tInvoices.Columns.Add("Adress", Type.GetType("System.String"));
            tInvoices.Columns.Add("Region", Type.GetType("System.String"));
            tInvoices.Columns.Add("State", Type.GetType("System.String"));
            tInvoices.Columns.Add("City", Type.GetType("System.String"));
            tInvoices.Columns.Add("ZipCode", Type.GetType("System.String"));
            tInvoices.Columns.Add("id_invoice", Type.GetType("System.String"));
            tInvoices.Columns.Add("date", Type.GetType("System.String"));
            tInvoices.Columns.Add("total", Type.GetType("System.String"));

            tInvoices.Rows.Add(new Object[] { i.order.customer.name, i.order.customer.surname,
                i.order.customer.address, i.order.customer.region.name, i.order.customer.state.name, i.order.customer.city.name,
                i.order.customer.zipcode.name, i.id, i.date.ToString("d"), i.order.total});

        }

        /// <summary>
        /// Fill a datatable with the invoice's order data.
        /// </summary>
        /// <param name="i">The invoice.</param>
        public void MakeOrdersDataTable(Invoice i)
        {
            tOrders = new DataTable();

            tOrders.Columns.Add("Quantity", Type.GetType("System.String"));
            tOrders.Columns.Add("Description", Type.GetType("System.String"));
            tOrders.Columns.Add("Unity_price", Type.GetType("System.String"));
            tOrders.Columns.Add("Prepaid", Type.GetType("System.String"));

            foreach (OrderProducts p in i.order.listOP)
            {
                tOrders.Rows.Add(new Object[] { p.amount, p.description,
                p.pricesale, i.order.prepaid});
            }

        }

    }
}
