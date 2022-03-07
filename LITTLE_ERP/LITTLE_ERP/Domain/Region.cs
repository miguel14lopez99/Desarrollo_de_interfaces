using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    /// <summary>
    /// Class for create Region objects
    /// </summary>
    class Region
    {

        public int id { get; set; }
        public String name { get; set; }

        public Manage.CustomerManage manage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Region"/> class.
        /// </summary>
        public Region()
        {
            this.manage = new Manage.CustomerManage();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Region"/> class.
        /// </summary>
        /// <param name="idRegion">The region identifier.</param>
        public Region(int idRegion)
        {
            this.manage = new Manage.CustomerManage();
            this.id = idRegion;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Region"/> class.
        /// </summary>
        /// <param name="idRegion">The region identifier.</param>
        /// <param name="name">The region name.</param>
        public Region(int idRegion, String name)
        {
            this.manage = new Manage.CustomerManage();
            this.id = idRegion;
            this.name = name;
        }

        /// <summary>
        /// Reads all regions from the database.
        /// </summary>
        public void ReadAll()
        {
            manage.ReadAllRegions();
        }

        public override bool Equals(object obj)
        {
            return obj is Region region &&
                   id == region.id;
        }
    }
}
