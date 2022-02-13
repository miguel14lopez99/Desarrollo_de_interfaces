using LITTLE_ERP.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain.Manage
{
    class OrderManage
    {
        public List<Order> list { get; set; }
        public List<PaymentMethod> listP { get; set; }
        public List<Order> selectedList { get; set; }
        

        public OrderManage()
        {
            list = new List<Order>();
            listP = new List<PaymentMethod>();
            selectedList = new List<Order>();
            
        }

        public void ReadAll()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT idOrder FROM Orders where deleted = 0", "Orders");

            DataTable table = data.Tables["Orders"];

            Order aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new Order(Convert.ToInt64(row["idOrder"]));
                ReadOrder(aux);
                list.Add(aux);
            }
        }

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

        public int getTodayMaxID()
        {
            ConnectOracle Search = new ConnectOracle();

            return Convert.ToInt32("0" + Search.DLookUp("count(*)", "Orders", "")) + 1;
        }

        public void InsertOrder(Order order)
        {
            ConnectOracle Search = new ConnectOracle();

            Search.setData("insert into orders (IDORDER, REFCUSTOMER, REFUSER, DATETIME, REFPAYMENTMETHOD, TOTAL, PREPAID, DELETED)" +
                " values ("+ order.idOrder +", "+ order.idCustomer +", "+ order.idUser +", '"+ order.datetime.ToString("dd/MM/yyyy") + 
                "', "+ order.payment.id +", "+ order.total +", "+ order.prepaid +", 0)");

        }

        public void UpdateOrder(Order order)
        {
            ConnectOracle Search = new ConnectOracle();

            setPaymentStatus(order);

            Search.setData("Update Orders set REFCUSTOMER = " + order.idCustomer + ", REFUSER = " + order.idUser + ", REFPAYMENTMETHOD = " + order.payment + ", TOTAL = " + order.total + ", PREPAID = " + order.prepaid +
                " where idOrder = " + order.idOrder);
        }

        public void DeleteOrder(Order order)
        {
            ConnectOracle Search = new ConnectOracle();

            Search.setData("Update Orders set DELETED = 1 where idOrder = " + order.idOrder);
        }

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

        public void InsertOrderProducts(Order order)
        {
            ConnectOracle Search = new ConnectOracle();

            foreach (OrderProducts product in order.listOP)
            {
                if (product.idProduct == -1) //generic product
                {
                    //max id from generic products
                    int maximun = Convert.ToInt32("0" + Search.DLookUp("count(*)", "GENERICPRODUCTS", "")) + 1;

                    Search.setData("insert into GENERICPRODUCTS (IDGENERICPRODUCT, IDORDER, DESCRIPTION, AMOUNT, PRICEOFSALE, DELETED)" +
                    " values (" + maximun + ", " + product.idOrder + ", '" + product.description + "', " + product.amount +
                    ", " + product.pricesale + ", 0)");
                }
                else //normal product
                {
                    //max id from order products
                    int maximun = Convert.ToInt32("0" + Search.DLookUp("count(*)", "ORDERSPRODUCTS", "")) + 1;

                    Search.setData("insert into ORDERSPRODUCTS (IDORDERPRODUCT, REFORDER, REFPRODUCT, AMOUNT, PRICESALE, DELETED)" +
                    " values (" + maximun + ", " + product.idOrder + ", " + product.idProduct + ", " + product.amount +
                    ", " + product.pricesale + ", 0)");
                }

            }

        }

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
    }
}
