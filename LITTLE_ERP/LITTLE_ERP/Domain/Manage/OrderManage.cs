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

            data = Search.getData("SELECT idOrder FROM Orders where deleted=0", "Orders");

            DataTable table = data.Tables["Orders"];

            Order aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new Order(Convert.ToInt32(row["idOrder"]));
                ReadOrder(aux);
                list.Add(aux);
            }
        }

        public void ReadOrder(Order Order)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT * FROM Orders where idOrder = " + Order.idOrder, "Orders");

            DataTable table = data.Tables["Orders"];

            DataRow row = table.Rows[0];
            Order.idCustomer = Convert.ToInt32(row["refCustomer"]);
            Order.idUser = Convert.ToInt32(row["refUser"]);
            Order.datetime = Convert.ToDateTime(row["datetime"]);
            Order.idPaymentMethod = Convert.ToInt32(row["refPaymentMethod"]);
            Order.total = Convert.ToDouble(row["total"]);
            Order.prepaid = Convert.ToDouble(row["prepaid"]);

            setPaymentStatus(Order);
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

        public void InsertOrder(Order order)
        {
            ConnectOracle Search = new ConnectOracle();

            order.datetime = DateTime.Now;

            int maximun = Convert.ToInt32("0" + Search.DLookUp("count(*)", "Orders", "TO_CHAR(datetime, 'DD/MM/YYYY') = TO_CHAR(sysdate, 'DD/MM/YYYY')")) + 1;

            Int64 id = Convert.ToInt64(order.datetime.ToString("yyyyMMdd") + maximun.ToString("0000"));

            order.idOrder = id;

            setPaymentStatus(order);

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

        public void DeleteOrder(Order Order)
        {
            ConnectOracle Search = new ConnectOracle();

            Search.setData("Delete from Orders where idOrder = " + Order.idOrder);
        }
    }
}
