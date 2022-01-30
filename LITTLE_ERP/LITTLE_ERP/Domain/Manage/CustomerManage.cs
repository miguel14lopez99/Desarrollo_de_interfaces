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

            setZipCityStateRegion(customer);
        }

        public void setZipCityStateRegion(Customer customer)
        {
            if(customer.refZipCodesCities != 0)
            {
                DataSet data = new DataSet();
                ConnectOracle Search = new ConnectOracle();

                data = Search.getData("select z.idZipCode, z.zipCode, c.idCity, c.city, s.idState, s.state, r.idRegion, r.region " +
                    "from cities c, states s, regions r, zipcodes z, zipcodescities zc where " +
                    "zc.refcity = c.idcity and zc.refstate = s.idstate and zc.refzipcode = z.idzipcode and s.refregion = r.idregion and " +
                    "zc.idZipCodesCities = " + customer.refZipCodesCities, "zipcodescities");

                DataTable table = data.Tables["zipcodescities"];
                DataRow row = table.Rows[0];

                customer.zipcode = new ZipCode(Convert.ToInt32(row["idZipCode"]), Convert.ToString(row["zipCode"]));
                customer.city = new City(Convert.ToInt32(row["idCity"]), Convert.ToString(row["city"]));
                customer.state = new State(Convert.ToInt32(row["idState"]), Convert.ToString(row["state"]));
                customer.region = new Region(Convert.ToInt32(row["idRegion"]), Convert.ToString(row["region"]));
            }

        }
       
        public void setZipCodesCities(Customer customer, ZipCode zipcode)
        {
            ConnectOracle Search = new ConnectOracle();

            int count = Convert.ToInt32(Search.DLookUp("count(zc.idzipcodescities)", "zipcodes z, zipcodescities zc", "zc.refzipcode = z.idzipcode and z.zipcode = '" + zipcode.name + "'"));

            if (count != 0)
            {
                //take REFZIPCODESCITIES from a zipcode
                DataSet data = new DataSet();
                data = Search.getData("select zc.idzipcodescities from zipcodes z, zipcodescities zc where zc.refzipcode = z.idzipcode and z.zipcode = '" + zipcode.name + "'", "zipcodescities");
                DataTable table = data.Tables["zipcodescities"];
                DataRow row = table.Rows[0];
                customer.refZipCodesCities = Convert.ToInt32(row["idzipcodescities"]);
            }

        }

        public void InsertCustomer(Customer customer)
        {
            ConnectOracle Search = new ConnectOracle();

            int maximun = Convert.ToInt32("0" + Search.DLookUp("max(idCustomer)", "customers", "")) + 1;

            customer.idCustomer = maximun;

            setZipCodesCities(customer, customer.zipcode);

            Search.setData("Insert into customers(idCustomer, NIF, name, surname, address, phone, email, refzipcodescities, deleted)" +
                " values (" + customer.idCustomer + ", '" + customer.NIF + "', '" + customer.name + "', '" + customer.surname + "', '" 
                + customer.address + "', '" + customer.phone + "', '" + customer.email + "', " + customer.refZipCodesCities + ", 0)");

        }

        public void UpdateCustomer(Customer customer)
        {
            ConnectOracle Search = new ConnectOracle();

            setZipCodesCities(customer, customer.zipcode);

            Search.setData("Update customers set nif = '"+ customer.NIF +"', name = '"+ customer.name +"', surname = '"+ customer.surname +
                "', address = '"+ customer.address +"', phone = "+ customer.phone +", email = '"+ customer.email +"', refzipcodescities = "
                + customer.refZipCodesCities + " where idcustomer = " + customer.idCustomer);
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
            if(region != null)
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
           
        }

        public void ReadAllCities(State state)
        {
            if(state != null)
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
            
        }

        public void ReadAllZipCodes(City city)
        {
            if(city != null)
            {
                DataSet data = new DataSet();
                ConnectOracle Search = new ConnectOracle();

                data = Search.getData("SELECT z.idzipcode, z.zipcode FROM zipcodes Z JOIN zipcodescities zc ON z.idzipcode = zc.refzipcode WHERE zc.refcity = " + city.id, "zipcodes");

                DataTable table = data.Tables["zipcodes"];

                ZipCode aux;

                foreach (DataRow row in table.Rows)
                {
                    aux = new ZipCode(Convert.ToInt32(row["idZipcode"]));
                    aux.name = Convert.ToString(row["zipcode"]);
                    listZ.Add(aux);
                }
            }

        }

    }
}
