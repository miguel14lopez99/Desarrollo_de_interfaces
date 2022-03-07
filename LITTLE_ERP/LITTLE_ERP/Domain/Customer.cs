using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    /// <summary>
    /// Class for create customer objects
    /// </summary>
    class Customer
    {

        public int idCustomer { get; set; }
        public String NIF { get; set; }
        public String name { get; set; }
        public String surname { get; set; }
        public String address { get; set; }
        public String phone { get; set; }
        public String email { get; set; }
        public int refZipCodesCities { get; set; }

        public Region region { get; set; }
        public State state { get; set; }
        public City city { get; set; }
        public ZipCode zipcode { get; set; }

        public Manage.CustomerManage manage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        public Customer()
        {
            manage = new Manage.CustomerManage();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="idCustomer">The customer identifier.</param>
        public Customer(int idCustomer)
        {
            manage = new Manage.CustomerManage();
            this.idCustomer = idCustomer;
        }

        /// <summary>
        /// Reads all customers from de database.
        /// </summary>
        public void ReadAll()
        {
            manage.ReadAll();
        }

        /// <summary>
        /// Reads a specific customer from the database.
        /// </summary>
        public void ReadCustomer()
        {
            manage.ReadCustomer(this);
        }

        /// <summary>
        /// Inserts the customer in the database.
        /// </summary>
        public void Insert()
        {
            manage.InsertCustomer(this);
        }

        /// <summary>
        /// Updates customer in the database.
        /// </summary>
        public void Update()
        {
            manage.UpdateCustomer(this);
        }

        /// <summary>
        /// Deletes the data base customer.
        /// </summary>
        public void Delete()
        {
            manage.DeleteCustomer(this);
        }

        /// <summary>
        /// Sets the zipcode_cities reference from database.
        /// </summary>
        /// <param name="zip">The zip.</param>
        public void setZipCodesCities(ZipCode zip)
        {
            manage.setZipCodesCities(this, zip);
        }

        /// <summary>
        /// Sets zipcode, city, state and region of the customer.
        /// </summary>
        /// <returns></returns>
        public void setZipCityStateRegion()
        {
            manage.setZipCityStateRegion(this);
        }

        public override string ToString()
        {
            return idCustomer + NIF + name + surname + address + phone + email + region.name + state.name + city.name + zipcode.name ;
        }
    }
}
