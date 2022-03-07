using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LITTLE_ERP.Domain
{
    /// <summary>
    /// Class for create Suplier objects
    /// </summary>
    class Suplier
    {
        public int idSuplier { get; set; }
        public String name { get; set; }
        public String goods { get; set; }

        public Manage.SuplierManage manage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Suplier"/> class.
        /// </summary>
        public Suplier()
        {
            manage = new Manage.SuplierManage();
        }

        /// <summary>
        /// Reads all supliers from a Json file.
        /// </summary>
        public void ReadAll()
        {
            manage.ReadAll();
        }

        public override string ToString()
        {
            return idSuplier + name + goods;
        }

    }
}
