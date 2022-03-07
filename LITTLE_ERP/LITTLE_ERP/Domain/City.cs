using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    /// <summary>
    /// Class for create city objects
    /// </summary>
    class City
    {
        public int id { get; set; }
        public String name { get; set; }

        public Manage.CustomerManage manage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="City"/> class.
        /// </summary>
        public City()
        {
            this.manage = new Manage.CustomerManage();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="City"/> class.
        /// </summary>
        /// <param name="idCity">The city identifier.</param>
        public City(int idCity)
        {
            this.manage = new Manage.CustomerManage();
            this.id = idCity;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="City"/> class.
        /// </summary>
        /// <param name="idCity">The city identifier.</param>
        /// <param name="name">The city name.</param>
        public City(int idCity, String name)
        {
            this.manage = new Manage.CustomerManage();
            this.id = idCity;
            this.name = name;
        }

        /// <summary>
        /// Reads all the cities from a determined state.
        /// </summary>
        /// <param name="state">The state.</param>
        public void ReadAll(State state)
        {
            manage.ReadAllCities(state);
        }

        public override bool Equals(object obj)
        {
            return obj is City city &&
                   id == city.id;
        }
    }
}
