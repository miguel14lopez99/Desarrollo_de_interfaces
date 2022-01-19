using LITTLE_ERP.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain.Manage
{
    class CustomerManage
    {

        List<Customer> list { get; set; }

        public CustomerManage()
        {
            this.list = new List<Customer>();
        }

        public void ReadAll()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT idCustomer FROM customers where deleted=0", "customers");

            DataTable table = data.Tables["customers"];

            Customer aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new Customer(Convert.ToInt32(row["idCustomer"]));
                ReadCustomer(aux);
                list.Add(aux);
            }

        }

        public void ReadCustomer(Customer customer)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT * FROM customers where idCustomer=" + customer.idCustomer, "customers");

            DataTable table = data.Tables["customers"];

            DataRow row = table.Rows[0];
            customer.name = Convert.ToString(row["name"]);
            customer.surname = Convert.ToString(row["surname"]);
        }

        public void InsertCustomer(Customer customer)
        {
            ConnectOracle Search = new ConnectOracle();

            int maximun = Convert.ToInt32("0" + Search.DLookUp("max(idUser)", "users", "")) + 1;

            customer.idCustomer = maximun;

            Search.setData("Insert into customers(idCustomer, name, surname, address, phone, email, refzipcodescities, deleted)" +
                " values ("+customer.idCustomer+", '"+customer.name+"', '"+customer.address+"', '"+customer.address+"', "+customer.phone+", '"+customer.email+"', "+customer.refZipCodesCities+", 0)");

        }

        public void DeleteCustomer(Customer customer)
        {
            ConnectOracle Search = new ConnectOracle();

            Search.setData("Delete from customers where idCustomer = " + customer.idCustomer);
        }
    }
}
