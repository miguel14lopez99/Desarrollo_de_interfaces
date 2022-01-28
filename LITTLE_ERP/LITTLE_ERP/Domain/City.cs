using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    class City
    {

        public int id { get; set; }
        public String name { get; set; }

        public Manage.CustomerManage manage { get; set; }

        public City()
        {
            this.manage = new Manage.CustomerManage();
        }

        public City(int idCity)
        {
            this.manage = new Manage.CustomerManage();
            this.id = idCity;
        }

        public City(int idCity, String name)
        {
            this.manage = new Manage.CustomerManage();
            this.id = idCity;
            this.name = name;
        }

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
