using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    /// <summary>
    /// Class for create ZipCode objects
    /// </summary>
    class ZipCode
    {
        public int id { get; set; }
        public String name { get; set; }

        public Manage.CustomerManage manage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZipCode"/> class.
        /// </summary>
        public ZipCode()
        {
            this.manage = new Manage.CustomerManage();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZipCode"/> class.
        /// </summary>
        /// <param name="idZipCode">The zip code identifier.</param>
        public ZipCode(int idZipCode)
        {
            this.manage = new Manage.CustomerManage();
            this.id = idZipCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZipCode"/> class.
        /// </summary>
        /// <param name="idZipCode">The zip code identifier.</param>
        /// <param name="name">The zip code name.</param>
        public ZipCode(int idZipCode, String name)
        {
            this.manage = new Manage.CustomerManage();
            this.id = idZipCode;
            this.name = name;
        }

        /// <summary>
        /// Reads all zip codes from a determined city.
        /// </summary>
        /// <param name="city">The city.</param>
        public void ReadAll(City city)
        {
            manage.ReadAllZipCodes(city);
        }

        public override bool Equals(object obj)
        {
            return obj is ZipCode code &&
                   id == code.id;
        }
    }
}
