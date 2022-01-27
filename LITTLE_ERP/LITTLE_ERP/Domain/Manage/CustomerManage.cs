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

        public List<Customer> list { get; set; }
        public List<Region> listR { get; set; }
        public List<State> listS { get; set; }
        public List<City> listC { get; set; }
        public List<ZipCode> listZ { get; set; }

        public CustomerManage()
        {
            this.list = new List<Customer>();
            this.listR = new List<Region>();
            this.listS = new List<State>();
            this.listC = new List<City>();
            this.listZ = new List<ZipCode>();
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
            customer.NIF = Convert.ToString(row["NIF"]);
            customer.name = Convert.ToString(row["name"]);
            customer.surname = Convert.ToString(row["surname"]);
            customer.address = Convert.ToString(row["address"]);
            customer.phone = Convert.ToString(row["phone"]);
            customer.email = Convert.ToString(row["email"]);
            customer.refZipCodesCities = Convert.ToInt32(row["refZipCodesCities"]);

        }

        public void InsertCustomer(Customer customer)
        {
            ConnectOracle Search = new ConnectOracle();

            int maximun = Convert.ToInt32("0" + Search.DLookUp("max(idCustomer)", "customers", "")) + 1;

            customer.idCustomer = maximun;
            customer.refZipCodesCities = 123;

            Search.setData("Insert into customers(idCustomer, NIF, name, surname, address, phone, email, refzipcodescities, deleted)" +
                " values ("+customer.idCustomer+", '"+ customer.NIF +"', '"+customer.name+"', '"+customer.surname+"', '"+customer.address+"', '"+customer.phone+"', '"+customer.email+"', "+customer.refZipCodesCities+", 0)");

        }

        public void DeleteCustomer(Customer customer)
        {
            ConnectOracle Search = new ConnectOracle();

            Search.setData("Delete from customers where idCustomer = " + customer.idCustomer);
        }

        public void ReadAllRegions()
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT * FROM regions", "regions");

            DataTable table = data.Tables["regions"];

            Region aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new Region(Convert.ToInt32(row["idRegion"]));
                aux.name = Convert.ToString(row["region"]);
                listR.Add(aux);
            }
        }


        public void ReadAllStates(Region region)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT * FROM states WHERE refregion = " + region.id, "states");

            DataTable table = data.Tables["states"];

            State aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new State(Convert.ToInt32(row["idState"]));
                aux.name = Convert.ToString(row["state"]);
                listS.Add(aux);
            }
        }

        public void ReadAllCities(State state)
        {
            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT DISTINCT idCity, city FROM cities C JOIN zipcodescities zc ON C.idcity = zc.refcity WHERE zc.refstate = " + state.id + " ORDER BY city", "cities");

            DataTable table = data.Tables["cities"];

            City aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new City(Convert.ToInt32(row["idCity"]));
                aux.name = Convert.ToString(row["city"]);
                listC.Add(aux);
            }
        }

        public void ReadAllZipCodes(City city)
        {

            DataSet data = new DataSet();
            ConnectOracle Search = new ConnectOracle();

            data = Search.getData("SELECT z.idzipcode, z.zipcode FROM zipcodes Z JOIN zipcodescities zc ON z.idzipcode = zc.refzipcode WHERE zc.refcity = " + city.id, "zipcodes");

            DataTable table = data.Tables["zipcodes"];

            ZipCode aux;

            foreach (DataRow row in table.Rows)
            {
                aux = new ZipCode(Convert.ToInt32(row["idZipcode"]));
                aux.name = Convert.ToInt32(row["zipcode"]);
                listZ.Add(aux);
            }

        }

    }
}
